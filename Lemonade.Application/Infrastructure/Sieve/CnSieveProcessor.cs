using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;

namespace Lemonade.Application.Infrastructure.Sieve;

public class LemonadeSieveProcessor : SieveProcessor
{
    public LemonadeSieveProcessor(IOptions<SieveOptions> options) : base(options) { }

    protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
    {
        mapper.ApplyConfiguration<LemonadeSieveConfiguration>();

        return mapper;
    }
}