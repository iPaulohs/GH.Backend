using Domain.Entities;
using Infrastructure.Database;
using Infrastructure.Repository.Base;

namespace Infrastructure.Repository.UnitOfWork;

public interface IAdminRepository : ISqlBaseRepository<Admin> { }

public class AdminRepository(SqlContextDatabase context) 
    : SqlBaseRepository<Admin>(context), IAdminRepository
{
}