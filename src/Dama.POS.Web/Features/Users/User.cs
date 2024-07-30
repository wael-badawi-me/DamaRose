namespace Dama.POS.Web.Features.Users;

public class User {
    public Guid Id { get; private set; }
    public string Username { get; private set; } = null!;
    public string Password { get; private set; } = null!;

    public static User Create(string Username, string Password)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace("Cannot be null or empty", nameof(Username));

        // TODO replace with number?
        ArgumentException.ThrowIfNullOrWhiteSpace("Cannot be null or empty", nameof(Password));

        return new User {
            Id = Guid.NewGuid(), // Replace with nano id for speed / tracking
            Username = Username,
            Password = Password
        };
    }
}
