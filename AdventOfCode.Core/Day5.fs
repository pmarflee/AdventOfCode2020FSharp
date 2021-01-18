namespace AdventOfCode.Core

module Day5 =

    type State = {
        RowFrom : int;
        RowTo : int;
        ColumnFrom : int;
        ColumnTo : int;
    }

    let seatID input =
        
        let rec folder state c =
            let range lower upper = (upper - lower + 1) / 2
            match c with
            | 'F' -> { state with RowTo = state.RowTo - (range state.RowFrom state.RowTo) }
            | 'B' -> { state with RowFrom = state.RowFrom + (range state.RowFrom state.RowTo) }
            | 'L' -> { state with ColumnTo = state.ColumnTo - (range state.ColumnFrom state.ColumnTo) }
            | 'R' -> { state with ColumnFrom = state.ColumnFrom + (range state.ColumnFrom state.ColumnTo) }
            | _ -> invalidArg (nameof c) "Invalid character. Should be one of the following: F, B, L, R"

        let finalState = input |> Seq.fold folder { RowFrom = 0; RowTo = 127; ColumnFrom = 0; ColumnTo = 7 }

        (finalState.RowFrom * 8) + finalState.ColumnFrom

    let calculate part input = input |> Seq.map seatID |> Seq.max
