namespace Wolfe.AdventOfCode;

public interface IPuzzleDay
{
    int Day { get; }
    Task<string> Part1(string input, CancellationToken cancellationToken = default);
    Task<string> Part2(string input, CancellationToken cancellationToken = default);
}
