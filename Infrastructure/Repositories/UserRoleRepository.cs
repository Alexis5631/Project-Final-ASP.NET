using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<UserRole>> GetUserRolesByUserIdAsync(int userId)
        {
            return await _dbSet
                .Include(ur => ur.Role)
                .Where(ur => ur.IdUser == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserRole>> GetUserRolesByRoleIdAsync(int roleId)
        {
            return await _dbSet
                .Include(ur => ur.User)
                .Where(ur => ur.IdRole == roleId)
                .ToListAsync();
        }

        public async Task<bool> UserHasRoleAsync(int userId, int roleId)
        {
            return await _dbSet.AnyAsync(ur => ur.IdUser == userId && ur.IdRole == roleId);
        }
    }
} 