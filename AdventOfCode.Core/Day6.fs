namespace AdventOfCode.Core

module Day6 =

    let calculate part input =

        let mergeAnswers set1 set2 = 
            match part with
            | 1 -> Set.union set1 set2
            | 2 -> Set.intersect set1 set2
            | _ -> invalidArg (nameof part) "Invalid part. Should be 1 or 2"

        let parse =
            let rec parse' groups current remaining =
                match remaining with
                | [] -> current :: groups 
                | hd :: tl ->
                    match hd with
                    | "" -> parse' (current :: groups) None tl
                    | person -> 
                        let current' = 
                            match current with
                            | Some c -> person |> Set.ofSeq |> mergeAnswers c
                            | None -> Set.ofSeq person
                        parse' groups (Option.Some current') tl
            parse' [] None input

        parse |> Seq.sumBy (Option.get >> Set.count)
