using Dama.POS.DAL.Entities.Languages;

namespace Dama.POS.DAL.Entities.Products;

public class Category : BaseEntity {
    public string? ParentId { get; set; }

    public string NameId { get; set; } = null!;

    public string MenuId { get; set; } = null!;

    public bool IsEnabled { get; set; }

    public string? Photo { get; set; }

    public int SystemSequence { get; set; } = 0;

    public int CustomerSequence { get; set; } = 0;

    public virtual ICollection<Item> Items { get; set; } = [];

    public virtual Category? ParentCategory { get; set; }

    public virtual ICollection<Category> ChildCategories { get; set; } = [];

    public virtual ICollection<Translation> Translations { get; set; } = [];
}