using Dama.POS.DAL.Entities.Products;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.POS.DAL.EntityConfiguration;

public class MenuConfiguration : IEntityTypeConfiguration<Menu> {
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.HasKey(u => u.Id);

        builder.HasOne(u => u.CreatedByNavigation)
            .WithMany()
            .HasForeignKey(u => u.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(u => u.LastModifiedByNavigation)
            .WithMany()
            .HasForeignKey(u => u.LastModifiedById)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(i => i.Translations)
            .WithOne()
            .HasForeignKey(t => t.EntityId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(m => m.Categories)
            .WithOne()
            .HasForeignKey(c => c.MenuId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
