using Dama.POS.DAL.Entities.Languages;

namespace Dama.POS.DAL.Entities.Products;

public class Menu : BaseEntity {
    public string? Photo { get; set; }

    public bool IsEnabled { get; set; }

    public virtual ICollection<Translation> Translations { get; set; } = [];

    public virtual ICollection<Category> Categories { get; set; } = [];
}