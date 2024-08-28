using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class SqlContextDatabase() : DbContext()
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<MediaCollection> MediaCollections { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<MediasFavorites> MediasFavorites { get; set; }
    public DbSet<TmdbGuestKey> TmdbGuestKeys { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=geekhub_postgres_user;Password=Tx72j,1Gpm!+z0Lk#voa;Database=geekhub_postgres_database");
    }
}