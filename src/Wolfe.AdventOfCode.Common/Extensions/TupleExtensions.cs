namespace Wolfe.AdventOfCode.Extensions;

public static class TupleTExtensions
{
    public static void Scatter<T1, T2>(this (T1, T2) tuple, Action<T1, T2> action) => action(tuple.Item1, tuple.Item2);

    public static TOutput Scatter<T1, T2, TOutput>(this (T1, T2) tuple, Func<T1, T2, TOutput> func) => func(tuple.Item1, tuple.Item2);

}