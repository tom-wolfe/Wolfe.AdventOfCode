namespace Wolfe.AdventOfCode.Extensions;

public static class TExtensions
{
    public static Task<T> ToTask<T>(this T input) => Task.FromResult(input);
}