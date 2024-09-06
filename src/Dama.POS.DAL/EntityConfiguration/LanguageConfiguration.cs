using Dama.POS.DAL.Entities.Languages;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.POS.DAL.EntityConfiguration;
public class LanguageConfiguration : IEntityTypeConfiguration<Language> {
    public void Configure(EntityTypeBuilder<Language> builder)
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
    }
}