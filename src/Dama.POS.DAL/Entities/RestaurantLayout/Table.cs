using Dama.POS.DAL.Entities.Languages;

namespace Dama.POS.DAL.Entities.RestaurantLayout;

public class Table : BaseEntity {
    public string FloorId { get; set; } = null!;

    public string? Photo { get; set; }

    public bool IsEnabled { get; set; }

    public int PhotoLocationX { get; set; }

    public int PhotoLocationY { get; set; }

    public virtual Floor Floor { get; set; } = null!;

    public virtual ICollection<Translation> Translations { get; set; } = [];
}