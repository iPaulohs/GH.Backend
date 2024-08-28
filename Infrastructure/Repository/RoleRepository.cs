using Domain.Entities;
using Infrastructure.Database;
using Infrastructure.Repository.Base;

namespace Infrastructure.Repository;

public interface IRoleRepository : ISqlBaseRepository<Role> { }

public class RoleRepository(SqlContextDatabase context) 
    : SqlBaseRepository<Role>(context), IRoleRepository
{
    
}