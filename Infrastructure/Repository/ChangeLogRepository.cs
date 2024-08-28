using Domain.Audit;
using Infrastructure.Repository.Base;
using MongoDB.Driver;

namespace Infrastructure.Repository;

public class ChangeLogRepository(IMongoDatabase database) 
    : NoSqlBaseRepository<ChangeLog>(database, "ChangeLogs") { }