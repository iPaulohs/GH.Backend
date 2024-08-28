using Domain.Audit;
using Infrastructure.Repository.Base;
using MongoDB.Driver;

namespace Infrastructure.Repository;

public class LogRepository(IMongoDatabase database) 
    : NoSqlBaseRepository<Log>(database, "Logs"){ }