using Lemonade.Application;
using Microsoft.EntityFrameworkCore;

namespace Lemonade.Persistence.Repositories;

public class LemonadeRepository : Repository<Lemonade.Domain.Entities.Lemonade>
{
    public LemonadeRepository(IUnitOfWork unitOfWork, LemonadeContext lemonadeContext)
        : base(unitOfWork, lemonadeContext)
    {
    }

    protected override IQueryable<Lemonade.Domain.Entities.Lemonade> GetAggregateQueryable() =>
        LemonadeContext.Lemonades.Include(x => x.AvailableSizes);
}