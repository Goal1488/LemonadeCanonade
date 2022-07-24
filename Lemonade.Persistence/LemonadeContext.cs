using Lemonade.Domain.CustomerAggregate;
using Lemonade.Domain.OrderAggregate;
using Microsoft.EntityFrameworkCore;

namespace Lemonade.Persistence;

/// <inheritdoc />
public sealed class LemonadeContext : DbContext
{
    /// <summary>
    /// </summary>
    /// <param name="options"></param>
    public LemonadeContext(DbContextOptions options)
        : base(options)
    {
    }

    /// <summary>
    ///     Gets or sets Accounts
    /// </summary>
    public DbSet<Domain.Lemonade> Lemonades { get; set; }

    /// <summary>
    ///     Gets or sets Credits
    /// </summary>
    public DbSet<OrderAggregate> Credits { get; set; }

    /// <summary>
    ///     Gets or sets Debits
    /// </summary>
    public DbSet<CustomerAggregate> Customer { get; set; }

    /// <summary>
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (modelBuilder is null)
        {
            throw new ArgumentNullException(nameof(modelBuilder));
        }

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LemonadeContext).Assembly);
        
        //TODO: add initial data
    }
}