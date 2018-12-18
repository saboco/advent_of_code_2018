//************ Part I **********************
let ids = List.ofArray <| [|"crruafyzloguvxwctqmphenbkd";"srcjafyzlcguvrwctqmphenbkd";"srijafyzlogbpxwctgmphenbkd";"zrijafyzloguvxrctqmphendkd";"srijabyzloguvowcqqmphenbkd";"srijafyzsoguvxwctbmpienbkd";"srirtfyzlognvxwctqmphenbkd";"srijafyzloguvxwctgmphenbmq";"senjafyzloguvxectqmphenbkd";"srijafyeloguvxwwtqmphembkd";"srijafyzlogurxtctqmpkenbkd";"srijafyzlkguvxictqhphenbkd";"srijafgzlogunxwctqophenbkd";"shijabyzloguvxwctqmqhenbkd";"srjoafyzloguvxwctqmphenbwd";"srijafyhloguvxwmtqmphenkkd";"srijadyzlogwvxwctqmphenbed";"brijafyzloguvmwctqmphenhkd";"smijafyzlhguvxwctqmphjnbkd";"sriqafvzloguvxwctqmpheebkd";"srijafyzloguvxwisqmpuenbkd";"mrijakyuloguvxwctqmphenbkd";"srnfafyzloguvxwctqmphgnbkd";"srijadyzloguvxwhfqmphenbkd";"srijafhzloguvxwctdmlhenbkd";"srijafyzloguvxwcsqmphykbkd";"srijafyzlogwvxwatqmphhnbkd";"srijafyzlozqvxwctqmphenbku";"srijafyzloguvxwcbamphenbgd";"srijafyzlfguvxwctqmphzybkd";"srijafyzloguqxwetqmphenkkd";"srijafyylogubxwttqmphenbkd";"srijafyzloguvxzctadphenbkd";"srijafyzloguoxwhtqmchenbkd";"srijafyzloguvxwcvqmzhenbko";"srijnfyzloguvxwctqmchenjkd";"srijaryzloggvxwctqzphenbkd";"srijafhzleguvxwcxqmphenbkd";"ssijafyzllguvxfctqmphenbkd";"srijafyzloguvxdctqmfhenbcd";"srijafyzloguvxfctqmplynbkd";"srijaftzlogavxwcrqmphenbkd";"sriwaoyzloguvxwctqmphenbtd";"srijahyzlogunxwctqmphenbvd";"srjjafyzloguzxwctumphenbkd";"nrijafyzlxguvxwctqmphanbkd";"srijafezlqguyxwctqmphenbkd";"srijafygloguvxwjtqcphenbkd";"erijafyzloguvxoctqmnhenbkd";"ssijafyzllguvxwbtqmphenbkd";"sriaafyzloguvxwctqqphenbkv";"frijafyzloguvswctwmphenbkd";"srijafyzyogkvxwctqmprenbkd";"syijafyzuoguvxwctqmkhenbkd";"srijafyzloganxwctqmphenbkf";"srijafyzloguvxwftqmxhenbkq";"srijafyflogxvxwctqmghenbkd";"srijafyzsoguvxwctqmpjenwkd";"srujafylloguvxwctqmphenckd";"srijafyzlpzuvxwctqmphenbud";"srijafyzlogfvxwctqmhhenbwd";"srijafjzlogusxwctqmphepbkd";"srijlfyzloguvxwctqfphenzkd";"srijafyzlogwvxwctqyphenbqd";"srijafyzloluvxwctqtphenukd";"srizafyzlowuvxwctqmphqnbkd";"sritafkzlkguvxwctqmphenbkd";"sbijafdzloguvxgctqmphenbkd";"crijafyeloguvxwctqmpsenbkd";"srijafyvlogulxwctqmphenbkk";"srijafyologuvxwctqmehegbkd";"siijafyzloguvxwctjmphenbmd";"srijafyzlupuvxwctqmpheabkd";"srijafyzlogumxwctqqphanbkd";"srijxfyzlogujxwcqqmphenbkd";"irijafizeoguvxwctqmphenbkd";"sgijafyzloguvtwctqmpfenbkd";"srijzfyzloguvmwctnmphenbkd";"srijafyzwohuvxwctqmthenbkd";"srijafyzlhguvxoctqwphenbkd";"srgjafyplogxvxwctqmphenbkd";"srijafyqlogovxwctqzphenbkd";"srijafjzloguvlnvtqmphenbkd";"srijafyzooguvxwctqmphenvud";"srijafyzgoguvxwctumphgnbkd";"srijaffzloguvxwdqqmphenbkd";"srijafyzlogugxwctqxphenbkr";"srijafyzlogutxwctqmmcenbkd";"srifafyzlhguwxwctqmphenbkd";"mrimajyzloguvxwctqmphenbkd";"sriyafyzloguvxwcthmphejbkd";"srieakyzlokuvxwctqmphenbkd";"srisafyzloguhxwctqmphecbkd";"srijanyzloguvxcctqmxhenbkd";"srijafyzypguvxwctqmqhenbkd";"sryjtfyzlvguvxwctqmphenbkd";"srijafyzlsguvxwctqmqfenbkd";"srijafyzlogudxwbtqwphenbkd";"srijysyzloguvxwctqmpvenbkd";"srijafyzloggvxwjtqmphegbkd";"srijgfyzloguvxwctqmbhdnbkd";"ssijufyzloguvawctqmphenbkd";"skojafyzloguvxwctqmphenbnd";"srijafylloguvxwcqqmpienbkd";"trioafyzloguvqwctqmphenbkd";"srijafydloguvxwctqmpzjnbkd";"saijafvzloguvxwcqqmphenbkd";"srhjapyzloguvxwctqmbhenbkd";"srijafyzlfguvxwcsqmpwenbkd";"shijafyzboguvxwctqmphenbmd";"srizafysloguvxwrtqmphenbkd";"srijafyzloguvxwciqmwhenbkj";"qrijafyzloduvxwctqmphenbko";"srijefyuloguvxwctqmphenbed";"srijafyzlobuvxwctqmphenhbd";"srijafyzloxuvxwctqmpheabkq";"srijafyzloguvrwctqmghenkkd";"sfisafywloguvxwctqmphenbkd";"srgjafyzlogurxwctqmphenbkp";"srijafhzloguvxwcjqmphenhkd";"srijafyylogufxwrtqmphenbkd";"srijafyzvoguvxwzkqmphenbkd";"sqijafyzloguvxwctqmpheqbxd";"srijafyvloguvxwctqzpherbkd";"srijufyzloguvxlcsqmphenbkd";"srijafykloguvxlccqmphenbkd";"srijafyzloguexwcrqmphenzkd";"sridifyzloguyxwctqmphenbkd";"srijafyzlogfvxwctqlphenbkl";"srijafyzlodqdxwctqmphenbkd";"srijafyzloruvxactqmphenekd";"grijafyzloguvxpctmmphenbkd";"srsjakyzloguvxwctqmphvnbkd";"srikafyvloguvxwrtqmphenbkd";"srijafyzloguvxwctqjpserbkd";"jrijafyzloguvxwctqmpgesbkd";"swijafyzluguvxwctqmfhenbkd";"srijanynlogovxwctqmphenbkd";"jrijafyzloguvxwctymphrnbkd";"srinafyzloguvewctqmphenbzd";"srijakyzloguvxwctqmphcnbka";"srijafyhlobuvxwctqmphenbka";"srijafyzcogusxwctqmphwnbkd";"srijavyzlosuvxwctqmphjnbkd";"orijafyzxoguvxwcnqmphenbkd";"srijafyzlogcvxwvtqmthenbkd";"srijapyzloauvxwctqmphenvkd";"srijaflzloguhxwctqmphenbwd";"smijafyzlonuvxwctqmphenbkw";"jrijafyzloguvxwclqmnhenbkd";"srijaqyzloguvqwctqmphenskd";"srijasyzloguvxwctqmvhenbku";"crijtfyzloguvxwctqmthenbkd";"srrkafyzvoguvxwctqmphenbkd";"srijatyzloguvewctqmphenbld";"srfjafyyloguvnwctqmphenbkd";"srijafyzloguvxwctqjpbenbkt";"hrijafyzooguvxwctqmphenbld";"srijafbzlogscxwctqmphenbkd";"srinafyzlogxvxwctqqphenbkd";"slijafyzloglvxwctqmphenbdd";"srijafyzlogjvxwcsqmphenbld";"sryjcfyzloguvewctqmphenbkd";"srijafyzloguexwctqmohknbkd";"jaijafyzlogevxwctqmphenbkd";"srijafbzlogavxwctqmphenbki";"srijafozlogpvxwctqmphgnbkd";"srijdfyzloguvxwczqmphenbkm";"srijafyzlobuvxwctqmphxndkd";"mrijifyzlhguvxwctqmphenbkd";"srijafyzloguvxbctumphjnbkd";"srijafyzloyuvxwptqmphlnbkd";"arijafyzloguvxwcsqmohenbkd";"srijaftzioguvxwttqmphenbkd";"srijafyzlqsuvxwctqmphxnbkd";"srijafyzioguvxwctqnphetbkd";"prijafbzloguvxdctqmphenbkd";"srijaeyzlnguvxwmtqmphenbkd";"srijofyzloguvqwctqmphonbkd";"srixaryzpoguvxwctqmphenbkd";"srijafyzlowuvxwcwhmphenbkd";"srijafydloguvxwctqmptenikd";"srijqfyzlogtvfwctqmphenbkd";"srijafyzloguvxlctqmpvenbgd";"srijafyzlbguvxwjtqgphenbkd";"srijafyzlohuqxwctqmphenbka";"srijafyzroguvxictqmphynbkd";"srijafyzloguvxdctjmphenjkd";"srijaoczloguvxwctqmphenbjd";"srajafhzloguvxwctqmphenbke";"srijofyzloduvxwctqmphanbkd";"srijafytloguvxwmtnmphenbkd";"srijafyzuoguvxwceqmpgenbkd";"rrijafyzloyuvxwctqmphlnbkd";"srljafyzloguvxictqmohenbkd";"srijafyzlogulxwcrqrphenbkd";"srajafyzloguvxwctqmphanbke";"srijafyzlhguvxwxtqmpheabkd";"sxijafyzloggwxwctqmphenbkd";"srijafyultguvxwctqmphinbkd";"srijafyzloguvtwctqmfhvnbkd";"srijafwzloruvxwctquphenbkd";"srbjafyzxoguuxwctqmphenbkd";"erijafyzlxguvxbctqmphenbkd";"srijagyzlojubxwctqmphenbkd";"srijafyzloguvxwdtqmchenakd";"srijafkzlogukxwctqiphenbkd";"mridafyzloguvxwctqmphenrkd";"szqjafyzloguvxwctqmpheibkd";"srijahyzloguvxwctcmphenekd";"srijafyzloguvxwczpuphenbkd";"srijafyzcoguvfwctqmphenbkq";"qriiafyzloguvxwctqmpheebkd";"srijpfyzloguvxlctqmphenokd";"srijzfyzlotuvxwcjqmphenbkd";"srinafyqloguvxwctfmphenbkd";"srijafyzlogjvxpltqmphenbkd";"srijafyzlotuvxwutqmphenbtd";"sridafyzloguvxwctqmpyenokd";"srxjafyzqogyvxwctqmphenbkd";"ssijafyzzoguvxwctqmphenbad";"srijafrzloguvxwctqmphekpkd";"srijafyzlfgrvxactqmphenbkd";"srijafyzroguvxwttqmphekbkd";"srijefyzloguvxwctqmpqenbrd";"srijefycloguvxwctqmchenbkd";"srzjafyzloguvxwcqqmphanbkd";"srijauyzlhguvxwctqmphenbgd";"srijafyzloguvmwvnqmphenbkd";"srihafyzloguvlwotqmphenbkd";"srigafyzloguvxwctqmphennsd";"sriuafzzloguvxwcuqmphenbkd";"srijavuzllguvxwctqmphenbkd";"srijafjzloguvlnctqmphenbkd";"lrirafyzloguvxwctqmphenbld";"soijarxzloguvxwctqmphenbkd";"srijapyzlnguvxwctqmdhenbkd";"srijafyzkogujxmctqmphenbkd";"srijafuzloguvxwcsqvphenbkd";"srijagyzzoguvxwctqmpvenbkd";"srijafyzlovuvxwctqmrhenbxd";"srijafyzqoguvxwctwmpienbkd";"sxijafyzloguvxwutqmphenlkd";"srijafyzlhgzvxwctqmphqnbkd";"srijajyzloguvxwcbwmphenbkd";"srijazyzloguvxwhtqmphenbkx";"srgjafyzloguvvwctqmphdnbkd";"rrivafyzloguvxjctqmphenbkd";"srijifyzdoguvxwctqmphenbka";"hrijafyzloguvxectqmpheybkd";|]

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

printfn "Boxes id are: %s" (getBoxes ids)