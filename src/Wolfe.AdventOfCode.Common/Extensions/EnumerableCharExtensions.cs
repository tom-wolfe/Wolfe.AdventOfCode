namespace Wolfe.AdventOfCode.Extensions;

public static class EnumerableCharExtensions
{
    public static string Join(this IEnumerable<char> chars) => new(chars.ToArray());
}
