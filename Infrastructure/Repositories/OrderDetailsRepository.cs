using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OrderDetailsRepository : GenericRepository<OrderDetails>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<OrderDetails>> GetOrderDetailsByOrderAsync(int orderId)
        {
            return await _dbSet
                .Include(od => od.Replacement)
                .Where(od => od.IdOrder == orderId)
                .ToListAsync();
        }

        public async Task<IEnumerable<OrderDetails>> GetOrderDetailsByReplacementAsync(int replacementId)
        {
            return await _dbSet
                .Include(od => od.ServiceOrder)
                .Where(od => od.IdReplacement == replacementId)
                .ToListAsync();
        }

        public async Task<IEnumerable<OrderDetails>> GetOrderDetailsWithRelationsAsync()
        {
            return await _dbSet
                .Include(od => od.ServiceOrder)
                .Include(od => od.Replacement)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalCostByOrderAsync(int orderId)
        {
            return await _dbSet
                .Where(od => od.IdOrder == orderId)
                .SumAsync(od => od.TotalCost);
        }
    }
} 