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
    run "Day 1 Part 1:" (readAllLines "Day1.txt" |> Array.map int) Day1.calculatePart1

    printfn ""
    printfn "Finished"

    0 // Return an integer exit code
