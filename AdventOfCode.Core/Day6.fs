namespace AdventOfCode.Core

module Day6 =

    let calculate part input =
        let parse =
            let rec parse' groups current remaining =
                match remaining with
                | [] -> current :: groups 
                | hd :: tl ->
                    match hd with
                    | "" -> parse' (current :: groups) Set.empty tl
                    | person -> 
                        let current' = person |> Set.ofSeq |> Set.union current
                        parse' groups current' tl
            parse' [] Set.empty input
        parse |> Seq.sumBy Set.count
