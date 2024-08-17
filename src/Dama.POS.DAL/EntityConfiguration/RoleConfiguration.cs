using Dama.POS.DAL.Entities.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.POS.DAL.EntityConfiguration;

public class RoleConfiguration : IEntityTypeConfiguration<Role> {
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(u => u.Id);

        builder.HasOne(u => u.CreatedByNavigation)
            .WithMany()
            .HasForeignKey(u => u.CreatedById);

        builder.HasOne(u => u.LastModifiedByNavigation)
            .WithMany()
            .HasForeignKey(u => u.LastModifiedById);
    }
}
