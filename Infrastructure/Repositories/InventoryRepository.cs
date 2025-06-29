using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class InventoryRepository : GenericRepository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(DbContext context) : base(context)
        {
        }

        public async Task<Inventory> GetInventoryWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(i => i.InventoryDetails)
                .FirstOrDefaultAsync(i => i.IdInventory == id);
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesWithDetailsAsync()
        {
            return await _dbSet
                .Include(i => i.InventoryDetails)
                .ToListAsync();
        }

        public async Task<Inventory> GetInventoryByNameAsync(string name)
        {
            return await _dbSet
                .FirstOrDefaultAsync(i => i.Name == name);
        }
    }
} 