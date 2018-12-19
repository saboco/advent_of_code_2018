let input = List.ofArray (System.IO.File.ReadAllLines("./inputs/input03.txt"))

type ClaimInfo = {
    Origin : int * int
    Size : int * int
}

[<Struct>]
type Claim = {
    NorthEast : int * int
    SouthEast : int * int
    NorthWest : int * int   
    SouthWest : int * int }

type FabricState = {
    OverlapedInches : int
    Claims : Map<Claim, string> }
    with static member Empty = { OverlapedInches = 0; Claims = Map.empty }

type Position = {
    Origin : int * int
    Offset : int * int }


with static member Empty = { OverlapedInches = 0; Claims = Map.empty }

let sliceFabric (data : string list) =
    let parseLine (l : string) =
        let arrayToPair (p :string []) : int * int =
            (System.Int32.Parse(p.[0].Trim()), System.Int32.Parse(p.[1].Trim()))
        let significantPart = l.Substring(l.IndexOf('@') + 1).Trim()
        let parts = significantPart.Split(' ')
        let point = parts.[0].Trim().Replace(":","").Split(',') |> arrayToPair
        let size = parts.[1].Trim().Split('x') |> arrayToPair
        { Origin = point; Size = size}

    let treat data =
        let folder state line =
            let claim = parseLine line
            let addClaim {OverlapedInches = count; Claims= claims} {Origin= origin; Offset=offset} =
                let (a,b) = origin
                let (x,y) = offset
                let claim = {
                    NorthEast = a + x, b + y
                    NorthWest = a + x - 1, b + y
                    SouthEast = a + x, b + y - 1
                    SouthWest = a + x - 1, b + y - 1}

                if claims.ContainsKey claim then
                    if claims.[claim] = "&"
                    then
                        {OverlapedInches = count; Claims= claims} 
                    else
                        claims.Remove(claim)
                        |> fun map -> {OverlapedInches = count + 1; Claims = map.Add(claim, "&")}
                else {OverlapedInches = count; Claims = claims.Add (claim, "#")}

            let moveHorizontally {Origin= origin; Offset=(x,_)} = let (_, y') = claim.Size in {Origin= origin; Offset=(x - 1, y')}
            let moveVertically {Origin= origin; Offset=(x,y)} = {Origin= origin; Offset=(x, y - 1)}

            let rec loop state ({Origin= _; Offset=offset} as p: Position) =
                match offset with
                | (1,1) -> addClaim state p
                | (_,1) -> loop (addClaim state p) (moveHorizontally p)
                | _ -> loop (addClaim state p) (moveVertically p)
            loop state {Origin = claim.Origin; Offset = claim.Size}
            

        List.fold folder FabricState.Empty data

    treat data

//  ["#123 @ 3,2: 5x4"] 
sliceFabric ["#1 @ 1,3: 4x4";"#2 @ 3,1: 4x4";"#3 @ 5,5: 2x2"] 
// |> fun {OverlapedInches = _; Claims= claims} -> Map.iter (fun key v -> printfn "%A %A" key v) claims
|> fun {OverlapedInches = count; Claims= _} -> 
     if count = 4 
     then printfn "Good implemetantion count: %i" count
     else failwithf "Bad implementation count: %i" count

sliceFabric input
|> fun {OverlapedInches = count; Claims= _} -> printfn "How many square inches of fabric are within two or more claims? %i" count