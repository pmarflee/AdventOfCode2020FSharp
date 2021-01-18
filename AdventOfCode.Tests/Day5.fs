namespace AdventOfCode.Tests

module Day5 =
    
    open Xunit
    open FsUnit.Xunit
    open AdventOfCode.Core.Day5

    type Tests ()=

        [<Theory>]
        [<InlineData("FBFBBFFRLR", 357)>]
        [<InlineData("BFFFBBFRRR", 567)>]
        [<InlineData("FFFBBBFRRR", 119)>]
        [<InlineData("BBFFBBFRLL", 820)>]
        member _.``Day 5 Calculate Seat ID`` (input : string, expected : int) =
            seatID input |> should equal expected

        [<Fact>]
        member _.``Day 5 Part 1`` () =
            calculate 1 ["FBFBBFFRLR"; "BFFFBBFRRR"; "FFFBBBFRRR"; "BBFFBBFRLL"] |> should equal 820
