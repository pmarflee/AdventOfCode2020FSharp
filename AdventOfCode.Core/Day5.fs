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

    let calculate part input = 
        let seatIDs = input |> Seq.map seatID
        match part with
        | 1 -> seatIDs |> Seq.max
        | 2 -> let allSeatIDs = Set.ofSeq seatIDs
               let isInList seatID = Set.contains seatID allSeatIDs
               let minSeatID = (Seq.min allSeatIDs) + 1
               let maxSeatID = (Seq.max allSeatIDs) - 1
               [ minSeatID .. maxSeatID ] |> List.find (fun seatID -> not (isInList seatID) && isInList (seatID - 1) && isInList (seatID + 1) )
        | _ -> invalidArg (nameof part) "Invalid part. Should be 1 or 2"
