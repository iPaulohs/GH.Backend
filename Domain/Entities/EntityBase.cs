namespace Domain.Entities;

public class EntityBase
{
    public string Id { get; private set; } = Ulid.NewUlid().ToString();
    
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
}

