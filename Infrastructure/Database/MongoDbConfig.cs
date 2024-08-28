namespace Infrastructure.Database;

public class MongoDbConfig
{
    public string? ConnectionString { get; private set; }
    public string? DatabaseName { get; private set; }
    public string? CollectionName { get; private set; }
}