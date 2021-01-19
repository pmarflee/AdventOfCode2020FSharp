namespace AdventOfCode.Tests

module Day6 =
    
    open Xunit
    open FsUnit.Xunit
    open AdventOfCode.Core.Parser
    open AdventOfCode.Core.Day6

    type Tests ()=

        static member Input
            with get() = 
                "abc\r\n\r\n\
                 a\r\n\
                 b\r\n\
                 c\r\n\r\n\
                 ab\r\n\
                 ac\r\n\r\n\
                 a\r\n\
                 a\r\n\
                 a\r\n\
                 a\r\n\r\n\
                 b" |> splitLines |> List.ofArray

        [<Fact>]
        member _.``Day 6 Part 1`` () = calculate 1 Tests.Input |> should equal 11

        [<Fact>]
        member _.``Day 6 Part 2`` () = calculate 2 Tests.Input |> should equal 6
