namespace Wolfe.AdventOfCode.Y2022.Puzzles;

internal partial class Day06 : IPuzzleDay
{
    public int Day => 6;

    public Task<string> Part1(string input, CancellationToken cancellationToken = default)
    {
        const int sequenceLength = 4;

        var buffer = new Queue<int>();
        for (var x = 0; x < input!.Length; x++)
        {
            buffer.Enqueue(input[x]);
            if (buffer.Count > sequenceLength)
            {
                buffer.Dequeue();
            }

            if (buffer.Count == sequenceLength && buffer.Distinct().Count() == sequenceLength)
            {
                return (x + 1).ToString().ToTask();
            }
        }

        return "0".ToTask();
    }

    public Task<string> Part2(string input, CancellationToken cancellationToken = default)
    {


        return ""
            .ToTask();
    }
}
