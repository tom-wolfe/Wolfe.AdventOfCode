namespace Wolfe.AdventOfCode.Helpers;

public static class PuzzleInput
{
    public static async Task<string?> GetPuzzleInput(int day, int part)
    {
        var inputPath = GetInputPath(day, part);
        if (!File.Exists(inputPath))
        {
            return null;
        }
        return await File.ReadAllTextAsync(GetInputPath(day, part));
    }

    private static string GetInputPath(int day, int part) => string.Format($"./Inputs/Day{day:D2}/Part{part}.txt");
}
