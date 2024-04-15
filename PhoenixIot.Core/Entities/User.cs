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
    public ICollection<Device> Devices { get; set; } = new List<Device>();
    public ICollection<Role> Roles { get; set; } = new List<Role>();

    public void AssignNewDevice(Device device, DateTime utcNow)
    {
        Devices.Add(device);
        UpdatedAt = utcNow;
    }
}