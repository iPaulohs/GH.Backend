namespace Domain.Entities;

public class TmdbGuestKey : EntityBase
{
    protected TmdbGuestKey() { }

    public TmdbGuestKey(string? tmdbKey, DateTime validAt)
    {
        TmdbKey = tmdbKey;
        ValidAt = validAt;
    }

    public string? TmdbKey { get; set; } 

    public DateTime ValidAt { get; set; } 
}