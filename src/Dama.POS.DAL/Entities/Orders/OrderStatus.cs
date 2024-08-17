using Dama.POS.DAL.Entities.Languages;

namespace Dama.POS.DAL.Entities.Orders;

public class OrderStatus : BaseEntity {

    public string? Photo { get; set; }

    public virtual ICollection<Translation> Translations { get; set; } = [];
}

public enum OrderState {
    Open,
    Closed,
}