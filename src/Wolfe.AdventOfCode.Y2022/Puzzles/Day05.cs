using System.Text.RegularExpressions;

namespace Wolfe.AdventOfCode.Y2022.Puzzles;

internal partial class Day05 : IPuzzleDay
{
    [GeneratedRegex(@"move (\d+) from (\d+) to (\d+)")]
    private static partial Regex InstructionRegex();

    public int Day => 5;

    public Task<string> Part1(string? input, CancellationToken cancellationToken = default)
    {
        var (rawState, rawInstructions) = input.GroupLines();

        var state = ParseState(rawState);
        var instructions = ParseInstructions(rawInstructions);

        Run(state, instructions);

        return state
            .Select(c => c.Peek())
            .Join()
            .ToTask();
    }

    public Task<string> Part2(string? input, CancellationToken cancellationToken = default) => ""
        .ToTask();

    private static List<Stack<char>> ParseState(IEnumerable<string> input)
    {
        var allData = input.Reverse().ToList();
        var columnCount = allData.First().Replace(" ", "").Length;
        var stateData = allData.Skip(1);
        var state = Enumerable
            .Range(0, columnCount)
            .Select(_ => new Stack<char>())
            .ToList();

        foreach (var line in stateData)
        {
            for (var x = 0; x < columnCount; x++)
            {
                var charIndex = 4 * x + 1;
                var nChar = line[charIndex];
                if (nChar != ' ')
                {
                    state[x].Push(nChar);
                }
            }
        }

        return state;
    }

    private static List<(int, int, int)> ParseInstructions(IEnumerable<string> instructions) => instructions
        .Select(i =>
        {
            var match = InstructionRegex().Match(i);
            return (
                int.Parse(match.Groups[1].Value),
                int.Parse(match.Groups[2].Value) - 1,
                int.Parse(match.Groups[3].Value) - 1
            );
        }).ToList();

    private static void Run(List<Stack<char>> state, List<(int, int, int)> instructions)
    {
        foreach (var instruction in instructions)
        {
            for (var x = 1; x <= instruction.Item1; x++)
            {
                var y = state[instruction.Item2].Pop();
                state[instruction.Item3].Push(y);
            }
        }
    }
}
