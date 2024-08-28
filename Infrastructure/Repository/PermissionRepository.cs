using Domain.Entities;
using Infrastructure.Database;
using Infrastructure.Repository.Base;

namespace Infrastructure.Repository;

public interface IPermissionRepository : ISqlBaseRepository<Permission> { }

public class PermissionRepository(SqlContextDatabase context) 
    : SqlBaseRepository<Permission>(context), IPermissionRepository
{
    
}