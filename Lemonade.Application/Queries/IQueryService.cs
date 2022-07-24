using System.Linq.Expressions;
using Lemonade.Domain;
using Lemonade.Domain.Shared;
using Sieve.Models;

namespace Lemonade.Application.Queries;

public interface IQueryService<TEntity, TModel> where TEntity : IEntity
{
    Task<ListResultsDto<TModel>> GetAsync(SieveModel sieveModel, CancellationToken cancellationToken);
    Task<TModel?> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    Task<TModel> GetAsync(Guid id, CancellationToken cancellationToken);
}