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

    public static void Deconstruct<T>(this IEnumerable<T> source, out T v1, out T v2, out T v3)
    {
        using var e = source.GetEnumerator();
        e.MoveNext();
        v1 = e.Current;
        e.MoveNext();
        v2 = e.Current;
        e.MoveNext();
        v3 = e.Current;
    }

    public static (T, T) ToTuple2<T>(this IEnumerable<T> source)
    {
        source.Deconstruct(out var v1, out var v2);
        return (v1, v2);
    }

    public static (T, T, T) ToTuple3<T>(this IEnumerable<T> source)
    {
        source.Deconstruct(out var v1, out var v2, out var v3);
        return (v1, v2, v3);
    }
}
