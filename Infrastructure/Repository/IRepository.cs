using System.Linq.Expressions;

namespace Authentication_Service.Application.Interfaces.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    #region Queries

    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);

    #endregion

    #region Commands

    void Add(TEntity entity);

    void Remove(TEntity entity);

    void Update(TEntity entity);

    #endregion
}