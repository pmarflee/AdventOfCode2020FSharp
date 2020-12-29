namespace AdventOfCode.Core

module Day2 =

    open Farkle
    open Farkle.Builder
    open Farkle.Builder.Regex

    type PasswordPolicy = {
        First : int;
        Second : int;
        Letter : char;
    } with 
      member private this.IsValidPart1(password : string) =
        let count = password |> Seq.where (fun c -> c = this.Letter) |> Seq.length
        count >= this.First && count <= this.Second
      member private this.HasLetterAt(password : string, index : int) = password.[index - 1] = this.Letter
      member private this.IsValidPart2(password : string) =
        (this.HasLetterAt(password, this.First)) <> (this.HasLetterAt(password, this.Second))
      member this.IsValid(password : string, part : int) =
        match part with
        | 1 -> this.IsValidPart1(password)
        | 2 -> this.IsValidPart2(password)
        | _ -> invalidArg (nameof part) "Invalid part. Should be 1 or 2."
    
    type PasswordLine = {
        Policy : PasswordPolicy;
        Password : string;
    } with
      member this.IsValid(part : int) = this.Policy.IsValid(this.Password, part)

    type Parser () =

        static let number = Terminals.genericUnsigned<int> "PasswordRangeNumber"

        static let letter = chars PredefinedSets.Letter 
                            |> terminal "PasswordLetter" (T(fun _ data -> data.[0]))

        static let passwordPolicy = "PasswordPolicy" ||= [
            !@ number .>> "-" .>>. number .>>. letter =>
            (fun rangeFrom rangeTo letter -> {
                First = rangeFrom;
                Second = rangeTo;
                Letter = letter
            })
        ]
        static let password = chars PredefinedSets.Letter 
                              |> atLeast 2 
                              |> terminal "Password" (T(fun _ data -> data.ToString()))

        static let line = "PasswordLine" ||= [
            !@ passwordPolicy .>> ":" .>>. password =>
            (fun policy password -> {
                Policy = policy;
                Password = password
            })
        ]

        static member parseLine input = 
            match RuntimeFarkle.parseString (RuntimeFarkle.build line) input with
            | Ok result -> result
            | Error err -> failwith (err.ToString())

    let internal parseLine input = Parser.parseLine input

    let calculate part input = input 
                               |> Seq.map parseLine 
                               |> Seq.where (fun line -> line.IsValid part)
                               |> Seq.length


