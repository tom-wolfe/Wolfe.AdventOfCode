namespace Wolfe.AdventOfCode.Helpers;

public static class PuzzleRunner
{
    public static async Task RunPuzzles<TMarker>()
    {
        var provider = new ServiceCollection()
            .AddPuzzles<TMarker>()
            .BuildServiceProvider();

        var puzzles = provider
            .GetServices<IPuzzleDay>()
            .OrderBy(p => p.Day)
            .ToList();

        foreach (var puzzle in puzzles)
        {
            var input1 = PuzzleInput.GetPuzzleInput(puzzle.Day, 1);
            var input2 = PuzzleInput.GetPuzzleInput(puzzle.Day, 2);

            var part1 = puzzle.Part1((await input1) ?? "");
            var part2 = puzzle.Part2((await input2) ?? "");

            var answer1 = await part1;
            var answer2 = await part2;

            Console.WriteLine($"Day {puzzle.Day}:");

            Console.Write("  Part 1: ");
            if (answer1.Contains(Environment.NewLine))
            {
                Console.WriteLine();
            }
            Console.WriteLine(answer1);


            Console.Write("  Part 2: ");
            if (answer2.Contains(Environment.NewLine))
            {
                Console.WriteLine();
            }
            Console.WriteLine(answer2);
        }

        Console.ReadLine();
    }

}
