using Dama.POS.DAL.Entities.Languages;

namespace Dama.POS.DAL.Entities.RestaurantLayout;

public class Location : BaseEntity {
    public string PrinterIP { get; set; } = null!;

    public string? Photo { get; set; }

    public bool IsEnabled { get; set; }

    public virtual ICollection<Translation> Translations { get; set; } = [];
}

