using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserSpecializationRepository : GenericRepository<UserSpecialization>, IUserSpecializationRepository
    {
        public UserSpecializationRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<UserSpecialization>> GetUserSpecializationsByUserIdAsync(int userId)
        {
            return await _dbSet
                .Include(us => us.Specialization)
                .Where(us => us.IdUser == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserSpecialization>> GetUserSpecializationsBySpecializationIdAsync(int specializationId)
        {
            return await _dbSet
                .Include(us => us.User)
                .Where(us => us.IdSpecialization == specializationId)
                .ToListAsync();
        }

        public async Task<bool> UserHasSpecializationAsync(int userId, int specializationId)
        {
            return await _dbSet.AnyAsync(us => us.IdUser == userId && us.IdSpecialization == specializationId);
        }
    }
} 