namespace Wolfe.AdventOfCode;

public static class Configuration
{
    public static IServiceCollection AddPuzzles<TMarker>(this IServiceCollection services) =>
        services.AddPuzzles(typeof(TMarker));

    public static IServiceCollection AddPuzzles(this IServiceCollection services, Type assemblyMarker)
    {
        var puzzleTypes = assemblyMarker.Assembly.GetTypes().Where(t => t.IsAssignableTo<IPuzzleDay>());

        foreach (var type in puzzleTypes)
        {
            services.AddTransient<IPuzzleDay>(type);
        }

        return services;
    }
}
