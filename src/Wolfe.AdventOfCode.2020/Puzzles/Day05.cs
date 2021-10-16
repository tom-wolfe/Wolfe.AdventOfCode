using System.Text.RegularExpressions;
using Wolfe.AdventOfCode._2020.Utils;
using Wolfe.AdventOfCode.Common;

namespace Wolfe.AdventOfCode._2020.Puzzles
{
    internal class Day05 : IPuzzleDay
    {
        public int Day { get; } = 5;

        private static readonly Lazy<List<BoardingPass>> LazyBoardingPasses = new(() => File
            .ReadAllLines("./Inputs/Day05.txt")
            .Select(ParseBoardingPass)
            .ToList()
        );
        private static List<BoardingPass> BoardingPasses => LazyBoardingPasses.Value;

        public Task<string> Part1(CancellationToken cancellationToken = default)
        {
            var answer = BoardingPasses.Select(p => p.GetId()).Max();
            return Task.FromResult(answer.ToString());
        }

        public Task<string> Part2(CancellationToken cancellationToken = default)
        {
            var count = "";
            return Task.FromResult(count.ToString());
        }

        private static BoardingPass ParseBoardingPass(string pass)
        {
            var row = Binary.FromString(pass[..7], 'B', 'F');
            var column = Binary.FromString(pass[7..], 'R', 'L');
            return new BoardingPass(row, column);
        }

        private record BoardingPass(int Row, int Column)
        {
            public int GetId()
            {
                return Row * 8 + Column;
            }
        }
    }
}

