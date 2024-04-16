using Authentication_Service.Application.Interfaces.Repositories;
using Domain.Entities.Roles;

namespace Infrastructure.Repository.Roles
{
    public interface IRoleRepository : IRepository<Role>
    {
        Role GetById(int id);
    }
}