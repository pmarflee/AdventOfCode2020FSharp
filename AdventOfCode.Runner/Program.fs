open System.IO
open AdventOfCode.Core

[<EntryPoint>]
let main _ =
    printfn "Advent of Code 2020 Solutions"
    printfn "============================="
    printfn ""

    let read path = File.ReadAllText path
    let readAllLines path = File.ReadAllLines path

    let run title input func = 
        let stopWatch = System.Diagnostics.Stopwatch.StartNew()
        let result = func input
        let elapsed = stopWatch.ElapsedMilliseconds

        printfn "%s %O (%ims)" title result elapsed

    // Run solutions here
    run "Day 1 Part 1:" (readAllLines "Day1.txt" |> Array.map int) (Day1.calculate 1)
    run "Day 1 Part 2:" (readAllLines "Day1.txt" |> Array.map int) (Day1.calculate 2)
    run "Day 2 Part 1:" (readAllLines "Day2.txt") (Day2.calculate 1)
    run "Day 2 Part 2:" (readAllLines "Day2.txt") (Day2.calculate 2)
    run "Day 3 Part 1:" (readAllLines "Day3.txt") (Day3.calculate 1)
    run "Day 3 Part 2:" (readAllLines "Day3.txt") (Day3.calculate 2)
    run "Day 4 Part 1:" (read "Day4.txt") (Day4.calculate 1)
    run "Day 4 Part 2:" (read "Day4.txt") (Day4.calculate 2)
    run "Day 5 Part 1:" (readAllLines "Day5.txt") (Day5.calculate 1)
    run "Day 5 Part 2:" (readAllLines "Day5.txt") (Day5.calculate 2)
    run "Day 6 Part 1:" (readAllLines "Day6.txt" |> List.ofArray) (Day6.calculate 1)
    run "Day 6 Part 2:" (readAllLines "Day6.txt" |> List.ofArray) (Day6.calculate 2)

    printfn ""
    printfn "Finished"

    0 // Return an integer exit code
