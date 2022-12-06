namespace Wolfe.AdventOfCode.Y2020.Puzzles;

internal class Day02 : IPuzzleDay
{
    public int Day => 2;

    private static readonly Regex PasswordRegex = new(@"(?<min>\d+)-(?<max>\d+) (?<letter>\D): (?<password>\D+)");

    public Task<string> Part1(string input, CancellationToken cancellationToken = default) => input
        .ToLines()
        .Select(ParsePassword)
        .Count(IsValid)
        .ToString()
        .ToTask();

    public Task<string> Part2(string input, CancellationToken cancellationToken = default) => input
        .ToLines()
        .Select(ParsePassword)
        .Count(IsValidPart2)
        .ToString()
        .ToTask();

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