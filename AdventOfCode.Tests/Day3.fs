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

        [<Fact>]
        member _.``Day 3 Part 1 Calculate Should Produce Result Of 7`` () =
            calculate 1 Tests.Input |> should equal 7
