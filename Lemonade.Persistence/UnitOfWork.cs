using Lemonade.Application;

namespace Lemonade.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly LemonadeContext _cnContext;

    public UnitOfWork(LemonadeContext cnContext)
    {
        _cnContext = cnContext;
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _cnContext.SaveChangesAsync(cancellationToken);
    }
}