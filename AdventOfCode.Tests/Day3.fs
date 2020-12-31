namespace AdventOfCode.Core

module Day3 =

    open Xunit
    open FsUnit.Xunit
    open AdventOfCode.Core.Day3

    type Tests ()=

        static member Input = [|
            "..##.......";
            "#...#...#..";
            ".#....#..#.";
            "..#.#...#.#";
            ".#...##..#.";
            "..#.##.....";
            ".#.#.#....#";
            ".#........#";
            "#.##...#...";
            "#...##....#";
            ".#..#...#.#"
        |]

        static member Map = [| 
            [| Tile.None; Tile.None; Tile.Tree; Tile.Tree; Tile.None; Tile.None; Tile.None; Tile.None; Tile.None; Tile.None; Tile.None|];
            [|Tile.Tree; Tile.None; Tile.None; Tile.None; Tile.Tree; Tile.None; Tile.None; Tile.None; Tile.Tree; Tile.None; Tile.None|];
            [|Tile.None; Tile.Tree; Tile.None; Tile.None; Tile.None; Tile.None; Tile.Tree; Tile.None; Tile.None; Tile.Tree; Tile.None|];
            [|Tile.None; Tile.None; Tile.Tree; Tile.None; Tile.Tree; Tile.None; Tile.None; Tile.None; Tile.Tree; Tile.None; Tile.Tree|];
            [|Tile.None; Tile.Tree; Tile.None; Tile.None; Tile.None; Tile.Tree; Tile.Tree; Tile.None; Tile.None; Tile.Tree; Tile.None|];
            [|Tile.None; Tile.None; Tile.Tree; Tile.None; Tile.Tree; Tile.Tree; Tile.None; Tile.None; Tile.None; Tile.None; Tile.None|];
            [|Tile.None; Tile.Tree; Tile.None; Tile.Tree; Tile.None; Tile.Tree; Tile.None; Tile.None; Tile.None; Tile.None; Tile.Tree|];
            [|Tile.None; Tile.Tree; Tile.None; Tile.None; Tile.None; Tile.None; Tile.None; Tile.None; Tile.None; Tile.None; Tile.Tree|];
            [|Tile.Tree; Tile.None; Tile.Tree; Tile.Tree; Tile.None; Tile.None; Tile.None; Tile.Tree; Tile.None; Tile.None; Tile.None|];
            [|Tile.Tree; Tile.None; Tile.None; Tile.None; Tile.Tree; Tile.Tree; Tile.None; Tile.None; Tile.None; Tile.None; Tile.Tree|];
            [|Tile.None; Tile.Tree; Tile.None; Tile.None; Tile.Tree; Tile.None; Tile.None; Tile.None; Tile.Tree; Tile.None; Tile.Tree|]
        |]

        [<Theory>]
        [<InlineData(1, 7)>]
        [<InlineData(2, 336)>]
        member _.``Day 3 Calculation Tests`` (part : int, expected : int) =
            calculate part Tests.Input |> should equal expected
