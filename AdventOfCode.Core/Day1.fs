namespace AdventOfCode.Core

module Day1 =

    let private sum = 2020

    let private tryFindPair numbers entries = 
        let other = sum - (List.sum entries)
        if Set.contains other numbers then Some(other :: entries) else None

    let private part1 numbers = Seq.map List.singleton numbers

    let private part2 numbers =
        numbers 
        |> Seq.allPairs numbers
        |> Seq.where (fun (a, b) -> a <> b)
        |> Seq.map (fun (a, b) -> [a; b])

    let calculate part numbers =
        let numbers' = Set.ofSeq numbers
        let partFunc = if part = 1 then part1 else part2 
        numbers' |> partFunc |> Seq.pick (tryFindPair numbers') |> List.reduce (*) 