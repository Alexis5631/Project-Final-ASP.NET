using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ServiceTypeRepository : GenericRepository<ServiceType>, IServiceTypeRepository
    {
        public ServiceTypeRepository(DbContext context) : base(context)
        {
        }

        public async Task<ServiceType> GetServiceTypeWithOrdersAsync(int id)
        {
            return await _dbSet
                .Include(st => st.ServiceOrders)
                .FirstOrDefaultAsync(st => st.IdServiceType == id);
        }

        public async Task<IEnumerable<ServiceType>> GetServiceTypesWithOrdersAsync()
        {
            return await _dbSet
                .Include(st => st.ServiceOrders)
                .ToListAsync();
        }

        public async Task<ServiceType> GetServiceTypeByDescriptionAsync(string description)
        {
            return await _dbSet
                .FirstOrDefaultAsync(st => st.Description == description);
        }
    }
} 