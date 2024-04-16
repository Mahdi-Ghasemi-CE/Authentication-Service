using Authentication_Service.Application.Utils;

namespace Application.Services;

public interface IService<TEntity> where TEntity : class
{
    Task<OperationResult> Add(TEntity entity);
    Task<OperationResult> Get(int id);

    Task<OperationResult> Remove(int id);

    Task<OperationResult> Update(TEntity entity);
}