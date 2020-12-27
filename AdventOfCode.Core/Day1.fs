namespace AdventOfCode.Core

module Day1 =

    let calculatePart1 numbers = 
        let numbers' = numbers |> Set.ofSeq
        let tryFindPair number = 
            let other = 2020 - number
            if Set.contains other numbers' then
                Some(number, other)
            else
                None
        let first, second = numbers' |> Seq.pick tryFindPair 

        first * second
