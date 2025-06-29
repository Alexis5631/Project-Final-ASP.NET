using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(DbContext context) : base(context)
        {
        }

        public async Task<Vehicle> GetVehicleWithClientAsync(int id)
        {
            return await _dbSet
                .Include(v => v.Client)
                .FirstOrDefaultAsync(v => v.IdVehicle == id);
        }

        public async Task<Vehicle> GetVehicleWithServiceOrdersAsync(int id)
        {
            return await _dbSet
                .Include(v => v.ServiceOrders)
                .FirstOrDefaultAsync(v => v.IdVehicle == id);
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesByClientAsync(int clientId)
        {
            return await _dbSet
                .Where(v => v.IdClient == clientId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesWithClientAsync()
        {
            return await _dbSet
                .Include(v => v.Client)
                .ToListAsync();
        }

        public async Task<Vehicle> GetVehicleByVINAsync(string vin)
        {
            return await _dbSet
                .FirstOrDefaultAsync(v => v.SerialNumberVIN == vin);
        }

        public async Task<bool> VINExistsAsync(string vin)
        {
            return await _dbSet.AnyAsync(v => v.SerialNumberVIN == vin);
        }
    }
} 