namespace PhoenixIot.Core.Entities;

public class User : BaseEntity
{
    public User(string username, string password, DateTime now)
    {
        Username = username;
        Password = password;
        CreatedAt = now;
    }

    protected User()
    {
    }

    public string Username { get; set; }
    public string Password { get; set; }
    public List<Device> Devices { get; set; } = new();
    public List<Role> Roles { get; set; } = new();
}