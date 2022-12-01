using FluentAssertions;
using Wolfe.AdventOfCode._2020.Utils;
using Xunit;

namespace Wolfe.AdventOfCode._2020.Tests
{
    public class TreeMapTests
    {
        private static readonly TreeMap TreeMap = new(new[]
        {
            "..##.......",
            "#...#...#..",
            ".#....#..#.",
            "..#.#...#.#",
            ".#...##..#.",
            "..#.##.....",
            ".#.#.#....#",
            ".#........#",
            "#.##...#...",
            "#...##....#",
            ".#..#...#.#"
        });

        [Fact]
        public void CountTrees_Once()
        {
            var answer = TreeMap.CountTrees(3, 1);
            answer.Should().Be(7);
        }

        [Fact]
        public void CountTrees_Many()
        {
            var a = TreeMap.CountTrees(1, 1);
            var b = TreeMap.CountTrees(3, 1);
            var c = TreeMap.CountTrees(5, 1);
            var d = TreeMap.CountTrees(7, 1);
            var e = TreeMap.CountTrees(1, 2);

            (a * b * c * d * e).Should().Be(336);
        }
    }
}