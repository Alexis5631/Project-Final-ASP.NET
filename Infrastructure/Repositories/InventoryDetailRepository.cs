using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class InventoryDetailRepository : GenericRepository<InventoryDetail>, IInventoryDetailRepository
    {
        public InventoryDetailRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<InventoryDetail>> GetInventoryDetailsByOrderAsync(int orderId)
        {
            return await _dbSet
                .Include(id => id.Inventory)
                .Where(id => id.IdOrder == orderId)
                .ToListAsync();
        }

        public async Task<IEnumerable<InventoryDetail>> GetInventoryDetailsByInventoryAsync(int inventoryId)
        {
            return await _dbSet
                .Include(id => id.ServiceOrder)
                .Where(id => id.IdInventory == inventoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<InventoryDetail>> GetInventoryDetailsWithRelationsAsync()
        {
            return await _dbSet
                .Include(id => id.ServiceOrder)
                .Include(id => id.Inventory)
                .ToListAsync();
        }
    }
} 