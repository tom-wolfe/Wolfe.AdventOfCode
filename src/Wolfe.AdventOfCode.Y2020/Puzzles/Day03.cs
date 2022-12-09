namespace Wolfe.AdventOfCode.Y2020.Puzzles;

internal class Day03 : IPuzzleDay
{
    public int Day => 3;

    public Task<string> Part1(string input, CancellationToken cancellationToken = default) =>
        new TreeMap(input)
            .CountTrees(3, 1)
            .ToString()
            .ToTask();

    public Task<string> Part2(string input, CancellationToken cancellationToken = default)
    {
        var map = new TreeMap(input);
        var part1 = map.CountTrees(1, 1);
        var part2 = map.CountTrees(3, 1);
        var part3 = map.CountTrees(5, 1);
        var part4 = map.CountTrees(7, 1);
        var part5 = map.CountTrees(1, 2);
        var answer = part1 * part2 * part3 * part4 * part5;
        return Task.FromResult(answer.ToString());
    }

    private class TreeMap
    {
        private readonly bool[,] _treeMap;

        public TreeMap(string? input) : this(input.ToLines())
        {

        }

        public TreeMap(IEnumerable<string> input)
        {
            _treeMap = ParseTreeMap(input);
        }

        public long CountTrees(int xSlope, int ySlope)
        {
            var trees = 0L;
            var (curX, curY) = (0, 0);
            var width = _treeMap.GetLength(0);
            var height = _treeMap.GetLength(1);
            for (var y = 0; y < height; y += ySlope)
            {
                if (_treeMap[curX, curY])
                    trees++;
                curX = (curX + xSlope) % width;
                curY = (curY + ySlope) % height;
            }

            return trees;
        }

        private static bool[,] ParseTreeMap(IEnumerable<string> input)
        {
            var inputArray = input.ToArray();
            var map = new bool[inputArray[0].Length, inputArray.Length];
            for (var y = 0; y < inputArray.Length; y++)
            {
                var line = inputArray[y];
                for (var x = 0; x < line.Length; x++)
                    map[x, y] = line[x] == '#';
            }

            return map;
        }
    }
}