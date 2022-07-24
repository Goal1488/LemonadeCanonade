using Lemonade.Domain;
using Lemonade.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lemonade.Persistence.Configurations;

public class OrderDetailAggregateConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    /// <summary>
    ///     Configure Account.
    /// </summary>
    /// <param name="builder">Builder.</param>
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        builder.ToTable("OrderDetail");

        builder.Property(x => x.Price).IsRequired();
    }
}