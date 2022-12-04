namespace Wolfe.AdventOfCode.Helpers
{
    public class FuncHelpers
    {
        public static Func<(T1, T2), TOutput> Gather<T1, T2, TOutput>(Func<T1, T2, TOutput> func) => t => func(t.Item1, t.Item2);
    }
}
