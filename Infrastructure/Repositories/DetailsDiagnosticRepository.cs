using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class DetailsDiagnosticRepository : GenericRepository<DetailsDiagnostic>, IDetailsDiagnosticRepository
    {
        public DetailsDiagnosticRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<DetailsDiagnostic>> GetDetailsDiagnosticByOrderAsync(int orderId)
        {
            return await _dbSet
                .Include(dd => dd.Diagnostic)
                .Where(dd => dd.IdOrder == orderId)
                .ToListAsync();
        }

        public async Task<IEnumerable<DetailsDiagnostic>> GetDetailsDiagnosticByDiagnosticAsync(int diagnosticId)
        {
            return await _dbSet
                .Include(dd => dd.ServiceOrder)
                .Where(dd => dd.IdDiagnostic == diagnosticId)
                .ToListAsync();
        }

        public async Task<IEnumerable<DetailsDiagnostic>> GetDetailsDiagnosticWithRelationsAsync()
        {
            return await _dbSet
                .Include(dd => dd.ServiceOrder)
                .Include(dd => dd.Diagnostic)
                .ToListAsync();
        }
    }
} 