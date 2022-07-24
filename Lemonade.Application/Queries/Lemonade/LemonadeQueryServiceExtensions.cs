using Lemonade.Application.Models;

namespace Lemonade.Application.Queries.Lemonade;

public static class LemonadeQueryServiceExtensions
{
    public static Task<LemonadeModel> GetById(this IQueryService<Domain.Entities.Lemonade, LemonadeModel> queryService,
        Guid id, CancellationToken cancellationToken)
    {
        return queryService.GetAsync(id, cancellationToken);
    }
}