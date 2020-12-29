namespace AdventOfCode.Tests

module Day2 =
    
    open Xunit
    open FsUnit.Xunit
    open AdventOfCode.Core.Day2

    type Tests ()=

        static member ParseData
            with get() = [ [| "1-3 a: abcde" :> obj;
                              { Policy = { First = 1; Second = 3; Letter = 'a' }; Password = "abcde" } :> obj;
                              true :> obj;
                              true :> obj;|];
                           [| "1-3 b: cdefg" :> obj;
                              { Policy = { First = 1; Second = 3; Letter = 'b' }; Password = "cdefg" } :> obj;
                              false :> obj;
                              false :> obj;|];
                           [| "2-9 c: ccccccccc" :> obj;
                              { Policy = { First = 2; Second = 9; Letter = 'c' }; Password = "ccccccccc" } :> obj;
                              true :> obj;
                              false :> obj;|];
            ]

        static member PartData
            with get() = [ [| [ "1-3 a: abcde"; "1-3 b: cdefg"; "2-9 c: ccccccccc" ] :> obj; 2 :> obj; 1 :> obj; |] ]

        [<Theory>] 
        [<MemberData(nameof Tests.ParseData)>]
        member _.``Day 2 Parse Password Line`` (input: string, expected: PasswordLine, _, _) = 
            parseLine input |> should equal expected

        [<Theory>] 
        [<MemberData(nameof Tests.ParseData)>]
        member _.``Day 2 Is Password Valid (Part 1)`` (input: string, _, expected: bool, _) = 
            (parseLine input).IsValid 1 |> should equal expected

        [<Theory>] 
        [<MemberData(nameof Tests.ParseData)>]
        member _.``Day 2 Is Password Valid (Part 2)`` (input: string, _, _, expected: bool) = 
            (parseLine input).IsValid 2 |> should equal expected

        [<Theory>] 
        [<MemberData(nameof Tests.PartData)>]
        member _.``Day 2 Calculate Part 1`` (input: string list, expected: int, _) = 
            calculate 1 input |> should equal expected

        [<Theory>] 
        [<MemberData(nameof Tests.PartData)>]
        member _.``Day 2 Calculate Part 2`` (input: string list, _, expected: int) = 
            calculate 2 input |> should equal expected
