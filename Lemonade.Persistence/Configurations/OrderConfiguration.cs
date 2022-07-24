using Lemonade.Domain;
using Lemonade.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lemonade.Persistence.Configurations;

public class OrderAggregateConfiguration : IEntityTypeConfiguration<Order>
{
    /// <summary>
    ///     Configure Account.
    /// </summary>
    /// <param name="builder">Builder.</param>
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        builder.ToTable("Order");
    }
}