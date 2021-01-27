namespace AdventOfCode.Core

module Day7 =

    open Farkle
    open Farkle.Builder
    open Farkle.Builder.Regex

    type BagColour =
        | LightRed
        | DarkOrange
        | BrightWhite
        | MutedYellow
        | ShinyGold
        | DarkOlive
        | VibrantPlum
        | FadedBlue
        | DottedBlack

    type Content = { Type : BagColour; Units : int }

    type Line = { Type : BagColour; Contents : Content list }

    type Lines = Lines of Line list

    type Day7Parser () =

        static let number = Terminals.genericUnsigned<int> "UnsignedNumber"

        static let colour =
            [
                "light", "red", LightRed
                "dark", "orange", DarkOrange
                "bright", "white", BrightWhite
                "muted", "yellow", MutedYellow
                "shiny", "gold", ShinyGold
                "dark", "olive", DarkOlive
                "vibrant", "plum", VibrantPlum
                "faded", "blue", FadedBlue
                "dotted", "black", DottedBlack
            ]
            |> List.map (fun (style, name, x) -> !& style .>> name =% x)
            |> (||=) "BagColour"

        static let bagWord = regexString "bag(s)?" |> terminalU "BagWord"

        static let fullStop = literal "."

        static let bagType = "BagType" ||= [
            !@ colour .>> bagWord => id
        ]

        static let contentItem = "ContentItem" ||= [
            !@ number .>>. bagType => (fun n t -> { Type = t; Units = n })
        ]

        static let contents =  sepBy1 (literal ",") contentItem

        static let line = "Line" ||= [
            !@ bagType .>> "contain" .>>. contents .>> "."
            => (fun t c -> { Type = t; Contents = c })
            !@ bagType .>> "contain" .>> "no" .>> "other" |> id .>> bagWord .>> fullStop
            => (fun t -> { Type = t; Contents = [] })
        ]

        static let lines = "Lines" ||= [
            !@ (many1 line) => Lines
        ]

        static let linesParser = RuntimeFarkle.build lines

        static let bagTypeParser = RuntimeFarkle.build bagType

        static let lineParser = RuntimeFarkle.build line

        static let contentItemParser = RuntimeFarkle.build contentItem

        static let contentsParser = RuntimeFarkle.build contents

        static member private parse input parser =
            match RuntimeFarkle.parseString parser input with
            | Ok result -> result
            | Error err -> failwith (err.ToString())

        static member parseLines input = Day7Parser.parse input linesParser

        static member parseBagType input = Day7Parser.parse input bagTypeParser

        static member parseContentItem input = Day7Parser.parse input contentItemParser

        static member parseContents input = Day7Parser.parse input contentsParser

        static member parseLine input = Day7Parser.parse input lineParser
