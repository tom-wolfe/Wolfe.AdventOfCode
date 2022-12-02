namespace Wolfe.AdventOfCode.Y2022.Puzzles;

internal class Day02 : IPuzzleDay
{
    public int Day => 2;

    public Task<string> Part1(string? input, CancellationToken cancellationToken = default) => input
        .ToLines()
        .Select(Round.FromInstruction)
        .Select(r => r.Score)
        .Sum()
        .ToString()
        .ToTask();

    public Task<string> Part2(string? input, CancellationToken cancellationToken = default) => input
        .ToLines()
        .Select(Round.FromWinState)
        .Select(r => r.Score)
        .Sum()
        .ToString()
        .ToTask();

    private record Round(RockPaperScissors You, RockPaperScissors Opponent)
    {
        public bool IsDraw => Opponent == You;

        public bool IsWin => You == LosesAgainst(Opponent);

        public int Score => (int)You + (IsDraw ? 3 : 0) + (IsWin ? 6 : 0);

        public static Round FromInstruction(string input)
        {
            return new Round(Parse(input[2]), Parse(input[0]));
        }

        public static Round FromWinState(string input)
        {
            var opponent = Parse(input[0]);
            var you = input[2] switch
            {
                'X' => WinsAgainst(opponent),
                'Y' => opponent,
                'Z' => LosesAgainst(opponent),
                _ => throw new ArgumentOutOfRangeException()
            };
            return new Round(you, opponent);
        }

        private static RockPaperScissors LosesAgainst(RockPaperScissors input) => input switch
        {
            RockPaperScissors.Rock => RockPaperScissors.Paper,
            RockPaperScissors.Paper => RockPaperScissors.Scissors,
            RockPaperScissors.Scissors => RockPaperScissors.Rock,
            _ => throw new ArgumentOutOfRangeException(nameof(input), input, null)
        };

        private static RockPaperScissors WinsAgainst(RockPaperScissors input) => input switch
        {
            RockPaperScissors.Rock => RockPaperScissors.Scissors,
            RockPaperScissors.Paper => RockPaperScissors.Rock,
            RockPaperScissors.Scissors => RockPaperScissors.Paper,
            _ => throw new ArgumentOutOfRangeException(nameof(input), input, null)
        };

        private static RockPaperScissors Parse(char c) => c switch
        {
            'A' => RockPaperScissors.Rock,
            'B' => RockPaperScissors.Paper,
            'C' => RockPaperScissors.Scissors,
            'X' => RockPaperScissors.Rock,
            'Y' => RockPaperScissors.Paper,
            'Z' => RockPaperScissors.Scissors,
            _ => throw new ArgumentOutOfRangeException(nameof(c), c, null)
        };
    }

    enum RockPaperScissors
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }
}
