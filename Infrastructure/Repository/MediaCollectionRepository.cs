using System.Reflection;
using Amazon.Runtime;
using Domain.Audit;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Database;
using Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public interface IMediaCollectionRepository : ISqlBaseRepository<MediaCollection> { }

public class MediaCollectionRepository(SqlContextDatabase context, LogRepository logRepository) 
    : SqlBaseRepository<MediaCollection>(context), IMediaCollectionRepository
{
    private readonly LogRepository _logRepository = logRepository;
    
    public override async Task Delete(string id)
    {
        var entity = await context.MediaCollections.FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null)
        {
            Log error = new()
            {
                Title = "Error",
                Message = $"Não foi possível encontrar nenhum registro com o Id '{id}'.",
                Type = TypeLog.Error,
                EntityId = id,
                MethodSignature = MethodBase.GetCurrentMethod()?.Name
            };

            _logRepository.CreateAsync(error);
        }

        entity.Status = Status.Inactive;
    }
}