namespace Domain.Entities;

public class User : EntityBase
{
    protected User() { }

    public User(string? name, string? surname, string? email, string? nickname, string? passwordHash, DateOnly? birthday, Gender gender, TmdbGuestKey? guestKey)
    {
        Name = name;
        Surname = surname;
        Email = email;
        Nickname = nickname;
        PasswordHash = passwordHash;
        Birthday = birthday;
        Gender = gender;
        GuestKey = guestKey;
    }

    public string? Name { get; private set; }
    
    public string? Surname { get; set; }
    
    public string? Email { get; set; }
    
    public string? Nickname { get; set; }
    
    /// User's password after the hashing's method.
    public string? PasswordHash { get; set; }
    
    public DateOnly? Birthday { get; set; }
    
    public Gender Gender { get; set; }
    
    public TmdbGuestKey? GuestKey { get; set; }

    public ICollection<Role>? Roles { get; set; } = [];

    public ICollection<MediasFavorites>? Favorites { get; set; } = [];
    
    public string? ProfilePictureUrl { get; set; } 
}

public enum Gender
{
    Male,
    Female
}