namespace Wolfe.AdventOfCode.Y2022.Puzzles;

internal class Day04 : IPuzzleDay
{
    public int Day => 4;

    public Task<string> Part1(string input, CancellationToken cancellationToken = default) => input
        .ToLines()
        .Select(Parse)
        .Count(FuncHelpers.Gather<int[], int[], bool>(FullyContains))
        .ToString()
        .ToTask();

    public Task<string> Part2(string input, CancellationToken cancellationToken = default) => input
        .ToLines()
        .Select(Parse)
        .Count(FuncHelpers.Gather<int[], int[], bool>(HaveOverlap))
        .ToString()
        .ToTask();

    private static (int[], int[]) Parse(string input) => input
        .Split(',')
        .Select(r => r.Split('-').Select(int.Parse).ToTuple2())
        .Select(r => Enumerable.Range(r.Item1, r.Item2 - r.Item1 + 1).ToArray())
        .ToTuple2();

    private static bool FullyContains(int[] left, int[] right) => left.Intersect(right).Count() == Math.Min(left.Length, right.Length);
    private static bool HaveOverlap(int[] left, int[] right) => left.Intersect(right).Any();
}
