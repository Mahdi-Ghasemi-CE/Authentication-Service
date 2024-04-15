using Authentication_Service.Application.Interfaces;
using Authentication_Service.Application.Interfaces.Repositories.Users;
using Authentication_Service.Infrastructure.Repository.Users;

namespace Authentication_Service.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public IUserRepository Users { get; set; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;

        Users = new UserRepository(_context);
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