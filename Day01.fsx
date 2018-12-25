// *********** Part I **********************
let input = List.ofArray (System.IO.File.ReadAllLines("./inputs/input01.txt")) |> List.map System.Int32.Parse

let computeFrequencyChanges current data =
    let rec loop acc l =
        match l with
        | [] -> acc
        | h::t -> loop (acc + h) t
    loop current data

computeFrequencyChanges 0 input

// *********** Part II **********************

let getFirtFrequencyReachedTwice current data =
    let original = data
    let rec loop acc (map : Map<int, sbyte>) l =
        match (map.ContainsKey acc), l with
        | true, _ -> acc
        | false, [] -> 
            let h = List.head original
            loop (acc + h) (map.Add(acc, 1y)) (List.tail original)
        | false, h::t -> loop (acc + h) (map.Add(acc, 1y)) t
    loop current (Map.empty) original

let test expected data = 
    let actual = getFirtFrequencyReachedTwice 0 data
    if expected = actual
    then printfn "Good answer: %i" actual
    else failwithf "Bad answer %i" actual

test 0 [+1; -1]
test 10 [+3; +3; +4; -2; -4]
test 5 [-6; +3; +8; +5; -6]
test 14 [+7; +7; -2; -7; -4]

#time
getFirtFrequencyReachedTwice 0 input
#time