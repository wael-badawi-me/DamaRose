namespace Dama.POS.DAL.Entities.Users;
public class Role : BaseEntity {
    public static Role Create(string Name)
    {
        return new Role {
            Name = Name
        };
    }
}
