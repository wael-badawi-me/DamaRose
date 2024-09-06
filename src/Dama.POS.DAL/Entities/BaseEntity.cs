using Dama.POS.DAL.Entities.Users;
using static BTSID.BTSID;
namespace Dama.POS.DAL.Entities;

public abstract class BaseEntity {
    public string Id { get;  set; }

    public string Name { get;  set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime LastModifiedDate { get; set; }

    public string CreatedById { get; set; } = null!;

    public string LastModifiedById { get; set; } = null!;

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual User LastModifiedByNavigation { get; set; } = null!;

    protected BaseEntity()
    {
        Id = NewBase36Number(BTSID.NumberMode.Compressed);
        CreatedDate = DateTime.Now;
        LastModifiedDate = DateTime.Now;
        CreatedById = Id;
        LastModifiedById = Id;
    }
}
