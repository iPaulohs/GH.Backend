namespace Domain.Entities;

public class Permission : EntityBase
{
    protected Permission() { }

    public Permission(string? name, string? description)
    {
        Name = name;
        Description = description;
    }

    public string? Name { get; set; } 

    public string? Description { get; set; } 
}