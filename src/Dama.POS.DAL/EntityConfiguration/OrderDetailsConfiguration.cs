using Dama.POS.DAL.Entities.Orders;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dama.POS.DAL.EntityConfiguration;
public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetail> {
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
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

        builder.HasOne(o => o.OrderStatus)
           .WithMany()
           .HasForeignKey(o => o.OrderStatusId)
           .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(od => od.Order)
            .WithMany(o => o.OrderDetails)
            .HasForeignKey(od => od.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(od => od.OrderStatus)
         .WithMany()
         .HasForeignKey(od => od.OrderStatusId)
         .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(od => od.Item)
           .WithMany()
           .HasForeignKey(od => od.ItemId)
           .OnDelete(DeleteBehavior.Restrict);
    }
}