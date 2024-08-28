using Domain.Enums;

namespace Domain.Entities;

public class MediaCollection : EntityBase
{
    protected MediaCollection() { }
    
    public MediaCollection(string? title, string? description, User? ownerUser)
    {
        Title = title;
        Description = description;
        OwnerUser = ownerUser;
        GuestUsers = new List<User>();
        MediaIds = new List<int>();
    }

    public string? Title { get; set; } 

    public string? Description { get; set; } 

    public User? OwnerUser { get; set; } 

    public ICollection<User>? GuestUsers { get; set; } = [];

    public ICollection<int>? MediaIds { get; set; } = [];

    public Status Status { get; set; } = Status.Active;
}