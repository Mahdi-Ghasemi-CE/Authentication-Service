using Authentication_Service.Infrastructure;
using Authentication_Service.Infrastructure.Repository;
using Domain.Entities.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Roles
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private readonly IQueryable<Role> _queryable;

        public RoleRepository(AppDbContext dbContext) : base(dbContext)
        {
            _queryable = dbContext.Set<Role>();
        }

        public Role GetById(int id)
        {
            return _queryable.SingleOrDefault(x => x.RoleId == id);
        }
    }
}
