using Dama.POS.DAL.Entities.Users;
using static BTSID.BTSID;
namespace Dama.POS.DAL.Entities;

public abstract class BaseEntity {
    public string Id { get; private set; }

    public string Name { get; protected set; } = null!;

    public string? Description { get; protected set; }

    public DateTime CreatedDate { get; protected set; }

    public DateTime LastModifiedDate { get; protected set; }

    public string CreatedById { get; protected set; } = null!;

    public string LastModifiedById { get; protected set; } = null!;

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
