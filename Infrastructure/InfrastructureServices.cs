using Infrastructure.Database;
using Infrastructure.Repository;
using Infrastructure.Repository.UnitOfWork;
using Infrastructure.TmdbServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minio;
using Refit;

namespace Infrastructure;

public static class InfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        //Database Configs
        services.Configure<MongoDbConfig>(
            configuration.GetSection("MongoDbConfig"));
        
        services.AddSingleton(sp =>
        {
            var config = sp.GetRequiredService<IConfiguration>();
            return new MinioClient()
                .WithEndpoint(config["MinIOConfig:Endpoint"])
                .WithCredentials(config["MinIOConfig:AccessKey"], config["MinIOConfig:SecretKey"])
                .WithSSL(config.GetValue<bool>("Minio:Secure")); 
        });

        services.AddEntityFrameworkNpgsql().AddDbContext<SqlContextDatabase>();
        
        //Repositories
        services.AddScoped<IAdminRepository, AdminRepository>();
        services.AddScoped<IMediaCollectionRepository, MediaCollectionRepository>();
        services.AddScoped<ITmdbGuestKeyRepository, TmdbGuestKeyRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPermissionRepository, PermissionRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IMediasFavoritesRepository, MediasFavoritesRepository>();
        
        
        //TMDB Services
        services.AddTransient<AuthenticatedHttpClientHandler>();
        services.AddRefitClient<ITmdbGuestKeyRepository>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.themoviedb.org/3"))
            .AddHttpMessageHandler<AuthenticatedHttpClientHandler>();
        
        return services;
    }
}