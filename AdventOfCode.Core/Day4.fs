﻿namespace AdventOfCode.Core

module Day4 =

    open Farkle
    open Farkle.Builder
    open Farkle.Builder.Regex

    type Field =
        | BirthYear
        | IssueYear
        | ExpirationYear
        | Height
        | HairColor
        | EyeColor
        | PassportID
        | CountryID

    let requiredFields = [ BirthYear; 
                           IssueYear; 
                           ExpirationYear; 
                           Height; 
                           HairColor; 
                           EyeColor; 
                           PassportID; ]

    type KeyValuePair = { Key : Field; Value : string; }

    type Passport = Passport of KeyValuePair list
        with 
        member this.IsValid = 
            match this with
            | Passport p -> requiredFields |> List.forall (fun f -> p |> List.exists (fun kv -> kv.Key = f))
            

    type Day4Parser () =

        static let field =
            // Writing the field type as a nonterminal makes the parser more readable and case-insensitive.
            [
                "byr", BirthYear
                "iyr", IssueYear
                "eyr", ExpirationYear
                "hgt", Height
                "hcl", HairColor
                "ecl", EyeColor
                "pid", PassportID
                "cid", CountryID
            ]
            |> List.map (fun (name, x) -> !& name =% x)
            |> (||=) "Field"

        static let value =
            // The regex was shortened.
            regexString "([a-z]|\d|#)+"
            |> terminal "Value" (T(fun _ data -> data.ToString()))

        static let keyValuePair = "KeyValuePair" ||= [
            !@ field .>> ":" .>>. value => (fun k v -> { Key = k; Value = v })
        ]

        static let passport = "Passport" ||= [
            !@ (many1 keyValuePair) => Passport
        ]

        // This designtime Farkle matches many different passports in the same
        // input file (I assume you were calling the parser many times)
        static let passports = sepBy (literal "\r\n\r\n") passport

        // Declaring the runtime Farkle in a static member will cause it to be rebuilt every
        // time the property is accesed, resulting in a significant waste of computation.
        // I also took the liberty to remove the runtime Farkle for the KeyValuePair
        // (unless I am mistaken it doesn't seem necessary).
        static let runtime = RuntimeFarkle.build passports

        static member internal parse input = 
            match RuntimeFarkle.parseString runtime input with
            | Ok result -> result
            | Error err -> failwith (err.ToString())

    let calculate part input = Day4Parser.parse input |> Seq.where (fun p -> p.IsValid) |> Seq.length