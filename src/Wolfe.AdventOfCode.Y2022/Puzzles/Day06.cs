namespace Wolfe.AdventOfCode.Y2022.Puzzles;

internal partial class Day06 : IPuzzleDay
{
    public int Day => 6;

    public Task<string> Part1(string input, CancellationToken cancellationToken = default) => 
        FindMarker(input, 4)
            .ToString()
            .ToTask();
    
    public Task<string> Part2(string input, CancellationToken cancellationToken = default) =>
        FindMarker(input, 14)
            .ToString()
            .ToTask();

    private static int FindMarker(string input, int length)
    {
        var buffer = new Queue<int>();
        for (var x = 0; x < input.Length; x++)
        {
            buffer.Enqueue(input[x]);
            if (buffer.Count > length)
            {
                buffer.Dequeue();
            }

            if (buffer.Count == length && buffer.Distinct().Count() == length)
            {
                return (x + 1);
            }
        }
        return -1;
    }
}
