#r "paket: 
source https://api.nuget.org/v3/index.json
nuget FSharpx.Extras"

#load ".fake/04 Reponse Record.fsx/intellisense.fsx"

open System
open FSharpx.Collections

let equalsOn f x (yobj : obj) =
    match yobj with
    | :? 'T as y -> (f x = f y)
    | _ -> false

let hashOn f x = hash (f x)

let compareOn f x (yobj : obj) =
    match yobj with
    | :? 'T as y -> compare (f x) (f y)
    | _ ->  invalidArg "yobj" "cannont compare values of different types"

type GuardId = GuardId of int

[<CustomEquality;CustomComparison>]
type GuardActivity =
    | BeginsShift of DateTime * GuardId
    | FallsAsleep of DateTime
    | WakesUp of DateTime
    member private __.selectSignificantValue activity = 
        match activity with
        | BeginsShift (time,_) -> time
        | FallsAsleep time -> time
        | WakesUp time -> time
    override x.Equals(yobj) =
        match yobj with
        | :? GuardActivity as y -> equalsOn id x y
        | _ -> false
    override x.GetHashCode() = hashOn id x
    interface System.IComparable with
        member x.CompareTo yobj =
            match yobj with
            | :? GuardActivity as y -> compareOn x.selectSignificantValue x y
            | _ -> invalidArg "yobj" "cannot compare value of different types"

type MaxAsleepTime = GuardId * int

let example =
    [
    "[1518-11-01 00:00] Guard #10 begins shift"
    "[1518-11-01 00:05] falls asleep"
    "[1518-11-01 00:25] wakes up"
    "[1518-11-01 00:30] falls asleep"
    "[1518-11-01 00:55] wakes up"
    "[1518-11-01 23:58] Guard #99 begins shift"
    "[1518-11-02 00:40] falls asleep"
    "[1518-11-02 00:50] wakes up"
    "[1518-11-03 00:05] Guard #10 begins shift"
    "[1518-11-03 00:24] falls asleep"
    "[1518-11-03 00:29] wakes up"
    "[1518-11-04 00:02] Guard #99 begins shift"
    "[1518-11-04 00:36] falls asleep"
    "[1518-11-04 00:46] wakes up"
    "[1518-11-05 00:03] Guard #99 begins shift"
    "[1518-11-05 00:45] falls asleep"
    "[1518-11-05 00:55] wakes up"]

open System.Text.RegularExpressions

let (|ExtractGuardId|_|) input =
   let m = Regex.Match(input,"Guard #(\d+) begins shift")
   if (m.Success) 
   then Some (GuardId (m.Groups.[1].Value |> Int32.Parse))
   else None

let addGuardActivity (state : IPriorityQueue<GuardActivity>) (log : string) =
    let parts = log.Replace("[","").Split(']')
    let time = parts.[0].Trim() |> System.DateTime.Parse
    let activity =
        match parts.[1].Trim() with
        | ExtractGuardId guardId -> BeginsShift (time, guardId)
        | "falls asleep" -> FallsAsleep time
        | "wakes up" -> WakesUp time
        | _ as s -> failwithf "wrong activity %s" s
    state.Insert activity

let parseActivities logs = List.fold addGuardActivity (PriorityQueue.empty false) logs

type AsleepInfo = {
    Total : int
    Periods : (int * int) list }

