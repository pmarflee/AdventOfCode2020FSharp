namespace AdventOfCode.Tests
    module Day1 =
        
        open Xunit
        open FsUnit.Xunit
        open AdventOfCode.Core

        type Tests ()=

            static member Data with get() = [ 1721; 979; 366; 299; 675; 1456 ]

            [<Fact>] 
            member _.``Day 1 Part 1`` () = Day1.calculate 1 Tests.Data |> should equal 514579 

            [<Fact>]
            member _.``Day 1 Part 2`` () = Day1.calculate 2 Tests.Data |> should equal 241861950 
