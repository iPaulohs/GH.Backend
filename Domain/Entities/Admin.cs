namespace Domain.Entities;

public class Admin : EntityBase
{
    protected Admin() { }
    public Admin(string? name, string? surname, string? email, string? passwordHash, DateOnly? birthday, Gender gender)
    {
        Name = name;
        Surname = surname;
        Email = email;
        PasswordHash = passwordHash;
        Birthday = birthday;
        Gender = gender;
    }

    public string? Name { get; set; } 

    public string? Surname { get; set; }

    public string? Email { get; set; }

    /// User's password after the hashing's method.
    public string? PasswordHash { get; set; } 

    public DateOnly? Birthday { get; set; }

    public Gender Gender { get; set; } 

    public ICollection<Role>? Roles { get; set; } = [];

    public ICollection<Permission>? Permissions { get; set; } = [];
    
    public string? ProfilePictureUrl { get; set; } = null;
}