using Domain.Entities;
using Infrastructure.Database;
using Infrastructure.Repository.Base;

namespace Infrastructure.Repository;

public interface ITmdbGuestKeyRepository : ISqlBaseRepository<TmdbGuestKey> { }

public class TmdbGuestKeyRepository(SqlContextDatabase context) 
    : SqlBaseRepository<TmdbGuestKey>(context), ITmdbGuestKeyRepository
{
    
}