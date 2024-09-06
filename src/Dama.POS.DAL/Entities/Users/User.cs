namespace Dama.POS.DAL.Entities.Users;

public class User : BaseEntity {
    public string Password { get;  set; } = null!;

    public bool IsEnabled { get;  set; }

    public static User Create(string Name, string Password)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace("Cannot be null or empty", nameof(Name));
        ArgumentException.ThrowIfNullOrWhiteSpace("Cannot be null or empty", nameof(Password)); // TODO replace with number easy to login 123

        return new User {

            Name = Name,
            Password = Password,
            IsEnabled = true
        };
    }

    public void Edit(string name, bool isEnabled)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(Name));

        Name = name;
        IsEnabled = isEnabled;
    }
}
