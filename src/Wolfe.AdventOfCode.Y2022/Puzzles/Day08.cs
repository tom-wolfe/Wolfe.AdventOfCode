using System.Data;
using System.Xml.Schema;
using Wolfe.AdventOfCode.DataStructures;

namespace Wolfe.AdventOfCode.Y2022.Puzzles;

internal class Day08 : IPuzzleDay
{
    public int Day => 8;

    public Task<string> Part1(string input, CancellationToken cancellationToken = default)
    {
        var map = Parse(input);
        return map
            .Flatten()
            .Count(n => IsVisible(map, n.Item1, n.Item2))
            .ToString()
            .ToTask();
    }

    public Task<string> Part2(string input, CancellationToken cancellationToken = default)
    {
        return "".ToTask();
    }

    private static Map<int> Parse(string input) => new(input.ToLines().Select(r => r.Select(c => int.Parse(c.ToString()))));

    private static bool IsVisible(Map<int> map, int x, int y)
    {
        var t = map[x, y];

        var h = map.GetRow(y);
        var v = map.GetColumn(x);

        var west = h.Where((_, i) => i < x);
        var east = h.Where((_, i) => i > x);

        var north = v.Where((_, i) => i < y);
        var south = v.Where((_, i) => i > y);

        return west.All(w => w < t)
               || south.All(w => w < t)
               || east.All(w => w < t)
               || north.All(w => w < t);
    }

}
