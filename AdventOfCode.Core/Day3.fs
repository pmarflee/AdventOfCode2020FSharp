namespace AdventOfCode.Core

module Day3 =

    type Tile = None = 0 | Tree = 1

    type Position = { X : int; Y : int; } with
        member this.Next(length : int) = { X = (this.X + 3) % length; Y = this.Y + 1 }

    type State = {
        Map : Tile [] [];
        Position : Position;
        Trees : int
    } with
      member private this.NextPosition = this.Position.Next
      member private this.HasTreeAtPosition(position : Position) =
        this.Map.[position.Y].[position.X] = Tile.Tree
      member this.Next =
        let newPosition = this.NextPosition this.Map.[0].Length
        let hasReachedEndOfMap = newPosition.Y >= this.Map.Length
        let newState = 
            if hasReachedEndOfMap then this
            else
                let newTrees = 
                    if this.HasTreeAtPosition(newPosition) 
                    then this.Trees + 1 
                    else this.Trees
                { this with Position = newPosition; Trees = newTrees }
        newState, hasReachedEndOfMap 

    let parse input =
        let mapTile = function
        | '.' -> Tile.None
        | '#' -> Tile.Tree
        | _ -> invalidArg "char" "Invalid character. Expected '.' or '#'."

        let mapTileLine line = line |> Seq.map mapTile |> Seq.toArray

        Array.map mapTileLine input

    let calculate part input =
        let rec calculate' (state : State) =
            let newState, hasReachedEndOfMap = state.Next
            if hasReachedEndOfMap then newState else calculate' newState
        let result = calculate' { Map = parse input; Position = { X = 0; Y = 0; }; Trees = 0; }
        result.Trees
