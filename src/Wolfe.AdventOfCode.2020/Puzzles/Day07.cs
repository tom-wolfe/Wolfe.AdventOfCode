using Wolfe.AdventOfCode._2020.Utils;
using Wolfe.AdventOfCode.Common;

namespace Wolfe.AdventOfCode._2020.Puzzles
{
    internal class Day07 : IPuzzleDay
    {
        public int Day { get; } = 7;

        private readonly BagCollection _bags = new();
        public Day07()
        {
            var lines = File.ReadAllLines("./Inputs/Day07.txt");
            foreach (var line in lines) _bags.AddBag(line);
        }

        public Task<string> Part1(CancellationToken cancellationToken = default)
        {
            var bags = _bags.BagsEventuallyContaining("shiny", "gold").ToList();
            return Task.FromResult(bags.Count().ToString());
        }

        public Task<string> Part2(CancellationToken cancellationToken = default)
        {
            return Task.FromResult("");
        }
    }
}

