using System.Linq.Expressions;
using Lemonade.Domain;

namespace Lemonade.Application;

public interface IRepository<T> where T : IEntity
{
    IUnitOfWork UnitOfWork { get; }
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
    Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
    Task AddAsync(T item, CancellationToken cancellationToken);
    T Remove(T item);
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
}