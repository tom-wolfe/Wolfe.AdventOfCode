namespace Wolfe.AdventOfCode.Extensions;

public static class EnumerableExtensions
{
    public static void Deconstruct<T>(this IEnumerable<T> source, out T v1)
    {
        using var e = source.GetEnumerator();
        e.MoveNext();
        v1 = e.Current;
    }

    public static void Deconstruct<T>(this IEnumerable<T> source, out T v1, out T v2)
    {
        using var e = source.GetEnumerator();
        e.MoveNext();
        v1 = e.Current;
        e.MoveNext();
        v2 = e.Current;
    }
}
