open System

let input = System.IO.File.ReadAllLines("./inputs/input05.txt")

let react (unitA : char) (unitB : char) =
    unitA <> unitB && 
    Char.ToLower(unitA) = Char.ToLower(unitB)

let calculateReactions (rawPolymer : string) =
    let rec loop (polymer : string) i (previousUnit : char) (acc : char list) count =
        match previousUnit with
        | c when i >= polymer.Length && count > 0 ->
            let newPolymer = List.rev (c::acc) |> fun chars -> String.Join("",chars)
            loop newPolymer 1 newPolymer.[0] [] 0
        | c when i >= polymer.Length -> c::acc |> List.rev
        | c when react c polymer.[i] ->
            let j = if i + 1 = polymer.Length then i else i + 1
            loop polymer (i + 2) polymer.[j] acc (count + 1)
        | c -> loop polymer (i + 1) polymer.[i] (c::acc) count
    loop rawPolymer 1 rawPolymer.[0] [] 0

"dabAcCaCBAcCcaDA"
|> calculateReactions
|> fun chars -> System.String.Join("", chars)
|> fun actual ->
    let expected = "dabCBAcaDA"
    if actual = expected
    then printfn "Good implementation %s" actual
    else failwithf "Bad implementation %s" actual

let treatData data =
    data
    |> calculateReactions
    |> fun chars -> System.String.Join("", chars)
    |> fun s -> s.Length

treatData "dabAcCaCBAcCcaDA"
treatData input.[0]

open System.Text.RegularExpressions

let replaceIgnoreCase (newValue : string) (oldValuie:string) (s:string) =
    Regex.Replace(s, oldValuie, newValue, RegexOptions.IgnoreCase)

let removeIgnoreCase (oldValuie:string) (s:string) = replaceIgnoreCase "" oldValuie s

let reactUnits unit rawPolymer = replaceIgnoreCase unit rawPolymer

let fullyReactPolymer rawPolymer =
    let keepShortetsPolymer (unitA, shortest) (unitB, candidatelength) =
        if shortest <= candidatelength 
        then (unitA, shortest)
        else (unitB, candidatelength)

    let rec loop i (units : string) (acc : char * int) =
        if i = units.Length
        then acc
        else
            let fullyReactedPolymerLength =
                rawPolymer
                |> removeIgnoreCase (units.[i].ToString())
                |> treatData
            
            keepShortetsPolymer acc (units.[i], fullyReactedPolymerLength)
            |> loop (i + 1) units
    loop 0 "abcdefghijklmnopqrstuvwxyz" ('+', Int32.MaxValue)

fullyReactPolymer input.[0]
