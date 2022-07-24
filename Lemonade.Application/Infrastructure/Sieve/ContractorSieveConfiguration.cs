using Sieve.Services;

namespace Lemonade.Application.Infrastructure.Sieve;

public class LemonadeSieveConfiguration : ISieveConfiguration
{
    public void Configure(SievePropertyMapper mapper)
    {
        mapper.Property<Domain.Entities.Lemonade>(z => z.CreatedOn)
            .CanSort()
            .CanFilter();

        mapper.Property<Domain.Entities.Lemonade>(z => z.Name)
            .CanFilter();
    }
}