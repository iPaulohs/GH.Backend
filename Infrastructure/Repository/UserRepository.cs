using Domain.Entities;
using Infrastructure.Database;
using Infrastructure.Repository.Base;

namespace Infrastructure.Repository;

public interface IUserRepository : ISqlBaseRepository<User> { }

internal class UserRepository(SqlContextDatabase context) 
    : SqlBaseRepository<User>(context), IUserRepository
{
    
}