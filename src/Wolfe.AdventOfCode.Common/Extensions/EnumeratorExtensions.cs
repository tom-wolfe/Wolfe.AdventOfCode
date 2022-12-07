using Wolfe.AdventOfCode.Helpers;

namespace Wolfe.AdventOfCode.Extensions;

public static class EnumeratorExtensions
{
    public static SneakyEnumerator<T> ToSneakyEnumerator<T>(this IEnumerator<T> source) => new(source);

    public static T? GetNext<T>(this IEnumerator<T> source) => source.MoveNext() ? source.Current : default;
}
