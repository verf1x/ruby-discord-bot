using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using RubyBot.Application.Abstrcations;

namespace RubyBot.Application.Extensions;

public static class HandlersExtensions
{
    public static IServiceCollection AddHandlers(
        this IServiceCollection services,
        IEnumerable<Assembly> assemblies)
    {
        services.Scan(scan => scan.FromAssemblies(assemblies)
            .AddClasses(classes => classes
                .AssignableToAny(typeof(ICommandHandler<,>), typeof(ICommandHandler<>)))
            .AsSelfWithInterfaces()
            .WithScopedLifetime());

        return services;
    }
}