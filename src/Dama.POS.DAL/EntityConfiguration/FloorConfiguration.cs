using Dama.POS.DAL.Entities.RestaurantLayout;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.POS.DAL.EntityConfiguration;

public class FloorConfiguration : IEntityTypeConfiguration<Floor> {
    public void Configure(EntityTypeBuilder<Floor> builder)
    {
        builder.HasKey(u => u.Id);

        builder.HasOne(u => u.CreatedByNavigation)
            .WithMany()
            .HasForeignKey(u => u.CreatedById);

        builder.HasOne(u => u.LastModifiedByNavigation)
            .WithMany()
            .HasForeignKey(u => u.LastModifiedById);

        builder.HasMany(i => i.Translations)
            .WithOne()
            .HasForeignKey(t => t.EntityId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(f => f.Tables)
            .WithOne(t => t.Floor)
            .HasForeignKey(t => t.FloorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
