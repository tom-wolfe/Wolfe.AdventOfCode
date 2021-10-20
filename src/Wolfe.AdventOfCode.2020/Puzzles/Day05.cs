using Wolfe.AdventOfCode.Common;
using Wolfe.AdventOfCode.Common.Extensions;

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
            var seatIds = BoardingPasses.Select(b => b.GetId()).OrderBy(p => p).ToList();

            var expected = seatIds[0];
            foreach (var id in seatIds)
            {
                if (id != expected) return Task.FromResult(expected.ToString());
                expected = id + 1;
            }
            return Task.FromResult("Error");
        }

        private static BoardingPass ParseBoardingPass(string pass)
        {
            var row = StringExtensions.ToBinary(pass[..7], 'B', 'F');
            var column = StringExtensions.ToBinary(pass[7..], 'R', 'L');
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

