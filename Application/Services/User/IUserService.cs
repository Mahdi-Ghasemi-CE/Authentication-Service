using Application.Services;
using Domain.Entities.Users;

namespace Authentication_Service.Application.Services.User;

public interface IUserService : IService<UserRequest>
{
}