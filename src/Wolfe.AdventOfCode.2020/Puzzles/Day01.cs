using Wolfe.AdventOfCode._2020.Utils;
using Wolfe.AdventOfCode.Common;

namespace Wolfe.AdventOfCode._2020.Puzzles
{
    internal class Day01 : IPuzzleDay
    {
        private readonly SumFinder _sumFinder;

        public Day01()
        {
            var input = File
                .ReadAllLines("./Inputs/Day01.txt")
                .Select(int.Parse);
            _sumFinder = new SumFinder(input);
        }

        public int Day { get; } = 1;

        public Task<string> Part1(CancellationToken cancellationToken = default)
        {
            var (a, b) = _sumFinder.FindPair(2020);
            var solution = a * b;
            return Task.FromResult(solution.ToString());
        }

        public Task<string> Part2(CancellationToken cancellationToken = default)
        {
            var (a, b, c) = _sumFinder.FindTriplet(2020);
            var solution = a * b * c;
            return Task.FromResult(solution.ToString());
        }
    }
}
