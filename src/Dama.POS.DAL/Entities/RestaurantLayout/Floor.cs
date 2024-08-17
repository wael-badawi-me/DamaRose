using Dama.POS.DAL.Entities.Languages;

namespace Dama.POS.DAL.Entities.RestaurantLayout;

public class Floor : BaseEntity {
    public string? Photo { get; set; }

    public bool IsEnabled { get; set; }

    public virtual ICollection<Translation> Translations { get; set; } = [];

    public virtual ICollection<Table> Tables { get; set; } = [];
}