using System.Collections.Generic;
using System.Runtime.InteropServices;
using FluentAssertions;
using Wolfe.AdventOfCode._2020.Day01;
using Xunit;

namespace Wolfe.AdventOfCode._2020.Tests.Day01
{
    public class SumFinderTests
    {
        [Fact]
        public void Test1()
        {
            var sumFinder = new SumFinder(new List<int>()
            {
                1721,
                979,
                366,
                299,
                675,
                1456
            });
            var pair = sumFinder.FindPair(2020);
            pair.Item1.Should().Be(1721);
            pair.Item2.Should().Be(299);
        }
    }
}