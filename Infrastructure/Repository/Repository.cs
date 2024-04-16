using System.Linq.Expressions;
using Authentication_Service.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Authentication_Service.Infrastructure.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly AppDbContext _dbContext;

    protected Repository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    #region Queries

    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbContext.Set<TEntity>().AnyAsync(predicate);
    }

    #endregion

    #region Commands

    public void Add(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
        _dbContext.SaveChanges();
    }

    public void Add(IEnumerable<TEntity> entities)
    {
        _dbContext.Set<TEntity>().AddRange(entities);
        _dbContext.SaveChanges();
    }

    public void Remove(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
        _dbContext.SaveChanges();
    }

    public void Remove(IEnumerable<TEntity> entities)
    {
        _dbContext.Set<TEntity>().RemoveRange(entities);
        _dbContext.SaveChanges();
    }

    public void Update(TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
        _dbContext.SaveChanges();
    }

    public void Update(IEnumerable<TEntity> entities)
    {
        _dbContext.Set<TEntity>().UpdateRange(entities);
        _dbContext.SaveChanges();
    }

    #endregion
}