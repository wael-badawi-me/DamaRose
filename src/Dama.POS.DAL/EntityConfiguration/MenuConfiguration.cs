using Dama.POS.DAL.Entities.Products;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.POS.DAL.EntityConfiguration;

public class MenuConfiguration : IEntityTypeConfiguration<Menu> {
    public void Configure(EntityTypeBuilder<Menu> builder)
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

        builder.HasMany(m => m.Categories)
            .WithOne()
            .HasForeignKey(c => c.MenuId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
