namespace Dama.POS.DAL.Entities.Languages;
public class Translation : BaseEntity {
    public string LanguageId { get; set; } = null!;

    public string EntityId { get; set; } = null!;

    public string EntityType { get; set; } = null!;

    public bool IsEnabled { get; set; }
}