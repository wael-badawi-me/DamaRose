﻿using Dama.POS.DAL.Entities.RestaurantLayout;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.POS.DAL.EntityConfiguration;

public class TableConfiguration : IEntityTypeConfiguration<Table> {
    public void Configure(EntityTypeBuilder<Table> builder)
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

        builder.HasOne(t => t.Floor)
            .WithMany(f => f.Tables)
            .HasForeignKey(t => t.FloorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}