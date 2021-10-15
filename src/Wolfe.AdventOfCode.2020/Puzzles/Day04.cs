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
            return Task.FromResult("");
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
            public bool IsValid()
            {
                return ContainsKeys("byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid");
            }

            private bool ContainsKeys(params string[] keys)
            {
                return keys.All(ContainsKey);
            }
        }
    }
}
