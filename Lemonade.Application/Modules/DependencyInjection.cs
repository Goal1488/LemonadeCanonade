using Lemonade.Application.Infrastructure.Sieve;
using Lemonade.Application.Mappers;
using Lemonade.Application.Mappers.Lemonade;
using Lemonade.Application.Providers;
using Microsoft.Extensions.DependencyInjection;
using Sieve.Services;

namespace Lemonade.Application.Modules;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.Scan(i =>
            i.FromAssemblyOf<LemonadeMapper>()
                .AddClasses(c => c.AssignableTo(typeof(IMapper<,>)))
                .AsImplementedInterfaces()
                .WithSingletonLifetime()
        );

        services
            .AddScoped<ISieveProcessor, LemonadeSieveProcessor>()
            .AddScoped<LemonadeProvider>();

        return services;
    }
}