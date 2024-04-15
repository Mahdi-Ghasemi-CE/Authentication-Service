using Authentication_Service.Application.Interfaces.Repositories.Users;
using Authentication_Service.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Authentication_Service.Infrastructure.Repository.Users;

public class UserRepository : Repository<User>,IUserRepository
{
    private readonly IQueryable<User> _queryable;
    public UserRepository(AppDbContext dbContext) : base(dbContext)
    {
        _queryable = dbContext.Set<User>();
    }
}