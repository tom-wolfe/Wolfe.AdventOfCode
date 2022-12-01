namespace Wolfe.AdventOfCode.Y2020.Puzzles;

internal class Day07 : IPuzzleDay
{
    public int Day => 7;

    public Task<string> Part1(string? input, CancellationToken cancellationToken = default)
    {
        var bags = new BagCollection();
        var lines = input.ToLines();
        foreach (var line in lines) bags.AddBag(line);

        var bagList = bags.BagsEventuallyContaining("shiny", "gold").ToList();
        return Task.FromResult(bagList.Count().ToString());
    }

    public Task<string> Part2(string? input, CancellationToken cancellationToken = default)
    {
        var bags = new BagCollection();
        var lines = input.ToLines();
        foreach (var line in lines) bags.AddBag(line);

        var count = bags.CountBagsWithin("shiny", "gold");
        return Task.FromResult(count.ToString());
    }

    private class BagCollection
    {
        private readonly Dictionary<(string, string), List<(int, string, string)>> _bags = new();

        public void AddBag(string bag)
        {
            // bright olive bags contain 4 dotted teal bags, 3 dotted violet bags.
            var words = new Queue<string>(bag.Split(' '));

            var adjective = words.Dequeue();
            var color = words.Dequeue();

            words.Dequeue(); // bags
            words.Dequeue(); // contain

            var contents = GetOrCreateBag(adjective, color);
            while (words.Count > 0)
            {
                if (!int.TryParse(words.Dequeue(), out var qty)) break;
                var innerAdj = words.Dequeue();
                var innerCol = words.Dequeue();
                contents.Add((qty, innerAdj, innerCol));
                GetOrCreateBag(innerAdj, innerCol);

                words.Dequeue(); // "bags," or "bags."
            }
        }

        public IEnumerable<(string, string)> BagsEventuallyContaining(string adjective, string color)
        {
            var list = new List<(string, string)>();
            BagsWhereContainsCore(adjective, color, list);
            return list;
        }

        private void BagsWhereContainsCore(string adjective, string color, ICollection<(string, string)> runningCount)
        {
            var parents = BagsContaining(adjective, color);
            foreach (var parent in parents)
            {
                if (runningCount.Contains(parent)) continue;
                runningCount.Add(parent);
                BagsWhereContainsCore(parent.Item1, parent.Item2, runningCount);
            }
        }

        private IEnumerable<(string, string)> BagsContaining(string adjective, string color) => _bags
            .Where(b => b.Value.Any(i => i.Item2 == adjective && i.Item3 == color))
            .Select(b => b.Key);

        public int CountBagsWithin(string adjective, string color)
        {
            var count = 0;
            var contents = GetOrCreateBag(adjective, color);
            foreach (var (qty, bagAdj, bagCol) in contents)
            {
                count += qty + qty * CountBagsWithin(bagAdj, bagCol);
            }
            return count;
        }

        private List<(int, string, string)> GetOrCreateBag(string adjective, string color)
        {
            var key = (adjective, color);
            if (_bags.TryGetValue(key, out var contents)) return contents;
            return _bags[key] = new();
        }
    }
}