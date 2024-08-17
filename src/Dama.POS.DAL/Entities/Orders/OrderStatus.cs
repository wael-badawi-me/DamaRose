using Dama.POS.DAL.Entities.Languages;

namespace Dama.POS.DAL.Entities.Orders;

public class OrderStatus : BaseEntity {

    public string? Photo { get; set; }

    public virtual ICollection<Translation> Translations { get; set; } = [];
}

public enum Status {
    Pending, // Same for order and details (waiting for kitchen approval) we will do this later (1 or more times pending)
    Preparing, // same for order and order details preparing = cooking part of the order (1 or more items preparing)
    Complete, // for order details complete = sent out and for order complete = paid
    Open, // only for order Open = complete but not paid
}