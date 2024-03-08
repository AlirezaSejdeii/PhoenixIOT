namespace PhoenixIot.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public DateTime CreateDate { get; set; }
    public List<Device> Devices { get; set; }
    public List<Role> Roles { get; set; }
}