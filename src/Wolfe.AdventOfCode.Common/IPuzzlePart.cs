namespace Wolfe.AdventOfCode.Common
{
    public interface IPuzzlePart
    {
        int Day { get; }
        int Part { get; }
        Task<string> Solve(CancellationToken cancellationToken);
    }
}