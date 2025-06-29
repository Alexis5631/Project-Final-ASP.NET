using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(DbContext context) : base(context)
        {
        }

        public async Task<Role> GetRoleWithUsersAsync(int id)
        {
            return await _dbSet
                .Include(r => r.UserRoles)
                    .ThenInclude(ur => ur.User)
                .FirstOrDefaultAsync(r => r.IdRole == id);
        }

        public async Task<IEnumerable<Role>> GetRolesWithUsersAsync()
        {
            return await _dbSet
                .Include(r => r.UserRoles)
                    .ThenInclude(ur => ur.User)
                .ToListAsync();
        }
    }
} 