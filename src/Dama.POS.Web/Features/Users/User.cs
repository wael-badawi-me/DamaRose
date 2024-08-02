namespace Dama.POS.Web.Features.Users;

public class User {
    public Guid Id { get; private set; }
    public string Username { get; private set; } = null!;
    public string Password { get; private set; } = null!;

    public static User Create(string Username, string Password)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace("Cannot be null or empty", nameof(Username));
        ArgumentException.ThrowIfNullOrWhiteSpace("Cannot be null or empty", nameof(Password)); // TODO replace with number easy to login 123

        return new User {
            Id = Guid.NewGuid(), // Replace with nano id for speed / tracking
            Username = Username,
            Password = Password
        };
    }

    public void Edit(string username)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(username, nameof(Username));

        Username = username;
    }
}
