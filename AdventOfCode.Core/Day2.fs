namespace AdventOfCode.Core

module Day2 =

    open Farkle
    open Farkle.Builder
    open Farkle.Builder.Regex

    type PasswordPolicy = {
        From : int;
        To : int;
        Letter : char;
    } with 
      member this.IsValid(password : string) =
        let result = password |> Seq.countBy id |> Seq.tryFind (fun (c, _) -> c = this.Letter)
        match result with
        | Some(_, count) -> count >= this.From && count <= this.To
        | None -> false
    
    type PasswordLine = {
        Policy : PasswordPolicy;
        Password : string;
    } with
      member this.IsValid = this.Policy.IsValid(this.Password)

    type Parser () =

        static let number = Terminals.genericUnsigned<int> "PasswordRangeNumber"

        static let letter = chars PredefinedSets.Letter 
                            |> terminal "PasswordLetter" (T(fun _ data -> data.[0]))

        static let passwordPolicy = "PasswordPolicy" ||= [
            !@ number .>> "-" .>>. number .>>. letter =>
            (fun rangeFrom rangeTo letter -> {
                From = rangeFrom;
                To = rangeTo;
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

    let calculate input = input 
                          |> Seq.map parseLine 
                          |> Seq.where (fun line -> line.IsValid)
                          |> Seq.length


