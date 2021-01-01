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
        [<InlineData(1, 7L)>]
        [<InlineData(2, 336L)>]
        member _.``Day 3 Calculation Tests`` (part : int, expected : int64) =
            calculate part Tests.Input |> should equal expected
