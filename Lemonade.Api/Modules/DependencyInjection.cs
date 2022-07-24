using FluentValidation;
using Lemonade.Api.Mappers.Lemonade;
using Lemonade.Api.Validators;
using Lemonade.Application.Mappers;

namespace Lemonade.Api.Modules;

public static class DependencyInjection
{
    public static IServiceCollection AddApiLayer(this IServiceCollection services)
    {
        services.Scan(i =>
            i.FromAssemblyOf<LemonadeCreateViewModelValidator>()
                .AddClasses(c => c.AssignableTo(typeof(IValidator<>)))
                .AsSelf()
                .WithSingletonLifetime()
        );

        services.Scan(i =>
            i.FromAssemblyOf<LemonadeMapper>()
                .AddClasses(c => c.AssignableTo(typeof(IMapper<,>)))
                .AsImplementedInterfaces()
                .WithSingletonLifetime()
        );

        return services;
    }
}