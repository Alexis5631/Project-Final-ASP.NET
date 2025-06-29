using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class DiagnosticRepository : GenericRepository<Diagnostic>, IDiagnosticRepository
    {
        public DiagnosticRepository(DbContext context) : base(context)
        {
        }

        public async Task<Diagnostic> GetDiagnosticWithUserAsync(int id)
        {
            return await _dbSet
                .Include(d => d.User)
                .FirstOrDefaultAsync(d => d.IdDiagnostic == id);
        }

        public async Task<IEnumerable<Diagnostic>> GetDiagnosticsByUserAsync(int userId)
        {
            return await _dbSet
                .Where(d => d.IdUser == userId)
                .OrderByDescending(d => d.IdDiagnostic)
                .ToListAsync();
        }

        public async Task<IEnumerable<Diagnostic>> GetDiagnosticsWithUserAsync()
        {
            return await _dbSet
                .Include(d => d.User)
                .OrderByDescending(d => d.IdDiagnostic)
                .ToListAsync();
        }
    }
} 