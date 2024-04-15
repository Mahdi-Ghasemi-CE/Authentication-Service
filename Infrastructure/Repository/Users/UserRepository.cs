using Authentication_Service.Application.Interfaces.Repositories.Users;
using Domain.Users;

namespace Authentication_Service.Infrastructure.Repository.Users;

public class UserRepository : Repository<User>,IUserRepository
{
    private readonly IQueryable<User> _queryable;
    public UserRepository(AppDbContext dbContext) : base(dbContext)
    {
        _queryable = dbContext.Set<User>();
    }
}