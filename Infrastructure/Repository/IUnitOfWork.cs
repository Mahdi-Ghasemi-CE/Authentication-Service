using Authentication_Service.Application.Interfaces.Repositories.Users;

namespace Authentication_Service.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IUserRepository Users { get; set; }
}