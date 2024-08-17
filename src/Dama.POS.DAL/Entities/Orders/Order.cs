using Dama.POS.DAL.Entities.RestaurantLayout;
using Dama.POS.DAL.Entities.Users;

namespace Dama.POS.DAL.Entities.Orders;

public class Order : BaseEntity {
    public string TableId { get; set; } = null!;

    public string OrderStatusId { get; set; } = null!;

    public string OrderLanguageId { get; set; } = null!;

    public string PrintLanguageId { get; set; } = null!;

    public string? Note { get; set; }

    public string? PaymentReceivedById { get; set; }

    public int DiscountPercent { get; set; } = 0;

    public decimal DiscountAmount { get; set; } = 0.00m;

    public decimal TotalAmount { get; set; }

    public virtual OrderStatus OrderStatus { get; set; } = new();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = [];

    public virtual User? PaymentReceivedByNavigation { get; set; }

    public virtual Table Table { get; set; } = null!;
}