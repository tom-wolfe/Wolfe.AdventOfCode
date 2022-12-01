namespace Wolfe.AdventOfCode.Y2020.Puzzles;

internal class Day05 : IPuzzleDay
{
    public int Day => 5;

    public Task<string> Part1(string? input, CancellationToken cancellationToken = default) =>
        input
            .ToLines()
            .Select(ParseBoardingPass)
            .Select(p => p.GetId())
            .Max()
            .ToString()
            .ToTask();

    public Task<string> Part2(string? input, CancellationToken cancellationToken = default)
    {
        var seatIds = input
            .ToLines()
            .Select(ParseBoardingPass)
            .Select(b => b.GetId())
            .OrderBy(p => p)
            .ToList();

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
        var row = pass[..7].ToBinary('B', 'F');
        var column = pass[7..].ToBinary('R', 'L');
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