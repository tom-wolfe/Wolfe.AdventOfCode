namespace Wolfe.AdventOfCode.Y2020.Puzzles;

internal class Day01 : IPuzzleDay
{
    public int Day => 1;

    public Task<string> Part1(string? input, CancellationToken cancellationToken = default)
    {
        var values = input.ToLines().Select(int.Parse);

        var (a, b) = SumFinder.FindPair(values, 2020);
        var solution = a * b;
        return Task.FromResult(solution.ToString());
    }

    public Task<string> Part2(string? input, CancellationToken cancellationToken = default)
    {
        var values = input.ToLines().Select(int.Parse);

        var (a, b, c) = SumFinder.FindTriplet(values, 2020);
        var solution = a * b * c;
        return Task.FromResult(solution.ToString());
    }

    private static class SumFinder
    {
        public static (int, int) FindPair(IEnumerable<int> source, int sum)
        {
            var abPairs = new Dictionary<int, int>();
            foreach (var a in source)
            {
                var b = sum - a;
                if (abPairs.ContainsKey(b))
                    return (b, abPairs[b]);
                abPairs[a] = b;
            }

            throw new Exception("No matching pair found");
        }

        public static (int, int, int) FindTriplet(IEnumerable<int> source, int sum)
        {
            var list = source.ToList();
            foreach (var a in list)
            {
                foreach (var b in list)
                {
                    var c = sum - (a + b);
                    if (c <= 0) { continue; }
                    if (list.Contains(c)) { return (a, b, c); }
                }
            }
            throw new Exception("No matching triplet found");
        }
    }
}
