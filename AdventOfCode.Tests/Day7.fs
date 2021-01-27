namespace AdventOfCode.Tests

module Day7 =
    
    open Xunit
    open FsUnit.Xunit
    open AdventOfCode.Core.Day7

    type ParserTests ()=

        [<Fact>]
        member _.``Day 7 Parse Bag Type`` () = 
            Day7Parser.parseBagType "light red bag" |> should equal LightRed
            Day7Parser.parseBagType "light red bags" |> should equal LightRed

        [<Fact>]
        member _.``Day 7 Parse Bag Content Item`` () = 
            Day7Parser.parseContentItem "1 bright white bag" |> should equal { Type = BrightWhite; Units = 1 }
            Day7Parser.parseContentItem "2 muted yellow bag" |> should equal { Type = MutedYellow; Units = 2 }

        [<Fact>]
        member _.``Day 7 Parse Bag Contents`` () = 
            Day7Parser.parseContents "1 bright white bag, 2 muted yellow bags" 
            |> should equal [ { Type = BrightWhite; Units = 1 }; { Type = MutedYellow; Units = 2 } ]

        [<Fact>]
        member _.``Day 7 Parse Line (bag with contents)`` () = 
            Day7Parser.parseLine "light red bags contain 1 bright white bag, 2 muted yellow bags." 
            |> should equal 
                { Type = LightRed; 
                  Contents = [ { Type = BrightWhite; Units = 1 }; { Type = MutedYellow; Units = 2 } ] }

        [<Fact>]
        member _.``Day 7 Parse Line (bag with no contents)`` () = 
            Day7Parser.parseLine "faded blue bags contain no other bags." 
            |> should equal { Type = FadedBlue; Contents = [] }
            Day7Parser.parseLine "dotted black bags contain no other bags." 
            |> should equal { Type = DottedBlack; Contents = [] }
