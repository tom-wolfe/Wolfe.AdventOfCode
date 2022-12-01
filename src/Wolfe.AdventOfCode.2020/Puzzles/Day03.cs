using Wolfe.AdventOfCode._2020.Utils;
using Wolfe.AdventOfCode.Common;

namespace Wolfe.AdventOfCode._2020.Puzzles
{
    internal class Day03 : IPuzzleDay
    {
        public int Day { get; } = 3;

        private static readonly Lazy<TreeMap> LazyTreeMap = new(() => new TreeMap(File.ReadAllText("./Inputs/Day03.txt")));
        private static TreeMap TreeMap => LazyTreeMap.Value;

        public Task<string> Part1(CancellationToken cancellationToken = default)
        {
            var answer = TreeMap.CountTrees(3, 1);
            return Task.FromResult(answer.ToString());
        }

        public Task<string> Part2(CancellationToken cancellationToken = default)
        {
            var part1 = TreeMap.CountTrees(1, 1);
            var part2 = TreeMap.CountTrees(3, 1);
            var part3 = TreeMap.CountTrees(5, 1);
            var part4 = TreeMap.CountTrees(7, 1);
            var part5 = TreeMap.CountTrees(1, 2);
            var answer = part1 * part2 * part3 * part4 * part5;
            return Task.FromResult(answer.ToString());
        }
    }
}
