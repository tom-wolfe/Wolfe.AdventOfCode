namespace Wolfe.AdventOfCode.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTransient<T>(this IServiceCollection services, Type implementationType) =>
        services.AddTransient(typeof(T), implementationType);
}