using Dama.POS.DAL.Entities.Products;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.POS.DAL.EntityConfiguration;

public class ItemConfiguration : IEntityTypeConfiguration<Item> {
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.HasKey(u => u.Id);

        builder.HasOne(u => u.CreatedByNavigation)
            .WithMany()
            .HasForeignKey(u => u.CreatedById);

        builder.HasOne(u => u.LastModifiedByNavigation)
            .WithMany()
            .HasForeignKey(u => u.LastModifiedById);

        builder.HasOne(i => i.Category)
               .WithMany(c => c.Items)
               .HasForeignKey(i => i.CategoryId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(i => i.Translations)
            .WithOne()
            .HasForeignKey(t => t.EntityId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(i => i.Location)
            .WithMany()
            .HasForeignKey(l => l.LocationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
