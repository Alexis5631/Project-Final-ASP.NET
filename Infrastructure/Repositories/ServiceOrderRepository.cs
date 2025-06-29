using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ServiceOrderRepository : GenericRepository<ServiceOrder>, IServiceOrderRepository
    {
        public ServiceOrderRepository(DbContext context) : base(context)
        {
        }

        public async Task<ServiceOrder> GetServiceOrderWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(so => so.Vehicle)
                .Include(so => so.Mechanic)
                .Include(so => so.ServiceType)
                .Include(so => so.State)
                .Include(so => so.OrderDetails)
                .Include(so => so.DetailsDiagnostics)
                .FirstOrDefaultAsync(so => so.IdOrder == id);
        }

        public async Task<IEnumerable<ServiceOrder>> GetServiceOrdersByMechanicAsync(int mechanicId)
        {
            return await _dbSet
                .Include(so => so.Vehicle)
                .Include(so => so.State)
                .Where(so => so.IdMechanic == mechanicId)
                .OrderByDescending(so => so.EntryDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<ServiceOrder>> GetServiceOrdersByVehicleAsync(int vehicleId)
        {
            return await _dbSet
                .Include(so => so.Mechanic)
                .Include(so => so.State)
                .Where(so => so.IdVehicle == vehicleId)
                .OrderByDescending(so => so.EntryDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<ServiceOrder>> GetServiceOrdersByStateAsync(int stateId)
        {
            return await _dbSet
                .Include(so => so.Vehicle)
                .Include(so => so.Mechanic)
                .Where(so => so.IdState == stateId)
                .OrderByDescending(so => so.EntryDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<ServiceOrder>> GetServiceOrdersByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Include(so => so.Vehicle)
                .Include(so => so.Mechanic)
                .Include(so => so.State)
                .Where(so => so.EntryDate >= startDate && so.EntryDate <= endDate)
                .OrderByDescending(so => so.EntryDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<ServiceOrder>> GetServiceOrdersWithAllDetailsAsync()
        {
            return await _dbSet
                .Include(so => so.Vehicle)
                .Include(so => so.Mechanic)
                .Include(so => so.ServiceType)
                .Include(so => so.State)
                .Include(so => so.OrderDetails)
                .Include(so => so.DetailsDiagnostics)
                .OrderByDescending(so => so.EntryDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<ServiceOrder>> GetPendingServiceOrdersAsync()
        {
            return await _dbSet
                .Include(so => so.Vehicle)
                .Include(so => so.Mechanic)
                .Include(so => so.State)
                .Where(so => so.ExitDate == null)
                .OrderByDescending(so => so.EntryDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<ServiceOrder>> GetCompletedServiceOrdersAsync()
        {
            return await _dbSet
                .Include(so => so.Vehicle)
                .Include(so => so.Mechanic)
                .Include(so => so.State)
                .Where(so => so.ExitDate != null)
                .OrderByDescending(so => so.ExitDate)
                .ToListAsync();
        }
    }
} 