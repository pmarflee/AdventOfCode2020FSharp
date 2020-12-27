namespace AdventOfCode.Tests
    module Day1 =
        
        open Xunit
        open FsUnit.Xunit
        open AdventOfCode.Core

        type Tests () =

            static member Part1Data
                with get() = [ [| [ 1721; 979; 366; 299; 675; 1456 ] :> obj; 514579 :> obj |] ]

            [<Theory>]
            [<MemberData(nameof Tests.Part1Data)>]
            member _verify.``Day 1 Part 1`` (input: int list, expected: int) =
                Day1.calculatePart1 input |> should equal expected 
