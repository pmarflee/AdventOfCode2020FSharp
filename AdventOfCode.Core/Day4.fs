namespace AdventOfCode.Core

module Day4 =

    open System
    open Farkle
    open Farkle.Builder
    open Farkle.Builder.Regex
    
    type Rgx = System.Text.RegularExpressions.Regex

    type Field =
        | BirthYear
        | IssueYear
        | ExpirationYear
        | Height
        | HairColor
        | EyeColor
        | PassportID
        | CountryID

    type HeightUnit = Centimetre | Inch

    type Height = { Value : int; Unit : HeightUnit }

    type EyeColour =
        | Amber
        | Blue
        | Brown
        | Grey
        | Green
        | Hazel
        | Other

    let isIntegerInRange lower upper input = input >= lower && input <= upper

    let isValidInteger lower upper (input : string) = 
        match System.Int32.TryParse input with
        | true,int -> isIntegerInRange lower upper int
        | _ -> false

    type KeyValuePair = { Key : Field; Value : string; }

    type Passport = Passport of KeyValuePair list

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

        static let unsignedNumber = Terminals.genericUnsigned<int> "UnsignedNumber"

        static let heightUnit =
            [
                "cm", Centimetre
                "in", Inch
            ]
            |> List.map (fun (name, x) -> !& name =% x)
            |> (||=) "HeightUnit"

        static let height = "Height" ||= [
            !@ unsignedNumber .>>. heightUnit => (fun n u -> { Value = n; Unit = u })
        ]

        static let hairColor =
            regexString "#([0-9]|[a-f]){6}"
            |> terminal "HairColor" (T(fun _ data -> data.ToString()))

        static let eyeColor =
            [
                "amb", Amber
                "blu", Blue
                "brn", Brown
                "gry", Grey
                "grn", Green
                "hzl", Hazel
                "oth", Other
            ]
            |> List.map (fun (name, x) -> !& name =% x)
            |> (||=) "EyeColor"

        static let passportId =
            regexString "([0-9]){9}" 
            |> terminal "PassportID" (T(fun _ data -> data.ToString()))

        static let value =
            regexString "([a-z]|\d|#)+"
            |> terminal "Value" (T(fun _ data -> data.ToString()))

        static let keyValuePair = "KeyValuePair" ||= [
            !@ field .>> ":" .>>. value => (fun k v -> { Key = k; Value = v })
        ]

        static let passport = "Passport" ||= [
            !@ (many1 keyValuePair) => Passport
        ]

        static let passports = sepBy (literal "\r\n\r\n") passport

        static let runtimePassports = RuntimeFarkle.build passports
        static let runtimeHeight = RuntimeFarkle.build height
        static let runtimeHairColor = RuntimeFarkle.build hairColor
        static let runtimeEyeColor = RuntimeFarkle.build eyeColor
        static let runtimePassportId = RuntimeFarkle.build passportId

        static member internal parsePassports input = 
            match RuntimeFarkle.parseString runtimePassports input with
            | Ok result -> result
            | Error err -> failwith (err.ToString())

        static member internal parseHeight input = RuntimeFarkle.parseString runtimeHeight input

        static member internal parseHairColor input = RuntimeFarkle.parseString runtimeHairColor input

        static member internal parseEyeColor input = RuntimeFarkle.parseString runtimeEyeColor input

        static member internal parsePassportId input = RuntimeFarkle.parseString runtimePassportId input

    let private isValidHeight input = match Day4Parser.parseHeight input with
                                      | Ok height -> match height.Unit with
                                                     | Centimetre -> isIntegerInRange 150 193 height.Value
                                                     | Inch -> isIntegerInRange 59 76 height.Value
                                      | Error _ -> false

    let private isValidHairColor input = match Day4Parser.parseHairColor input with
                                         | Ok _ -> true
                                         | Error _ -> false

    let private isValidEyeColor input = match Day4Parser.parseEyeColor input with
                                         | Ok _ -> true
                                         | Error _ -> false

    let private isValidPassportId input = match Day4Parser.parsePassportId input with
                                          | Ok _ -> true
                                          | Error _ -> false

    let requiredFields = [ BirthYear; 
                           IssueYear; 
                           ExpirationYear; 
                           Height; 
                           HairColor; 
                           EyeColor; 
                           PassportID; ]

    let private validationRules = 
        [ BirthYear, isValidInteger 1920 2002;
          IssueYear, isValidInteger 2010 2020;
          ExpirationYear, isValidInteger 2020 2030;
          Height, isValidHeight;
          HairColor, isValidHairColor;
          EyeColor, isValidEyeColor;
          PassportID, isValidPassportId; 
          CountryID, fun _ -> true ]
          |> Map.ofList

    let private allRequiredFieldsArePresent = function
        | Passport p -> requiredFields |> List.forall (fun f -> p |> List.exists (fun kv -> kv.Key = f))
        
    let private allFieldsAreValid = function
        | Passport p -> p |> List.forall (fun kv -> validationRules.[kv.Key] kv.Value)

    let calculate part input = 
        let funcs = match part with
                    | 1 -> [ allRequiredFieldsArePresent ]
                    | 2 -> [ allRequiredFieldsArePresent; allFieldsAreValid ]
                    | _ -> invalidArg "part" "Should be 1 or 2"

        Day4Parser.parsePassports input 
            |> Seq.where (fun p -> funcs |> List.forall (fun f -> f p)) 
            |> Seq.length