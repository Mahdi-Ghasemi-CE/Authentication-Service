using Authentication_Service.Application.Utils;

namespace Authentication_Service.Application.Interfaces.Services;

public interface IService<TEntity> where TEntity : class
{
    Task<OperationResult> Add(TEntity entity);

    Task<OperationResult> Remove(TEntity entity);
    
    Task<OperationResult> Update(TEntity entity);
}