namespace Wolfe.AdventOfCode.Y2022.Puzzles;

internal class Day03 : IPuzzleDay
{
    public int Day => 3;

    public Task<string> Part1(string? input, CancellationToken cancellationToken = default) => input
        .ToLines()
        .Select(l => l.SplitByLength(l.Length / 2))
        .Select(FindCommon)
        .Join()
        .Select(Priority)
        .Sum()
        .ToString()
        .ToTask();

    public Task<string> Part2(string? input, CancellationToken cancellationToken = default) => "".ToTask();

    private static char FindCommon(IEnumerable<string> input) => input.Cast<IEnumerable<char>>().Aggregate((p, n) => p.Intersect(n)).First();

    private static int Priority(char input) => char.IsLower(input) ? input - 'a' + 1 : input - 'A' + 27;
}
