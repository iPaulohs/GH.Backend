namespace Domain.Entities;

public class Role : EntityBase
{
    protected Role() {}

    public Role(string? name, string? description)
    {
        Name = name;
        Description = description;
    }

    public string? Name { get; set; } 

    public string? Description { get; set; } 

    public ICollection<Permission>? Permissions { get; set; } = [];
}