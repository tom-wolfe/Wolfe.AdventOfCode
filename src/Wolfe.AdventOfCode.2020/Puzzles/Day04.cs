using System.Text.RegularExpressions;
using Wolfe.AdventOfCode.Common;

namespace Wolfe.AdventOfCode._2020.Puzzles
{
    internal class Day04 : IPuzzleDay
    {
        public int Day { get; } = 4;

        private static readonly Regex PassportRegex = new(@"(?<key>\D{3}):(?<value>[^\s]+)");

        private static readonly Lazy<List<Passport>> LazyPassports = new(() => ParsePassports(File.ReadAllLines("./Inputs/Day04.txt")));
        private static List<Passport> LazyPassport => LazyPassports.Value;

        public Task<string> Part1(CancellationToken cancellationToken = default)
        {
            var count = LazyPassport.Count(p => p.IsValid());
            return Task.FromResult(count.ToString());
        }

        public Task<string> Part2(CancellationToken cancellationToken = default)
        {
            var count = LazyPassport.Count(p => p.IsValidStrict());
            return Task.FromResult(count.ToString());
        }

        private static List<Passport> ParsePassports(IEnumerable<string> input)
        {
            var passports = new List<Passport>();
            var currentPassport = new Passport();
            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    passports.Add(currentPassport);
                    currentPassport = new Passport();
                }
                var matches = PassportRegex.Matches(line);
                foreach (Match match in matches)
                    currentPassport.Add(match.Groups["key"].Value, match.Groups["value"].Value);
            }
            passports.Add(currentPassport);
            return passports;
        }

        private class Passport : Dictionary<string, string>
        {
            private static readonly Regex HgtRegex = new(@"^(?<height>\d+)(?<unit>(cm|in))$");
            private static readonly Regex HclRegex = new(@"^#[0-9a-f]{6}$");
            private static readonly Regex EclRegex = new(@"^(amb|blu|brn|gry|grn|hzl|oth)$");
            private static readonly Regex PidRegex = new(@"^\d{9}$");

            public bool IsValid()
            {
                return ContainsKeys("byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid");
            }

            public bool IsValidStrict()
            {
                if (!IsValid()) return false;
                return ValidateByr() && ValidateIyr() && ValidateEyr() && ValidateHgt()
                       && ValidateHcl() && ValidateEcl() && ValidatePid();

            }

            private bool ValidateByr()
            {
                int.TryParse(this["byr"], out var byr);
                return byr is >= 1920 and <= 2002;
            }

            private bool ValidateIyr()
            {
                int.TryParse(this["iyr"], out var iyr);
                return iyr is >= 2010 and <= 2020;
            }

            private bool ValidateEyr()
            {
                int.TryParse(this["eyr"], out var eyr);
                return eyr is >= 2020 and <= 2030;
            }

            private bool ValidateHgt()
            {
                var match = HgtRegex.Match(this["hgt"]);
                if (!match.Success) { return false; }
                var unit = match.Groups["unit"].Value;
                int.TryParse(match.Groups["height"].Value, out var height);
                return unit switch
                {
                    "cm" => height is >=150 and <= 193,
                    "in" => height is >= 59 and <= 76,
                    _ => false
                };
            }

            private bool ValidateHcl() => HclRegex.IsMatch(this["hcl"]);
            private bool ValidateEcl() => EclRegex.IsMatch(this["ecl"]);
            private bool ValidatePid() => PidRegex.IsMatch(this["pid"]);

            private bool ContainsKeys(params string[] keys)
            {
                return keys.All(ContainsKey);
            }
        }
    }
}

