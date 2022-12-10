namespace Wolfe.AdventOfCode.Y2022.Puzzles;

internal class Day10 : IPuzzleDay
{
    public int Day => 10;

    public Task<string> Part1(string input, CancellationToken cancellationToken = default) =>
        Execute(input)
        .Take(220)
        .Select(SignalStrength)
        .Where((_, i) => (i + 21) % 40 == 0)
        .Sum()
        .ToString()
        .ToTask();

    public Task<string> Part2(string input, CancellationToken cancellationToken = default)
    {
        var output = Execute(input)
            .Take(240);

        return Render(output).ToTask();
    }

    private static string Render(IEnumerable<int> registers)
    {
        var rows = registers.Chunk(40);
        var output = "";

        foreach (var row in rows)
        {
            var crt = 0;
            foreach (var pos in row)
            {
                var posMin = pos - 1;
                var posMax = pos + 1;
                output += (crt >= posMin && crt <= posMax) ? '#' : '.';
                crt++;
            }
            output += Environment.NewLine;
        }
        return output;
    }

    private static IEnumerable<int> Execute(string input)
    {
        var register = 1;
        yield return register;

        foreach (var instruction in input.ToLines())
        {
            var output = Execute(register, instruction);
            foreach (var value in output)
            {
                yield return register = value;
            }
        }
    }

    private static IEnumerable<int> Execute(int register, string instruction)
    {
        var (op, arg) = instruction.Split(' ');
        return op switch
        {
            "noop" => NoOp(register),
            "addx" => AddX(register, int.Parse(arg!)),
            _ => throw new InvalidOperationException("Unrecognized command")
        };
    }

    private static IEnumerable<int> NoOp(int register)
    {
        yield return register;
    }

    private static IEnumerable<int> AddX(int register, int value)
    {
        yield return register;
        yield return register + value;
    }

    private static int SignalStrength(int register, int cycle) => register * (cycle + 1);
}
