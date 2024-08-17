using Dama.POS.DAL.Entities.Orders;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.POS.DAL.EntityConfiguration;

public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus> {
    public void Configure(EntityTypeBuilder<OrderStatus> builder)
    {
        builder.HasKey(u => u.Id);

        builder.HasOne(u => u.CreatedByNavigation)
            .WithMany()
            .HasForeignKey(u => u.CreatedById);

        builder.HasOne(u => u.LastModifiedByNavigation)
            .WithMany()
            .HasForeignKey(u => u.LastModifiedById);

        builder.HasMany(u => u.Translations)
            .WithOne()
            .HasForeignKey(u => u.EntityId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
