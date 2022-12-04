namespace Wolfe.AdventOfCode.Y2022.Puzzles;

internal class Day04 : IPuzzleDay
{
    public int Day => 4;

    public Task<string> Part1(string? input, CancellationToken cancellationToken = default) => input
        .ToLines()
        .Select(Parse)
        .Where(FullyContains)
        .Count()
        .ToString()
        .ToTask();

    public Task<string> Part2(string? input, CancellationToken cancellationToken = default) => ""
        .ToTask();

    private static IEnumerable<int[]> Parse(string input) => input
        .Split(',')
        .Select(ParseRange);

    private static int[] ParseRange(string range)
    {
        var (from, to) = range.Split('-').Select(int.Parse);
        return Enumerable.Range(from, to - from + 1).ToArray();
    }

    private static bool FullyContains(IEnumerable<int[]> input)
    {
        var (l, r) = input;
        return l.Intersect(r).Count() == Math.Min(l.Length, r.Length);
    }
}
