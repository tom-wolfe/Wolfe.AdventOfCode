namespace Wolfe.AdventOfCode.Common
{
    public interface IPuzzleDay
    {
        int Day { get; }
        Task<string> Part1(CancellationToken cancellationToken = default);
        Task<string> Part2(CancellationToken cancellationToken = default);
    }
}