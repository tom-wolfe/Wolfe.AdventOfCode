using Wolfe.AdventOfCode.Common;

namespace Wolfe.AdventOfCode._2020.Day01
{
    internal class Day01Part1 : IPuzzlePart
    {
        public int Day { get; } = 1;
        public int Part { get; } = 1;

        public Task<string> Solve(CancellationToken cancellationToken)
        {
            var input = File
                .ReadAllLines("./Day01/Day01Part1.txt")
                .Select(int.Parse)
                .ToList();
            var sum = new SumFinder(input);
            var pair = sum.FindPair(2020);
            var solution = pair.Item1 * pair.Item2;
            return Task.FromResult(solution.ToString());
        }
    }
}
