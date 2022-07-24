using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lemonade.Persistence.Configurations;

public class LemonadeConfiguration : IEntityTypeConfiguration<Domain.Entities.Lemonade>
{
    /// <summary>
    ///     Configure Account.
    /// </summary>
    /// <param name="builder">Builder.</param>
    public void Configure(EntityTypeBuilder<Domain.Entities.Lemonade> builder)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        builder.ToTable("Lemonade");

        builder.HasMany(x => x.AvailableSizes)
            .WithOne(b => b.Lemonade!)
            .HasForeignKey(b => b.LemonadeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}