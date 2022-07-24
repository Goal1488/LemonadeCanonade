using Lemonade.Application.Mappers;
using Lemonade.Application.Models;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;

namespace Lemonade.Persistence.QueryServices;

public class LemonadeQueryService : GenericQueryService<Domain.Entities.Lemonade, LemonadeModel>
{
    private readonly IMapper<Domain.Entities.Lemonade, LemonadeModel> _lemonadeMapper;

    public LemonadeQueryService(LemonadeContext dbContext,
        IMapper<Domain.Entities.Lemonade, LemonadeModel> lemonadeMapper,
        ISieveProcessor sieveProcessor)
        : base(dbContext, lemonadeMapper, sieveProcessor)
    {
        _lemonadeMapper = lemonadeMapper ?? throw new ArgumentNullException(nameof(lemonadeMapper));
    }

    protected override IQueryable<Domain.Entities.Lemonade> GetAggregateQueryable()
    {
        return LemonadeContext.Set<Domain.Entities.Lemonade>().Include(x => x.AvailableSizes);
    }
}