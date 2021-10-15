namespace Wolfe.AdventOfCode._2020.Utils
{
    public class TreeMap
    {
        private readonly bool[,] _treeMap;

        public TreeMap(string input) : this(input.Split(Environment.NewLine))
        {

        }

        public TreeMap(string[] input)
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
                if (_treeMap[curX, curY]) trees++;
                curX = (curX + xSlope) % width;
                curY = (curY + ySlope) % height;
            }

            return trees;
        }

        private static bool[,] ParseTreeMap(IReadOnlyList<string> input)
        {
            var map = new bool[input[0].Length, input.Count];
            for (var y = 0; y < input.Count; y++)
            {
                var line = input[y];
                for (var x = 0; x < line.Length; x++)
                    map[x, y] = line[x] == '#';
            }

            return map;
        }
    }
}
