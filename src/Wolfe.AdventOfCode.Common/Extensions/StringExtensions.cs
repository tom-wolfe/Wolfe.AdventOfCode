namespace Wolfe.AdventOfCode.Extensions;

public static class StringExtensions
{
    public static IEnumerable<string> SplitByLength(this string input, int size) => input.Chunk(size).Select(c => c.Join());

    public static int ToBinary(this string input, char one, char zero)
    {
        var binString = input.Replace(one, '1').Replace(zero, '0');
        return Convert.ToInt32(binString, 2);
    }

    public static IEnumerable<string> ToLines(this string? input) =>
        string.IsNullOrEmpty(input) ? Enumerable.Empty<string>() : input.Split(Environment.NewLine);

    public static List<List<string>> GroupLines(this string? input) =>
        GroupLines(input.ToLines());

    public static List<List<string>> GroupLines(this IEnumerable<string> lines)
    {
        var result = new List<List<string>>();
        var group = new List<string>();
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                result.Add(group);
                group = new List<string>();
            }
            else
                group.Add(line);
        }
        if (group.Any()) { result.Add(group); }
        return result;
    }

    public static Dictionary<char, int> CharacterFrequency(this string? input)
    {
        var result = new Dictionary<char, int>();
        foreach(var c in input ?? "")
        {
            if (!result.ContainsKey(c))
            {
                result.Add(c, 0);
            }
            result[c]++;
        }
        return result;
    }

    public static string CaesarShift(this string? input, int distance) => (input ?? "")
        .Select(c => c.CaesarShift(distance))
        .Join();
}
