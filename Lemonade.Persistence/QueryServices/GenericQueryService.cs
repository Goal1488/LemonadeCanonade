using System.Linq.Expressions;
using Lemonade.Application.Mappers;
using Lemonade.Application.Queries;
using Lemonade.Domain;
using Lemonade.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Lemonade.Persistence.QueryServices;

public class GenericQueryService<TEntity, TModel>
    : IQueryService<TEntity, TModel>
    where TEntity : class, IEntity
{
    protected readonly LemonadeContext LemonadeContext;

    private readonly IMapper<TEntity, TModel> _mapper;

    protected GenericQueryService(LemonadeContext dbContext, IMapper<TEntity, TModel> mapper)
    {
        LemonadeContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public Task<TModel> GetById(Guid id)
    {
        return GetAsync(x => x.Id == id);
    }
    
    public virtual async Task<TModel?> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var aggregateRoot = await GetAggregateQueryable().FirstOrDefaultAsync(predicate);

        return aggregateRoot == null ? default : _mapper.Map(aggregateRoot);
    }

    public virtual async Task<ListResultsDto<TModel>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var aggregateRoot = await GetAggregateQueryable().Where(predicate).ToListAsync();

        return new ListResultsDto<TModel>
        {
            Items = aggregateRoot.Select(a => _mapper.Map(a)).ToList(),
            TotalCount = aggregateRoot.Count()
        };
    }

    protected virtual IQueryable<TEntity> GetAggregateQueryable()
    {
        return LemonadeContext.Set<TEntity>();
    }
}