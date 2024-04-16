using Authentication_Service.Application.Interfaces.Repositories.Users;
using Infrastructure.Repository.Roles;

namespace Authentication_Service.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IUserRepository Users { get; set; }
    public IRoleRepository Roles { get; set; }
}