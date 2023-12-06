namespace Wolfe.AdventOfCode.Y2023.Puzzles;
internal class Day01 : IPuzzleDay
{
    public int Day => 1;

    public Task<string> Part1(string input, CancellationToken cancellationToken = default) => input
        .ToLines()
        .Select(s => s.Where(char.IsAsciiDigit).ToArray())
        .Select(d => d[0].ToString() + d[^1])
        .Select(int.Parse)
        .Sum()
        .ToString()
        .ToTask();

    public Task<string> Part2(string input, CancellationToken cancellationToken = default) => input
        .ToLines()
        .Select(s =>
        {
            var o = WordsToDigits.Select(f => new { F = s.IndexOf(f.Key), L = s.LastIndexOf(f.Key), D = f.Value }).ToList();
            var f = o.Where(x => x.F > -1).MinBy(x => x.F)!.D;
            var l = o.Where(x => x.L > -1).MaxBy(x => x.L)!.D;
            return f + l;
        })
        .Select(int.Parse)
        .Sum()
        .ToString()
        .ToTask();

    public static readonly IReadOnlyDictionary<string, string> WordsToDigits = new Dictionary<string, string>
    {
        {"1", "1"},
        {"2", "2"},
        {"3", "3"},
        {"4", "4"},
        {"5", "5"},
        {"6", "6"},
        {"7", "7"},
        {"8", "8"},
        {"9", "9"},
        {"one", "1"},
        {"two", "2"},
        {"three", "3"},
        {"four", "4"},
        {"five", "5"},
        {"six", "6"},
        {"seven", "7"},
        {"eight", "8"},
        {"nine", "9"},
    };
}
