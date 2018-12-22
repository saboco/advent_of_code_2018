//************ Part I **********************
let ids = List.ofArray (System.IO.File.ReadAllLines("./inputs/input02.txt"))

let checksum (ids : string list) =
    let count (s:string) =
        let folder state _ value =
            let addTwo (two, three) = if two = 0 then (1, three) else (two,three)
            let addThree (two, three) = if three = 0 then (two, 1) else (two, three)
            match value with
            | 2 -> addTwo state
            | 3 -> addThree state
            | _ -> failwith "something went worng"
        
        let count (map : Map<char,int>) c = 
            if map.ContainsKey c then
                let count = map.[c]
                map.Remove(c)
                |> fun map -> map.Add(c, count + 1)
            else map.Add(c, 1)
        
        s.ToCharArray()
        |> Array.fold count Map.empty
        |> Map.filter (fun _ -> fun i -> i = 2 || i = 3)
        |> Map.fold folder (0,0)

    let folder state (item : string) =
        count item :: state
    ids 
    |> List.fold folder []
    |> List.reduce (fun (two, three) (twos, threes) -> (twos + two, threes + three))
    |> (fun (two, three) -> two * three)

let test expected data =
    let actual = checksum data
    if actual = expected
    then printfn "God checksum: %i" actual
    else failwithf "Bad checksum: %i" actual

test 12 ["abcdef"; "bababc"; "abbcde"; "abcccd"; "aabcdd"; "abcdee"; "ababab"]

printfn "Checksum: %i" (checksum ids)

//************ Part II **********************

let getBoxes (data : string list) =
    let compare (fixedId : char []) (currentId : char []) =
        let rec loop (count : int) (acc : char list) (fixedId : char list) (currentId : char list) =
            let result chars = List.rev chars |> (fun (c : char list) -> System.String.Join("",c))
            match fixedId, currentId with
            | [], [] -> (count = 1, result acc)
            | h1::t1, h2::t2 when h1 = h2 -> loop count (h1 :: acc) t1 t2
            | h1::t1, h2::t2 when h1 <> h2 && count < 1-> loop (count + 1) acc t1 t2
            | h1::_, h2::_ when h1 <> h2 -> (false, "invalid id")
            | _ -> failwith "unexpected match"
        loop 0 [] (List.ofArray fixedId) (List.ofArray currentId)

    let treat l =
        let rec loop1 l =
            let (fixedId : string) = List.head l
            let rec loop2 (l' : string list) =
                match l' with
                | [] -> loop1 (List.tail l)
                | h::t ->
                    match compare (fixedId.ToCharArray()) (h.ToCharArray()) with
                    | (true, id) -> id
                    | _ -> loop2 t
            loop2 l
        loop1 l
    
    treat data    

let test2 expected data =
    let actual = getBoxes data
    if actual = expected
    then printfn "God id %s" actual
    else failwithf "Bad id %s" actual

test2 "srijayzloguvowcqqmphenbkd" ["crruafyzloguvxwctqmphenbkd";"srijabyzloguvowcqqmphenbkd";"srirtfyzlognvxwctqmphenbkd";"srijafyzloguvowcqqmphenbkd"]

#time
printfn "Boxes id are: %s" (getBoxes ids)
#time