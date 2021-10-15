using Wolfe.AdventOfCode.Common;

namespace Wolfe.AdventOfCode._2020.Day01
{
    internal class Day01Part2 : IPuzzlePart
    {
        public int Day { get; } = 1;
        public int Part { get; } = 2;

        public Task<string> Solve(CancellationToken cancellationToken)
        {
            var input = File
                .ReadAllLines("./Day01/Input.txt")
                .Select(int.Parse)
                .ToList();
            var sum = new SumFinder(input);
            var (a, b, c) = sum.FindTriplet(2020);
            var solution = a * b * c;
            return Task.FromResult(solution.ToString());
        }
    }
}
