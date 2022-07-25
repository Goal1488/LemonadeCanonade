using System.Linq.Expressions;
using Lemonade.Application;
using Lemonade.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lemonade.Persistence.Repositories;

public class Repository<T> : IRepository<T> where T : class, IEntity
{
    public IUnitOfWork UnitOfWork { get; set; }
    protected readonly LemonadeContext LemonadeContext;

    protected Repository(IUnitOfWork unitOfWork, LemonadeContext lemonadeContext)
    {
        UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        LemonadeContext = lemonadeContext ?? throw new ArgumentNullException(nameof(lemonadeContext));
    }

    public async Task AddAsync(T item, CancellationToken cancellationToken)
    {
        item.Id = Guid.NewGuid();
        item.CreatedOn = DateTime.UtcNow;

        await LemonadeContext.Set<T>().AddAsync(item, cancellationToken);
    }

    public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        return LemonadeContext.Set<T>().AnyAsync(predicate, cancellationToken: cancellationToken);
    }

    public virtual Task<T?> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        return GetAggregateQueryable().FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public virtual Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        return GetAggregateQueryable().Where(predicate).ToListAsync(cancellationToken: cancellationToken);
    }

    public T Remove(T item)
    {
        return LemonadeContext.Set<T>().Remove(item).Entity;
    }

    protected virtual IQueryable<T> GetAggregateQueryable()
    {
        return LemonadeContext.Set<T>();
    }
}