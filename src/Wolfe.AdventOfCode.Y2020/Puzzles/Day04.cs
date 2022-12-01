using System.Text.RegularExpressions;

namespace Wolfe.AdventOfCode.Y2020.Puzzles;

internal class Day04 : IPuzzleDay
{
    public int Day => 4;

    private static readonly Regex PassportRegex = new(@"(?<key>\D{3}):(?<value>[^\s]+)");

    public Task<string> Part1(string? input, CancellationToken cancellationToken = default) =>
        ParsePassports(input.ToLines())
            .Count(p => p.IsValid())
            .ToString()
            .ToTask();

    public Task<string> Part2(string? input, CancellationToken cancellationToken = default) =>
        ParsePassports(input.ToLines())
            .Count(p => p.IsValidStrict())
            .ToString()
            .ToTask();

    private static List<Passport> ParsePassports(IEnumerable<string> input)
    {
        return input.GroupLines().Select(group =>
        {
            var fields = group
                .Select(line => PassportRegex.Matches(line))
                .SelectMany(matches => matches)
                .ToDictionary(m => m.Groups["key"].Value, m => m.Groups["value"].Value);
            return new Passport(fields);
        }).ToList();
    }

    private class Passport : Dictionary<string, string>
    {
        public Passport(IDictionary<string, string> source) : base(source) { }
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
                "cm" => height is >= 150 and <= 193,
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