using System.Linq.Expressions;
using Domain.Entities;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Base;

public interface ISqlBaseRepository<T> where T : EntityBase
{
    Task CreateAsync(T entity);
    Task Delete(string id);
    Task Update(string id, T model);
    Task<T?> GetByExpression(Expression<Func<T, bool>> expression);
    Task<T?> GetById(string id);
    Task<IEnumerable<T>?> GetAllByExpression(Expression<Func<T, bool>> expression);
    Task<IEnumerable<T>?> GetAll();
}

public class SqlBaseRepository<T>(SqlContextDatabase context) 
    : ISqlBaseRepository<T> where T : EntityBase
{
    private readonly SqlContextDatabase _context = context;

    public async Task CreateAsync(T entity)
    {
        try
        {
            await _context.Set<T>().AddAsync(entity);
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("Um erro ocorreu durante o salvamento de dados no banco de dados", ex);
        }
    }

    public virtual Task Delete(string id)
    {
        throw new NotImplementedException();
    }

    public async Task Update(string id, T model)
    {
        try
        {
            var reg = await _context.Set<T>().FindAsync(id.ToString());
            _context.Set<T>().Update(model);
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("Um erro ocorreu durante o salvamento de dados no banco de dados", ex);
        }
    }
    
    public async Task<T?> GetByExpression(Expression<Func<T, bool>> expression)
    {
        return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression);
    }
    
    public async Task<T?> GetById(string id)
    {
        return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id.ToString());
    }
    
    public async Task<IEnumerable<T>?> GetAllByExpression(Expression<Func<T, bool>> expression)
    {
        return await _context.Set<T>().AsNoTracking().Where(expression).ToListAsync(); 
    }

    public async Task<IEnumerable<T>?> GetAll()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }
}