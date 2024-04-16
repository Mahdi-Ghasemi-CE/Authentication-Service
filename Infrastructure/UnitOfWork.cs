using Authentication_Service.Application.Interfaces;
using Authentication_Service.Application.Interfaces.Repositories.Users;
using Authentication_Service.Infrastructure.Repository.Users;
using Infrastructure.Repository.Roles;

namespace Authentication_Service.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public IUserRepository Users { get; set; }
    public IRoleRepository Roles { get; set; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;

        Users = new UserRepository(_context);
        Roles = new RoleRepository(_context);
    }
    
    public async Task<bool> CommitAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}