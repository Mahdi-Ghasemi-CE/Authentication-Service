using Authentication_Service.Application.Interfaces.Repositories.Users;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Authentication_Service.Infrastructure.Repository.Users;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly IQueryable<User> _queryable;
    public UserRepository(AppDbContext dbContext) : base(dbContext)
    {
        _queryable = dbContext.Set<User>();
    }

    public User GetById(int id)
    {
        return _queryable
            .Where(U => U.UserId == id)
            .Include(U => U.Role)
            .FirstOrDefault();
    }

    public User GetByMobile(string mobile)
    {
        return _queryable
             .Where(U => U.Mobile == mobile)
             .Include(U => U.Role)
             .SingleOrDefault();
    }

    public bool IsExistsUser(string email, string mobile)
    {
        return _queryable
            .Select(U => U.Email == email || U.Mobile == mobile)
            .SingleOrDefault();
    }
}