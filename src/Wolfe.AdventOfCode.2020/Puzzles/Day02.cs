using System.Text.RegularExpressions;
using Wolfe.AdventOfCode.Common;

namespace Wolfe.AdventOfCode._2020.Puzzles
{
    internal class Day02 : IPuzzleDay
    {
        private static readonly Regex PasswordRegex = new (@"(?<min>\d+)-(?<max>\d+) (?<letter>\D): (?<password>\D+)");
        public int Day { get; } = 2;

        public Task<string> Part1(CancellationToken cancellationToken = default)
        {
            var input = File
                .ReadAllLines("./Inputs/Day02.txt")
                .Select(ParsePassword);
            var validPasswords = input.Count(IsValid);
            return Task.FromResult(validPasswords.ToString());
        }

        public Task<string> Part2(CancellationToken cancellationToken = default)
        {
            return Task.FromResult("0");
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

        private static bool IsValid(PasswordModel password)
        {
            var count = password.Password.Count(c => c == password.Letter);
            return count >= password.Min && count <= password.Max;
        }
    }
}
