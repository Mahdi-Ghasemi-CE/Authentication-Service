using Domain.Entities.Users;

namespace Authentication_Service.Application.Interfaces.Repositories.Users;

public interface IUserRepository : IRepository<User>
{
    bool IsExistsUser(string email,string mobileNumber);
    User GetById(int id);
    User GetByMobile(string mobile);
}