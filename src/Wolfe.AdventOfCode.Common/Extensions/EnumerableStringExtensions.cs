namespace Wolfe.AdventOfCode.Extensions;

public static class EnumerableStringExtensions
{
    public static string Join(this IEnumerable<string> input, string? separator = null) => string.Join(separator, input);
}
