namespace AdventOfCode.Tests

module Day2 =
    
    open Xunit
    open FsUnit.Xunit
    open AdventOfCode.Core.Day2

    type Tests ()=

        static member ParseData
            with get() = [ [| "1-3 a: abcde" :> obj;
                              { Policy = { From = 1; To = 3; Letter = 'a' }; Password = "abcde" } :> obj;
                              true :> obj; |];
                           [| "1-3 b: cdefg" :> obj;
                              { Policy = { From = 1; To = 3; Letter = 'b' }; Password = "cdefg" } :> obj;
                              false :> obj; |];
                           [| "2-9 c: ccccccccc" :> obj;
                              { Policy = { From = 2; To = 9; Letter = 'c' }; Password = "ccccccccc" } :> obj;
                              true :> obj; |];
            ]

        static member Part1Data
            with get() = [ [| [ "1-3 a: abcde"; "1-3 b: cdefg"; "2-9 c: ccccccccc" ] :> obj; 2 :> obj; |] ]

        [<Theory>] 
        [<MemberData(nameof Tests.ParseData)>]
        member _.``Day 2 Parse Password Line`` (input: string, expected: PasswordLine, _) = 
            parseLine input |> should equal expected

        [<Theory>] 
        [<MemberData(nameof Tests.ParseData)>]
        member _.``Day 2 Is Password Valid`` (input: string, _, expected: bool) = 
            (parseLine input).IsValid |> should equal expected

        [<Theory>] 
        [<MemberData(nameof Tests.Part1Data)>]
        member _.``Day 2 Calculate Part 1`` (input: string list, expected: int) = 
            calculate input |> should equal expected
