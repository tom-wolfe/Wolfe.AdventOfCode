namespace Wolfe.AdventOfCode._2020.Utils
{
    public class BagCollection
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

        private List<(int, string, string)> GetOrCreateBag(string adjective, string color)
        {
            var key = (adjective, color);
            if (_bags.TryGetValue(key, out var contents)) return contents;
            return _bags[key] = new();
        }
    }
}
