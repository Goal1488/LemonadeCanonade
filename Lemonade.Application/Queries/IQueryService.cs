using System.Linq.Expressions;
using Lemonade.Domain;

namespace Lemonade.Application.Queries
{
    public interface IQueryService<TEntity, TModel> where TEntity : IEntity
    {
        Task<TModel?> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TModel> GetById(Guid id);
    }
}