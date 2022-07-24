using Lemonade.Application.Models;
using Lemonade.Application.Queries;
using Lemonade.Domain.Shared;
using Sieve.Models;

namespace Lemonade.Application.Providers;

public class LemonadeProvider
{
    private IRepository<Domain.Entities.Lemonade> LemonadeRepository { get; }
    private IQueryService<Domain.Entities.Lemonade, LemonadeModel> LemonadeQueryService { get; }

    public LemonadeProvider(
        IRepository<Lemonade.Domain.Entities.Lemonade> lemonadeRepository,
        IQueryService<Lemonade.Domain.Entities.Lemonade, LemonadeModel> lemonadeQueryService)
    {
        LemonadeRepository = lemonadeRepository;
        LemonadeQueryService = lemonadeQueryService;
    }

    public async Task<Guid> CreateAsync(LemonadeModel lemonadeModel, CancellationToken cancellationToken)
    {
        var lemonadeEntity = new Lemonade.Domain.Entities.Lemonade(lemonadeModel.Name);

        foreach (var lemonadeSize in lemonadeModel.AvailableSizes)
        {
            lemonadeEntity.AddOrUpdateSize(lemonadeSize.Size, lemonadeSize.Price);
        }

        LemonadeRepository.Add(lemonadeEntity);

        await LemonadeRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return lemonadeEntity.Id;
    }

    public Task<ListResultsDto<LemonadeModel>> GetAsync(SieveModel sieveModel, CancellationToken cancellationToken)
    {
        return LemonadeQueryService.GetAsync(sieveModel, cancellationToken);
    }
}