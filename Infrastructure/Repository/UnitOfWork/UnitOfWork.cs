using Infrastructure.Database;

namespace Infrastructure.Repository.UnitOfWork;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IRoleRepository RoleRepository { get; }
    ITmdbGuestKeyRepository TmdbGuestKeyRepository { get; }
    IPermissionRepository PermissionRepository { get; }
    IMediaCollectionRepository MediaCollectionRepository { get; }
}

internal class UnitOfWork(
    SqlContextDatabase context,
    LogRepository logRepository,
    IUserRepository userRepository,
    IRoleRepository roleRepository,
    ITmdbGuestKeyRepository tmdbGuestKeyRepository,
    IPermissionRepository permissionRepository,
    IMediaCollectionRepository mediaCollectionRepository)
{
    public IUserRepository UserRepository => 
        userRepository ?? new UserRepository(context);
    
    public IRoleRepository RoleRepository 
        => roleRepository ?? new RoleRepository(context);
    
    public ITmdbGuestKeyRepository TmdbGuestKeyRepository 
        => tmdbGuestKeyRepository ?? new TmdbGuestKeyRepository(context);
    
    public IPermissionRepository PermissionRepository 
        => permissionRepository ?? new PermissionRepository(context);
    
    public IMediaCollectionRepository MediaCollectionRepository
        => mediaCollectionRepository ?? new MediaCollectionRepository(context, logRepository);
}