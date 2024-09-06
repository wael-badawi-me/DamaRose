using Dama.POS.DAL.Entities.Languages;
using Dama.POS.DAL.Entities.RestaurantLayout;

namespace Dama.POS.DAL.Entities.Products;

public class Item : BaseEntity {
    public string CategoryId { get; set; } = null!;

    public string LocationId { get; set; } = null!;

    public string NameId { get; set; } = null!;

    public decimal Cost { get; set; }

    public decimal Price { get; set; }

    public string? Photo { get; set; }

    public int SystemSequence { get; set; } = 0;

    public int CustomerSequence { get; set; } = 0;

    public bool IsEnabled { get; set; }

    public bool IsPromo { get; set; }

    public int? DiscountPercent { get; set; }

    public decimal? DiscountAmount { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Location Location { get; set; } = null!;

    public virtual ICollection<Translation> Translations { get; set; } = [];

}