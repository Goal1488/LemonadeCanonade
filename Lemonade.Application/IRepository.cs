using System.Linq.Expressions;
using Lemonade.Domain;

namespace Lemonade.Application;

public interface IRepository<T> where T : IEntity
{
    IUnitOfWork UnitOfWork { get; }
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
    Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate);
    void Add(T item);
    T Remove(T item);
    Task<bool> Any(Expression<Func<T, bool>> predicate);
}