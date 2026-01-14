using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManagerDemo.Core.Interfaces;

namespace TaskManagerDemo.Data.Repositories;

public class EfRepository<T> : IRepository<T> where T : class
{
    protected readonly AppDbContext _dbContext;
    protected readonly DbSet<T> _dbSet;

    public EfRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();
    }

    public virtual async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public virtual async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}