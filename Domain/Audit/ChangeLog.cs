using Domain.Entities;

namespace Domain.Audit;

public class ChangeLog(string? entityName, Ulid entityId, string? field, string? oldValue, string? newValue)
    : EntityBase
{
    public string? EntityName { get; init; } = entityName;

    public Ulid EntityId { get; init; } = entityId;

    public string? Field { get; init; } = field;

    public string? OldValue { get; init; } = oldValue;

    public string? NewValue { get; init; } = newValue;

    public DateTime Timestamp { get; private init; } = DateTime.Now;
}