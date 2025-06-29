using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SpecializationRepository : GenericRepository<Specialization>, ISpecializationRepository
    {
        public SpecializationRepository(DbContext context) : base(context)
        {
        }

        public async Task<Specialization> GetSpecializationWithUsersAsync(int id)
        {
            return await _dbSet
                .Include(s => s.UserSpecializations)
                    .ThenInclude(us => us.User)
                .FirstOrDefaultAsync(s => s.IdSpecialization == id);
        }

        public async Task<IEnumerable<Specialization>> GetSpecializationsWithUsersAsync()
        {
            return await _dbSet
                .Include(s => s.UserSpecializations)
                    .ThenInclude(us => us.User)
                .ToListAsync();
        }
    }
} 