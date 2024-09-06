namespace Dama.POS.DAL.Entities.Languages;

public class Language : BaseEntity {

    public string Photo { get; set; } = null!;

    public bool IsEnabled { get; set; }

    public bool IsDefault { get; set; }
}