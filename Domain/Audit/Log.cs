using Domain.Entities;

namespace Domain.Audit;

public class Log : EntityBase
{
    public string? Title { get; set; }
    
    public string? Message { get; set; } 
    
    public string EntityId { get; init; }
    
    public DateTime OcurredIn { get; private set; } = DateTime.Now;
    
    public TypeLog Type { get; set; }
    
    public string? MethodSignature { get; set; }
};

public enum TypeLog
{
    Information,
    Warning,
    Critical,
    Error
}