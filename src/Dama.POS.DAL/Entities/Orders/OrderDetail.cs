using Dama.POS.DAL.Entities.Products;

namespace Dama.POS.DAL.Entities.Orders;

public class OrderDetail : BaseEntity {
    public string OrderId { get; set; } = null!;

    public string OrderStatusId { get; set; } = null!;

    public string ItemId { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal TotalCost { get; set; }

    public decimal TotalAmount { get; set; }

    public int? DiscountPercent { get; set; }

    public decimal? DiscountAmount { get; set; }

    public string? Note { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;

    public virtual OrderStatus OrderStatus { get; set; } = new();
}