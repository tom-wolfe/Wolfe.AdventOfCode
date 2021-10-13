using Unity;
using Wolfe.AdventOfCode._2020.Day01;
using Wolfe.AdventOfCode.Common;

var container = new UnityContainer();
var parts = new List<IPuzzlePart>
{
    container.Resolve<Day01Part1>(),
    container.Resolve<Day01Part2>()
};

await Parallel.ForEachAsync(parts, async (part, cancellationToken) =>
{
    var result = await part.Solve(cancellationToken);
    Console.WriteLine($"Day {part.Day} Part {part.Part} Solution: {result}");
});

Console.ReadLine();