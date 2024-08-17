﻿using Dama.POS.DAL.Entities.RestaurantLayout;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.POS.DAL.EntityConfiguration;

public class LocationConfiguration : IEntityTypeConfiguration<Location> {
    public void Configure(EntityTypeBuilder<Location> builder)
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
    }
}