using Lemonade.Application;
using Lemonade.Application.Models;
using Lemonade.Application.Queries;
using Lemonade.Persistence.QueryServices;
using Lemonade.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lemonade.Persistence.Modules;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddScoped(typeof(IQueryService<,>), typeof(GenericQueryService<,>))
            .AddScoped<IQueryService<Domain.Entities.Lemonade, LemonadeModel>, LemonadeQueryService>();

        services
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped(typeof(IRepository<>), typeof(Repository<>))
            .AddScoped<IRepository<Domain.Entities.Lemonade>, LemonadeRepository>();
            
        services.AddDbContext<LemonadeContext>(
            options => options.UseSqlServer(
                configuration.GetValue<string>("PersistenceModule:DefaultConnection")));
            
        return services;
    }
}