namespace Wolfe.AdventOfCode.Extensions;

public static class TypeExtensions
{
    public static bool IsAssignableTo<T>(this Type type) => type.IsAssignableTo(typeof(T));
}