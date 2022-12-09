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
        var map = Parse(input);

        var score = ScenicScore(map, 77, 17);

        return map
            .Flatten()
            .Select(n => ScenicScore(map, n.Item1, n.Item2))
            .Max()
            .ToString()
            .ToTask();
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

    private static int ScenicScore(Map<int> map, int x, int y)
    {
        var t = map[x, y];

        var h = map.GetRow(y);
        var v = map.GetColumn(x);

        var up = v.Where((_, i) => i < y).Reverse().ToArray();
        var left = h.Where((_, i) => i < x).Reverse().ToArray();
        var down = v.Where((_, i) => i > y).ToArray();
        var right = h.Where((_, i) => i > x).ToArray();

        var upCount = CountUntilGreaterThan(up, t);
        var leftCount = CountUntilGreaterThan(left, t);
        var downCount = CountUntilGreaterThan(down, t);
        var rightCount = CountUntilGreaterThan(right, t);

        var result = upCount * leftCount * downCount * rightCount;
        return result;
    }

    private static int CountUntilGreaterThan(IEnumerable<int> source, int than)
    {
        var count = 0;
        foreach (var n in source)
        {
            if (n < than)
            {
                count++;
            }
            else if (n >= than)
            {
                count++;
                break;
            }
        }
        return count;
    }

}
