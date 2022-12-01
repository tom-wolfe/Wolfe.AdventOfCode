namespace Wolfe.AdventOfCode.Y2020.Puzzles;

internal class Day06 : IPuzzleDay
{
    public int Day => 6;

    public Task<string> Part1(string? input, CancellationToken cancellationToken = default)
    {
        var groups = ParseGroups(input);
        var sum = groups.Sum(g => g.People.SelectMany(p => p.Answers).Distinct().Count());
        return Task.FromResult(sum.ToString());
    }

    public Task<string> Part2(string? input, CancellationToken cancellationToken = default)
    {
        var groups = ParseGroups(input);
        var sum = groups.Sum(g => g.People[0].Answers.Count(a => g.People.All(p => p.Answers.Contains(a))));
        return Task.FromResult(sum.ToString());
    }

    private static List<Group> ParseGroups(string? input)
    {
        var groups = input.GroupLines();
        return groups
            .Select(lines => lines.Select(line => new Person(line)))
            .Select(people => new Group(people.ToList())).ToList();
    }

    private record Group(List<Person> People);
    private record Person(string Answers);
}