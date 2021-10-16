using Wolfe.AdventOfCode.Common;
using Wolfe.AdventOfCode.Common.Extensions;

namespace Wolfe.AdventOfCode._2020.Puzzles
{
    internal class Day06 : IPuzzleDay
    {
        public int Day { get; } = 6;

        private static readonly Lazy<List<Group>> LazyGroups = new(() => ParseGroups(File.ReadAllText("./Inputs/Day06.txt")));
        private static List<Group> Groups => LazyGroups.Value;

        public Task<string> Part1(CancellationToken cancellationToken = default)
        {
            var sum = Groups.Sum(g => g.People.SelectMany(p => p.Answers).Distinct().Count());
            return Task.FromResult(sum.ToString());
        }

        public Task<string> Part2(CancellationToken cancellationToken = default)
        {
            return Task.FromResult("");
        }

        private static List<Group> ParseGroups(string input)
        {
            var groups = input.GroupLines();
            return groups
                .Select(lines => lines.Select(line => new Person(line)))
                .Select(people => new Group(people.ToList())).ToList();
        }

        private record Group(List<Person> People);
        private record Person(string Answers);
    }
}

