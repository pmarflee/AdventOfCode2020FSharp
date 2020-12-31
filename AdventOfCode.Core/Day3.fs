namespace AdventOfCode.Core

module Day3 =

    type Tile = None = 0 | Tree = 1

    type Direction = { Right : int; Down : int }

    type Position = { X : int; Y : int; } with
        member this.Next(direction : Direction, length : int) = 
            { X = (this.X + direction.Right) % length; Y = this.Y + direction.Down }

    type State = {
        Map : Tile [,];
        Direction : Direction;
        Position : Position;
        Trees : int64
    } with
      member private this.NextPosition = this.Position.Next
      member private this.HasTreeAtPosition(position : Position) =
        this.Map.[position.Y,position.X] = Tile.Tree
      member this.Next =
        let newPosition = this.NextPosition(this.Direction, this.Map.GetLength 1)
        let hasReachedEndOfMap = newPosition.Y >= this.Map.GetLength 0
        let newState = 
            if hasReachedEndOfMap then this
            else
                let newTrees = 
                    if this.HasTreeAtPosition(newPosition) 
                    then this.Trees + (int64 1)
                    else this.Trees
                { this with Position = newPosition; Trees = newTrees }
        newState, hasReachedEndOfMap 

    let private parse input =
        let mapTile = function
        | '.' -> Tile.None
        | '#' -> Tile.Tree
        | _ -> invalidArg "char" "Invalid character. Expected '.' or '#'."

        let mapTileLine line = line |> Seq.map mapTile |> Seq.toArray 
        input |> Array.map mapTileLine |> array2D

    let private calculate' map direction =
        let rec calculate'' (state : State) =
            let newState, hasReachedEndOfMap = state.Next
            if hasReachedEndOfMap then newState else calculate'' newState
        let state = { 
            Map = map; 
            Direction = direction;
            Position = { X = 0; Y = 0; }; 
            Trees = int64 0; 
        }
        (calculate'' state).Trees

    let private instructions = 
        [ 
           (1, [ { Right = 3; Down = 1 } ]);
           (2, [
                { Right = 1; Down = 1; };
                { Right = 3; Down = 1; };
                { Right = 5; Down = 1; };
                { Right = 7; Down = 1; };
                { Right = 1; Down = 2; };
           ]);
        ] |> Map.ofList

    let calculate part input = 
        let map = parse input
        instructions |> Map.find part |> List.map (calculate' map) |> List.reduce (*)
