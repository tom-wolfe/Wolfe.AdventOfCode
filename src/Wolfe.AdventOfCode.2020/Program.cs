using Unity;
using Wolfe.AdventOfCode._2020.Puzzles;
using Wolfe.AdventOfCode.Common;

var container = new UnityContainer();
var days = new List<IPuzzleDay>
{
    container.Resolve<Day01>(),
    container.Resolve<Day02>(),
    container.Resolve<Day03>(),
    container.Resolve<Day04>()
};

var puzzleDays = days
    .Select(day => new KeyValuePair<int, (Task<string>, Task<string>)>(day.Day, (day.Part1(), day.Part2())))
    .OrderBy(d => d.Key);

foreach (var (day, (part1, part2)) in puzzleDays)
{
    Console.WriteLine($"Day {day}:");
    Console.WriteLine($"  Part 1 Solution: {await part1}");
    Console.WriteLine($"  Part 2 Solution: {await part2}");
    Console.WriteLine();
}

Console.ReadLine();