namespace PhoenixIot.Core.Entities;

public class Role : BaseEntity
{
    public Role(string title, string description)
    {
        Title = title;
        Description = description;
    }

    protected Role()
    {
    }

    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<User> Users { get; set; }
}