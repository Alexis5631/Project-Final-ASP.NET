using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ReplacementRepository : GenericRepository<Replacement>, IReplacementRepository
    {
        public ReplacementRepository(DbContext context) : base(context)
        {
        }

        public async Task<Replacement> GetReplacementWithOrderDetailsAsync(int id)
        {
            return await _dbSet
                .Include(r => r.OrderDetails)
                .FirstOrDefaultAsync(r => r.IdReplacement == id);
        }

        public async Task<IEnumerable<Replacement>> GetReplacementsByCategoryAsync(string category)
        {
            return await _dbSet
                .Where(r => r.Category == category)
                .OrderBy(r => r.Description)
                .ToListAsync();
        }

        public async Task<IEnumerable<Replacement>> GetReplacementsWithOrderDetailsAsync()
        {
            return await _dbSet
                .Include(r => r.OrderDetails)
                .OrderBy(r => r.Description)
                .ToListAsync();
        }

        public async Task<Replacement> GetReplacementByCodeAsync(string code)
        {
            return await _dbSet
                .FirstOrDefaultAsync(r => r.Code == code);
        }

        public async Task<IEnumerable<Replacement>> GetLowStockReplacementsAsync()
        {
            return await _dbSet
                .Where(r => r.StockQuantity <= r.MinimumStock)
                .OrderBy(r => r.StockQuantity)
                .ToListAsync();
        }

        public async Task<bool> CodeExistsAsync(string code)
        {
            return await _dbSet.AnyAsync(r => r.Code == code);
        }
    }
} 