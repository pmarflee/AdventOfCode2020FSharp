namespace AdventOfCode.Tests

module Day4 =
    
    open Xunit
    open FsUnit.Xunit
    open AdventOfCode.Core.Day4

    type Tests ()=

        static member ParseKeyValuePairsData
            with get() = 
            [ 
                [|  "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd\r\n\
                     byr:1937 iyr:2017 cid:147 hgt:183cm\r\n\r\n\
                     iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884\r\n\
                     hcl:#cfa07d byr:1929\r\n\r\n\
                     hcl:#ae17e1 iyr:2013\r\n\
                     eyr:2024\r\n\
                     ecl:brn pid:760753108 byr:1931\r\n\
                     hgt:179cm\r\n\r\n\
                     hcl:#cfa07d eyr:2025 pid:166559648\r\n\
                     iyr:2011 ecl:brn hgt:59in" :> obj; 
                    [ Passport [ 
                        { Key = EyeColor; Value = "gry" };
                        { Key = PassportID; Value = "860033327" };
                        { Key = ExpirationYear; Value = "2020" };
                        { Key = HairColor; Value = "#fffffd" };
                        { Key = BirthYear; Value = "1937" };
                        { Key = IssueYear; Value = "2017" };
                        { Key = CountryID; Value = "147" };
                        { Key = Height; Value = "183cm" };
                      ];
                      Passport [
                        { Key = IssueYear; Value = "2013" };
                        { Key = EyeColor; Value = "amb" };
                        { Key = CountryID; Value = "350" };
                        { Key = ExpirationYear; Value = "2023" };
                        { Key = PassportID; Value = "028048884" };
                        { Key = HairColor; Value = "#cfa07d" };
                        { Key = BirthYear; Value = "1929" };
                      ];
                      Passport [
                        { Key = HairColor; Value = "#ae17e1" };
                        { Key = IssueYear; Value = "2013" };
                        { Key = ExpirationYear; Value = "2024" };
                        { Key = EyeColor; Value = "brn" };
                        { Key = PassportID; Value = "760753108" };
                        { Key = BirthYear; Value = "1931" };
                        { Key = Height; Value = "179cm" };
                      ];
                      Passport [
                        { Key = HairColor; Value = "#cfa07d" };
                        { Key = ExpirationYear; Value = "2025" };
                        { Key = PassportID; Value = "166559648" };
                        { Key = IssueYear; Value = "2011" };
                        { Key = EyeColor; Value = "brn" };
                        { Key = Height; Value = "59in" };
                      ];
                    ] :> obj; 
                |]; 
            ]

        [<Theory>]
        [<MemberData(nameof Tests.ParseKeyValuePairsData)>]
        member _.``Day 4 Parse Input`` (input : string, expected : Passport list) =
            Parser.parse input |> should equal expected

