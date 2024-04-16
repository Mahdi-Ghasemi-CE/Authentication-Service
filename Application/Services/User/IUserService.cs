using Application.Services;
using Authentication_Service.Application.Utils;
using Domain.Entities.Users;

namespace Authentication_Service.Application.Services.User;

public interface IUserService : IService<UserRequest>
{
    Task<OperationResult> GetByMobile(string mobile);
}