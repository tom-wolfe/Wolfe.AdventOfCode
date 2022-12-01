using Wolfe.AdventOfCode._2020.Utils;
using Wolfe.AdventOfCode.Common;

namespace Wolfe.AdventOfCode._2020.Puzzles
{
    internal class Day01 : IPuzzleDay
    {
        public int Day { get; } = 1;

        private static readonly Lazy<SumFinder> LazySumFinder = new(() =>
        {
            var input = File
                .ReadAllLines("./Inputs/Day01.txt")
                .Select(int.Parse);
            return new SumFinder(input);
        });
        private static SumFinder SumFinder => LazySumFinder.Value;

        public Task<string> Part1(CancellationToken cancellationToken = default)
        {
            var (a, b) = SumFinder.FindPair(2020);
            var solution = a * b;
            return Task.FromResult(solution.ToString());
        }

        public Task<string> Part2(CancellationToken cancellationToken = default)
        {
            var (a, b, c) = SumFinder.FindTriplet(2020);
            var solution = a * b * c;
            return Task.FromResult(solution.ToString());
        }
    }
}
