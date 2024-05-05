namespace PhoenixIot.Core.Entities;

public class User : BaseEntity
{
    public User(string username, string password, DateTime now)
    {
        Username = username;
        Password = password;
        IsActive = true;
        CreatedAt = now;
    }

    protected User()
    {
    }

    public string Username { get; set; }
    public string Password { get; set; }
    public bool IsActive { get; set; }
    public ICollection<Device> Devices { get; set; } = new List<Device>();
    public ICollection<Role> Roles { get; set; } = new List<Role>();

    public void AssignNewDevice(Device device, DateTime now)
    {
        Devices.Add(device);
        UpdatedAt = now;
    }

    public void UpdateUsernameAndPassword(string newUsername, string newPassword, DateTime now)
    {
        Username = newUsername;
        Password = newPassword;
        UpdatedAt = now;
    }

    public void ToggleActive(DateTime now)
    {
        IsActive = !IsActive;
        UpdatedAt = now;
    }
}