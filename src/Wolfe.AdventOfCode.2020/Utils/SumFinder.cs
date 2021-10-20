namespace Wolfe.AdventOfCode._2020.Utils
{
    public class SumFinder
    {
        private readonly IEnumerable<int> _source;

        public SumFinder(IEnumerable<int> source)
        {
            _source = source;
        }

        public (int, int) FindPair(int sum)
        {
            var abPairs = new Dictionary<int, int>();
            foreach (var a in _source)
            {
                var b = sum - a;
                if (abPairs.ContainsKey(b))
                    return (b, abPairs[b]);
                abPairs[a] = b;
            }

            throw new Exception("No matching pair found");
        }

        public (int, int, int) FindTriplet(int sum)
        {

            foreach (var a in _source)
            {
                foreach (var b in _source)
                {
                    var c = sum - (a + b);
                    if (c <= 0) { continue; }
                    if (_source.Contains(c)) { return (a, b, c); }
                }
            }
            throw new Exception("No matching triplet found");
        }
    }
}
