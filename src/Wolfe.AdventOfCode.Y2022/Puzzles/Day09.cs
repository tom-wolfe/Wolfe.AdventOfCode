namespace Wolfe.AdventOfCode.Y2022.Puzzles;

using System.Globalization;

internal class Day09 : IPuzzleDay
{
    public int Day => 9;

    public Task<string> Part1(string input, CancellationToken cancellationToken = default) =>
        ""
            .ToTask();

    public Task<string> Part2(string input, CancellationToken cancellationToken = default) => ""
            .ToTask();

    private static IEnumerable<(char, int)> Parse(string input) => input
        .ToLines()
        .Select(r => r.Split(' '))
        .Select(t => (t[0][0], int.Parse(t[1], CultureInfo.InvariantCulture)));
}
