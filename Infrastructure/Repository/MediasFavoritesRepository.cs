using Domain.Entities;
using Infrastructure.Database;
using Infrastructure.Repository.Base;

namespace Infrastructure.Repository;

public interface IMediasFavoritesRepository : ISqlBaseRepository<MediasFavorites> { }

public class MediasFavoritesRepository(SqlContextDatabase context) 
    : SqlBaseRepository<MediasFavorites>(context), IMediasFavoritesRepository
{
    
}