using System.Collections.Generic;
using FluentAssertions;
using Wolfe.AdventOfCode._2020.Utils;
using Xunit;

namespace Wolfe.AdventOfCode._2020.Tests.Day01
{
    public class SumFinderTests
    {
        private static readonly List<int> SampleInput = new()
        {
            1721,
            979,
            366,
            299,
            675,
            1456
        };

        [Fact]
        public void FindPair_FindsPair()
        {
            var sumFinder = new SumFinder(SampleInput);
            var (a, b) = sumFinder.FindPair(2020);
            a.Should().Be(1721);
            b.Should().Be(299);
        }

        [Fact]
        public void FindTriplet_FindsTriplet()
        {
            var sumFinder = new SumFinder(SampleInput);
            var (a, b, c) = sumFinder.FindTriplet(2020);
            a.Should().Be(979);
            b.Should().Be(366);
            c.Should().Be(675);
        }
    }
}