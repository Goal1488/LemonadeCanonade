using Lemonade.Domain;
using Lemonade.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lemonade.Persistence;

/// <inheritdoc />
public sealed class LemonadeContext : DbContext
{
    /// <summary>
    /// </summary>
    /// <param name="options"></param>
    public LemonadeContext(DbContextOptions options) : base(options)
    {
    }

    /// <summary>
    ///     Gets or sets Accounts
    /// </summary>
    public DbSet<Domain.Entities.Lemonade> Lemonades { get; set; }

    /// <summary>
    ///     Gets or sets Credits
    /// </summary>
    public DbSet<Order> Orders { get; set; }

    /// <summary>
    ///     Gets or sets Debits
    /// </summary>
    public DbSet<Customer> Customers { get; set; }

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