namespace Wolfe.AdventOfCode.Helpers;

public static class PuzzleInput
{
    public static async Task<string?> GetPuzzleInput(int day, int part)
    {
        var path = GetInputPaths(day, part).FirstOrDefault(File.Exists);
        if (path == null)
        {
            return null;
        }

        var contents = await File.ReadAllTextAsync(path);
        return contents.Trim(Environment.NewLine.ToArray());
    }

    private static IEnumerable<string> GetInputPaths(int day, int part)
    {
        yield return string.Format($"./Inputs/Day{day:D2}/Part{part}.txt");
        yield return string.Format($"./Inputs/Day{day:D2}.txt");
    }
}
