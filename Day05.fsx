open System

let input = System.IO.File.ReadAllLines("./inputs/input05.txt")

let react (unitA : char) (unitB : char) =
    unitA <> unitB && 
    Char.ToLower(unitA) = Char.ToLower(unitB)

let calculateRactions (rawPolymer : string) =
    let rec loop (polymer : string) i (previousUnit : char) (acc : char list) count =
        match previousUnit with
        | c when i = polymer.Length && count > 0 ->
            let newPolymer = List.rev (c::acc) |> fun chars -> String.Join("",chars)
            loop newPolymer 1 newPolymer.[0] [] 0
        | c when i = polymer.Length -> c::acc |> List.rev
        | c when react c polymer.[i] -> 
            loop polymer (i + 2) polymer.[i + 1] acc (count + 1)
        | c -> loop polymer (i + 1) polymer.[i] (c::acc) count
    loop rawPolymer 1 rawPolymer.[0] [] 0

"dabAcCaCBAcCcaDA"
|> calculateRactions
|> fun chars -> System.String.Join("", chars)
|> fun actual ->
    let expected = "dabCBAcaDA"
    if actual = expected
    then printfn "Good implementation %s" actual
    else failwithf "Bad implementation %s" actual

let treatData data =
    data
    |> calculateRactions
    |> fun chars -> System.String.Join("", chars)
    |> fun s -> s.Length

treatData "dabAcCaCBAcCcaDA"
treatData input.[0]