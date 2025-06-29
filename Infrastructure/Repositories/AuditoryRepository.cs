using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AuditoryRepository : GenericRepository<Auditory>, IAuditoryRepository
    {
        public AuditoryRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Auditory>> GetAuditoryByUserAsync(int userId)
        {
            return await _dbSet
                .Include(a => a.ResponsibleUser)
                .Where(a => a.ResponsibleUserId == userId)
                .OrderByDescending(a => a.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<Auditory>> GetAuditoryByEntityAsync(string entityName)
        {
            return await _dbSet
                .Include(a => a.ResponsibleUser)
                .Where(a => a.AffectedEntity == entityName)
                .OrderByDescending(a => a.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<Auditory>> GetAuditoryByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Include(a => a.ResponsibleUser)
                .Where(a => a.Date >= startDate && a.Date <= endDate)
                .OrderByDescending(a => a.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<Auditory>> GetAuditoryWithUserAsync()
        {
            return await _dbSet
                .Include(a => a.ResponsibleUser)
                .OrderByDescending(a => a.Date)
                .ToListAsync();
        }
    }
} 