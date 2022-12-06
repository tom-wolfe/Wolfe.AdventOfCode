namespace Wolfe.AdventOfCode.Y2022.Puzzles;

internal class Day01 : IPuzzleDay
{
    public int Day => 1;

    public Task<string> Part1(string input, CancellationToken cancellationToken = default) =>
        CountCalories(input)
            .Max()
            .ToString()
            .ToTask();

    public Task<string> Part2(string input, CancellationToken cancellationToken = default) =>
        CountCalories(input)
            .OrderByDescending(c => c)
            .Take(3)
            .Sum()
            .ToString()
            .ToTask();

    private static IEnumerable<int> CountCalories(string? input) =>
        input
            .GroupLines()
            .Select(elf => elf.Select(int.Parse))
            .Select(e => e.Sum(c => c));
}
