using System.Linq.Expressions;
using Lemonade.Application.Mappers;
using Lemonade.Application.Queries;
using Lemonade.Domain;
using Lemonade.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace Lemonade.Persistence.QueryServices;

public class GenericQueryService<TEntity, TModel>
    : IQueryService<TEntity, TModel>
    where TEntity : class, IEntity
{
    protected readonly LemonadeContext LemonadeContext;

    private readonly IMapper<TEntity, TModel> _mapper;
    private readonly ISieveProcessor _sieveProcessor;

    protected GenericQueryService(LemonadeContext dbContext,
        IMapper<TEntity, TModel> mapper,
        ISieveProcessor sieveProcessor)
    {
        LemonadeContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _sieveProcessor = sieveProcessor;
    }

    public Task<TModel> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return GetAsync(x => x.Id == id, cancellationToken);
    }

    public virtual async Task<TModel?> GetAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken)
    {
        var aggregateRoot = await GetAggregateQueryable().FirstOrDefaultAsync(predicate, cancellationToken);

        return aggregateRoot == null ? default : _mapper.Map(aggregateRoot);
    }

    public virtual async Task<ListResultsDto<TModel>> GetAsync(SieveModel sieveModel,
        CancellationToken cancellationToken)
    {
        var aggregates = GetAggregateQueryable().AsNoTracking();

        var filteredList = await _sieveProcessor.Apply(sieveModel, aggregates)
            .ToListAsync(cancellationToken: cancellationToken);

        var total = _sieveProcessor.Apply(sieveModel, aggregates, applySorting: false, applyPagination: false);

        return new ListResultsDto<TModel>
        {
            Items = filteredList.Select(_mapper.Map).ToList(),
            TotalCount = await total.CountAsync(cancellationToken: cancellationToken)
        };
    }

    protected virtual IQueryable<TEntity> GetAggregateQueryable()
    {
        return LemonadeContext.Set<TEntity>();
    }
}