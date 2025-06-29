using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class StateRepository : GenericRepository<State>, IStateRepository
    {
        public StateRepository(DbContext context) : base(context)
        {
        }

        public async Task<State> GetStateWithServiceOrdersAsync(int id)
        {
            return await _dbSet
                .Include(s => s.ServiceOrders)
                .FirstOrDefaultAsync(s => s.IdState == id);
        }

        public async Task<IEnumerable<State>> GetStatesWithServiceOrdersAsync()
        {
            return await _dbSet
                .Include(s => s.ServiceOrders)
                .ToListAsync();
        }

        public async Task<State> GetStateByTypeAsync(string stateType)
        {
            return await _dbSet
                .FirstOrDefaultAsync(s => s.StateType == stateType);
        }
    }
} 