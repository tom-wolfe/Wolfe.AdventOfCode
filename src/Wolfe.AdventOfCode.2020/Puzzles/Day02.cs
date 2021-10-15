using System.Text.RegularExpressions;
using Wolfe.AdventOfCode.Common;

namespace Wolfe.AdventOfCode._2020.Puzzles
{
    internal class Day02 : IPuzzleDay
    {
        public int Day { get; } = 2;

        private static readonly Regex PasswordRegex = new (@"(?<min>\d+)-(?<max>\d+) (?<letter>\D): (?<password>\D+)");
        private static readonly Lazy<List<PasswordModel>> LazyPasswords = new(() => File
            .ReadAllLines("./Inputs/Day02.txt")
            .Select(ParsePassword)
            .ToList()
        );
        private static List<PasswordModel> Passwords => LazyPasswords.Value;

        public Task<string> Part1(CancellationToken cancellationToken = default)
        {
            var validPasswords = Passwords.Count(IsValid);
            return Task.FromResult(validPasswords.ToString());
        }

        public Task<string> Part2(CancellationToken cancellationToken = default)
        {
            var input = File
                .ReadAllLines("./Inputs/Day02.txt")
                .Select(ParsePassword);
            var validPasswords = input.Count(IsValidPart2);
            return Task.FromResult(validPasswords.ToString());
        }

        record PasswordModel(int Min, int Max, char Letter, string Password);

        private static PasswordModel ParsePassword(string value)
        {
            var pwd = PasswordRegex.Match(value);
            return new PasswordModel(
            int.Parse(pwd.Groups["min"].Value),
            int.Parse(pwd.Groups["max"].Value),
                pwd.Groups["letter"].Value[0],
                pwd.Groups["password"].Value
            );
        }

        private static bool IsValid(PasswordModel pwd)
        {
            var count = pwd.Password.Count(c => c == pwd.Letter);
            return count >= pwd.Min && count <= pwd.Max;
        }

        private static bool IsValidPart2(PasswordModel pwd)
        {
            return pwd.Password[pwd.Min - 1] == pwd.Letter ^ pwd.Password[pwd.Max - 1] == pwd.Letter;
        }
    }
}
