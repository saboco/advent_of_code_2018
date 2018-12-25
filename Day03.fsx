let input = List.ofArray (System.IO.File.ReadAllLines("./inputs/input03.txt"))

type ClaimInfo = {
    Id : string
    Origin : int * int
    Size : int * int }

[<Struct>]
type Claim = {
    NorthEast : int * int
    SouthEast : int * int
    NorthWest : int * int
    SouthWest : int * int }

type FabricState = {
    OverlapedInches : int
    OverlapedIds : Map<string,sbyte>
    NotYetOverlapedIds : Map<string, sbyte>
    Claims : Map<Claim, string> }
    with static member Empty = 
            { OverlapedInches = 0; Claims = Map.empty; OverlapedIds = Map.empty; NotYetOverlapedIds = Map.empty }

type Position = {
    Origin : int * int
    Offset : int * int }

let sliceFabric (data : string list) =
    let parseLine (l : string) =
        let arrayToPair (p :string []) : int * int =
            (System.Int32.Parse(p.[0].Trim()), System.Int32.Parse(p.[1].Trim()))
        let significantPart = l.Split('@')
        let id = significantPart.[0].Trim()
        let parts = significantPart.[1].Trim().Split(' ')
        let point = parts.[0].Trim().Replace(":","").Split(',') |> arrayToPair
        let size = parts.[1].Trim().Split('x') |> arrayToPair
        { Id = id;  Origin = point; Size = size}

    let treat data =
        let folder state line =
            let claim = parseLine line
            let addOverlap currentId overlapedId (state : FabricState) =
                let notYetOverlapedIds =
                    if state.NotYetOverlapedIds.ContainsKey currentId
                    then state.NotYetOverlapedIds.Remove currentId
                    else state.NotYetOverlapedIds

                let notYetOverlapedIds =
                    if notYetOverlapedIds.ContainsKey overlapedId 
                    then notYetOverlapedIds.Remove overlapedId
                    else notYetOverlapedIds

                let overlapedIds = state.OverlapedIds.Add (currentId,1y) |> fun map -> map.Add(overlapedId, 1y)

                { state with NotYetOverlapedIds = notYetOverlapedIds; OverlapedIds = overlapedIds }

            let addNotOverlapedId id state =
                if not (state.OverlapedIds.ContainsKey id) 
                then state.NotYetOverlapedIds.Add(id,1y)
                else state.NotYetOverlapedIds
                
            let addClaim currentId state { Origin=origin; Offset=offset } =
                let (a,b) = origin
                let (x,y) = offset
                let claim = {
                    NorthEast = a + x, b + y
                    NorthWest = a + x - 1, b + y
                    SouthEast = a + x, b + y - 1
                    SouthWest = a + x - 1, b + y - 1}
                
                if state.Claims.ContainsKey claim then
                    let overlapedId = state.Claims.[claim]
                    let addOverlapWithIds = addOverlap currentId overlapedId
                    if overlapedId = "&"
                    then
                        state |> addOverlapWithIds
                    else
                        state |> addOverlapWithIds
                        |> fun state -> { state with Claims = state.Claims.Remove(claim) }
                        |> fun state -> { state with OverlapedInches = state.OverlapedInches + 1; Claims = state.Claims.Add(claim, "&")}

                else
                    {state with Claims = state.Claims.Add (claim, currentId); NotYetOverlapedIds = addNotOverlapedId currentId state }

            let moveHorizontally {Origin= origin; Offset=(x,_)} = let (_, y') = claim.Size in {Origin= origin; Offset=(x - 1, y')}
            let moveVertically {Origin= origin; Offset=(x,y)} = {Origin= origin; Offset=(x, y - 1)}

            let rec loop state ({Origin= _; Offset=offset} as p: Position) =
                match offset with
                | (1,1) -> addClaim claim.Id state p
                | (_,1) -> loop (addClaim claim.Id state p) (moveHorizontally p)
                | _ -> loop (addClaim claim.Id state p) (moveVertically p)
            loop state {Origin = claim.Origin; Offset = claim.Size}
            

        List.fold folder FabricState.Empty data


    treat data

//  ["#123 @ 3,2: 5x4"] 
sliceFabric ["#1 @ 1,3: 4x4";"#2 @ 3,1: 4x4";"#3 @ 5,5: 2x2"] 
|> fun {OverlapedInches = count; Claims= _; NotYetOverlapedIds = notyetoverlapedIds } -> 
     if count = 4 
     then printfn "Good implemetantion count: %i %A" count notyetoverlapedIds
     else failwithf "Bad implementation count: %i %A" count notyetoverlapedIds

#time

sliceFabric input
|> fun {OverlapedInches = count; Claims= _; NotYetOverlapedIds = overlapedIds } -> printfn "How many square inches of fabric are within two or more claims? %i %A" count overlapedIds

#time