let aggregateGuardActivity activities =
    let maxAsleep (currentMaxGuard, currentMaxTime) (guardId, asleepTime) : MaxAsleepTime =
        if currentMaxTime > asleepTime
        then  (currentMaxGuard, currentMaxTime)
        else  (guardId, asleepTime)
    let addSleepingTime 
        (currentMax : MaxAsleepTime, acc : Map<GuardId, AsleepInfo>)
        guardId 
        (fallsAsleep : DateTime)
        wakesup 
        =
        let newAsleepTime = { Total = (wakesup - fallsAsleep).TotalMinutes |> int; Periods = [ (fallsAsleep.Minute, wakesup.Minute) ] }
        let previousAsleepTime = if acc.ContainsKey guardId then acc.[guardId] else { Total = 0; Periods = [] }
        let totalAsleepTime =
            {   Total = previousAsleepTime.Total + newAsleepTime.Total
                Periods = previousAsleepTime.Periods@newAsleepTime.Periods }
        let preparedMap = if acc.ContainsKey guardId then acc.Remove(guardId) else acc
        maxAsleep currentMax (guardId, totalAsleepTime.Total), preparedMap.Add (guardId, totalAsleepTime)

    let rec loop currentGuardId (fallsAsleepTime : DateTime option) acc (remainingActivities : IPriorityQueue<GuardActivity>) =
        if remainingActivities.IsEmpty then
            acc
        else
            let activity, rest = remainingActivities.Pop ()
            match activity with
            | BeginsShift (_, guardId) -> loop guardId None acc rest
            | FallsAsleep time -> loop currentGuardId (Some time) acc rest
            | WakesUp time when Option.isSome fallsAsleepTime -> 
                let fallsAsleep = Option.defaultWith (fun () -> failwith "wrong activities") fallsAsleepTime 
                loop currentGuardId None (addSleepingTime acc currentGuardId fallsAsleep time) rest
            | _ as activity -> failwithf "WrongActivity %A, currentGardId %A" activity currentGuardId

    loop (GuardId -1) None ((GuardId -1, -1), Map.empty) activities

type CurrentMax = {
    Minute : int
    Count : int }

let mostProbablyAsleepMinute (asleepInfo : AsleepInfo) =
    let maxSleepingMinute (currentMax : CurrentMax) minute (acc: Map<int,int>) =
        let calculateCurrentMax count =
            if currentMax.Count >= count
            then currentMax
            else { Minute = minute; Count = count }
        if acc.ContainsKey minute
        then
            let count = acc.[minute] + 1
            let newAcc = acc.Remove minute
            calculateCurrentMax count, newAcc.Add (minute, count)
        else
            calculateCurrentMax 1, acc.Add (minute, 1)
    let folder state (starts, ends) =
        let rec loop i ((currentMax : CurrentMax, map : Map<int,int>) as acc) =
            if i = ends then acc
            else loop (i + 1) (maxSleepingMinute currentMax i map)
        loop starts state

    List.fold folder ({Minute= -1; Count = -1}, Map.empty) asleepInfo.Periods

let getAnswer data =
    data
    |> parseActivities
    |> aggregateGuardActivity
    |> fun ((GuardId guardId, _), all) ->
        mostProbablyAsleepMinute all.[GuardId guardId]
        |> fun ({ Minute = minute; Count = _ }, _) -> 
            printfn "most probably the guard %i is sleeping in the minute %i. Answer is %i" guardId minute (guardId*minute)

let input = List.ofArray (System.IO.File.ReadAllLines "./inputs/input04.txt")
getAnswer input

type CurrentMaxByGuard = {
    GuardId : GuardId
    Minute : int
    Count : int }

let mostProbablyAsleepMinuteByGuard (asleepInfoByGuard : Map<GuardId, AsleepInfo>) =

    let folder (state : CurrentMaxByGuard) guardId (asleepInfo : AsleepInfo) =
        let (maxOfCurrentGuard, _) = mostProbablyAsleepMinute asleepInfo
        if state.Count >= maxOfCurrentGuard.Count
        then state
        else { GuardId = guardId; Minute = maxOfCurrentGuard.Minute; Count = maxOfCurrentGuard.Count }

    Map.fold folder { GuardId= GuardId -1; Minute= -1;Count= -1} asleepInfoByGuard

let getAnswer2 data =
    data
    |> parseActivities
    |> aggregateGuardActivity
    |> fun (_, all) ->
        mostProbablyAsleepMinuteByGuard all
        |> fun { GuardId = (GuardId guardId); Minute = minute; Count = _ } -> 
            printfn "most probably the guard %i is sleeping in the minute %i. Answer is %i" guardId minute (guardId*minute)

getAnswer2 example
getAnswer2 input