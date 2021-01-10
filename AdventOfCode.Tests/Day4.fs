namespace AdventOfCode.Tests

module Day4 =
    
    open Xunit
    open FsUnit.Xunit
    open AdventOfCode.Core.Day4

    type Tests ()=

        static member Part1Input
            with get() = "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd\r\n\
                     byr:1937 iyr:2017 cid:147 hgt:183cm\r\n\r\n\
                     iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884\r\n\
                     hcl:#cfa07d byr:1929\r\n\r\n\
                     hcl:#ae17e1 iyr:2013\r\n\
                     eyr:2024\r\n\
                     ecl:brn pid:760753108 byr:1931\r\n\
                     hgt:179cm\r\n\r\n\
                     hcl:#cfa07d eyr:2025 pid:166559648\r\n\
                     iyr:2011 ecl:brn hgt:59in"

        static member ParseKeyValuePairsData
            with get() = 
            [ 
                [|  Tests.Part1Input :> obj; 
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

        static member Part2Data
            with get() =
            [
                [| "eyr:1972 cid:100\r\n\
                    hcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926\r\n\r\n\
                    iyr:2019\r\n\
                    hcl:#602927 eyr:1967 hgt:170cm\r\n\
                    ecl:grn pid:012533040 byr:1946\r\n\r\n\
                    hcl:dab227 iyr:2012\r\n\
                    ecl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277\r\n\r\n\
                    hgt:59cm ecl:zzz\r\n\
                    eyr:2038 hcl:74454a iyr:2023\r\n\
                    pid:3556412378 byr:2007" :> obj; 0 :> obj; |];
                [| "pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980\r\n\
                    hcl:#623a2f\r\n\r\n\
                    eyr:2029 ecl:blu cid:129 byr:1989\r\n\
                    iyr:2014 pid:896056539 hcl:#a97842 hgt:165cm\r\n\r\n\
                    hcl:#888785\r\n\
                    hgt:164cm byr:2001 iyr:2015 cid:88\r\n\
                    pid:545766238 ecl:hzl\r\n\
                    eyr:2022\r\n\r\n\
                    iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719" :> obj;
                    4 :> obj; |]
            ]

        [<Theory>]
        [<MemberData(nameof Tests.ParseKeyValuePairsData)>]
        member _.``Day 4 Parse Input`` (input : string, expected : Passport list) =
            Day4Parser.parsePassports input |> should equal expected

        [<Fact>]
        member _.``Day 4 Part 1`` () = calculate 1 Tests.Part1Input |> should equal 2

        [<Theory>]
        [<MemberData(nameof Tests.Part2Data)>]
        member _.``Day 4 Part 2`` (input : string, expected : int) = calculate 2 input |> should equal expected
