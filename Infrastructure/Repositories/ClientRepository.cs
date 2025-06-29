using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(DbContext context) : base(context)
        {
        }

        public async Task<Client> GetClientWithVehiclesAsync(int id)
        {
            return await _dbSet
                .Include(c => c.Vehicles)
                .FirstOrDefaultAsync(c => c.IdClient == id);
        }

        public async Task<IEnumerable<Client>> GetClientsWithVehiclesAsync()
        {
            return await _dbSet
                .Include(c => c.Vehicles)
                .ToListAsync();
        }

        public async Task<Client> GetClientByIdentificationAsync(string identification)
        {
            return await _dbSet
                .FirstOrDefaultAsync(c => c.Identification == identification);
        }

        public async Task<Client> GetClientByEmailAsync(string email)
        {
            return await _dbSet
                .FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<bool> IdentificationExistsAsync(string identification)
        {
            return await _dbSet.AnyAsync(c => c.Identification == identification);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _dbSet.AnyAsync(c => c.Email == email);
        }
    }
} 