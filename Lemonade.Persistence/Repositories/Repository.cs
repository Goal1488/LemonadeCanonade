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

    public void Add(T item)
    {
        item.Id = Guid.NewGuid();
        item.CreatedOn = DateTime.UtcNow;

        LemonadeContext.Set<T>().Add(item);
    }

    public Task<bool> Any(Expression<Func<T, bool>> predicate)
    {
        return LemonadeContext.Set<T>().AnyAsync(predicate);
    }

    public virtual Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
    {
        return GetAggregateQueryable().FirstOrDefaultAsync(predicate);
    }

    public virtual Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate)
    {
        return GetAggregateQueryable().Where(predicate).ToListAsync();
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