using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(DbContext context) : base(context)
        {
        }

        public async Task<Invoice> GetInvoiceWithServiceOrderAsync(int id)
        {
            return await _dbSet
                .Include(i => i.ServiceOrder)
                .FirstOrDefaultAsync(i => i.IdInvoice == id);
        }

        public async Task<Invoice> GetInvoiceByOrderAsync(int orderId)
        {
            return await _dbSet
                .Include(i => i.ServiceOrder)
                .FirstOrDefaultAsync(i => i.IdOrder == orderId);
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Include(i => i.ServiceOrder)
                .Where(i => i.IssueDate >= startDate && i.IssueDate <= endDate)
                .OrderByDescending(i => i.IssueDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesWithServiceOrderAsync()
        {
            return await _dbSet
                .Include(i => i.ServiceOrder)
                .OrderByDescending(i => i.IssueDate)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalRevenueByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Where(i => i.IssueDate >= startDate && i.IssueDate <= endDate)
                .SumAsync(i => i.TotalAmount);
        }
    }
} 