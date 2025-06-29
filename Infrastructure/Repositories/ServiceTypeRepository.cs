using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ServiceTypeRepository : GenericRepository<ServiceType>, IServiceTypeRepository
    {
        private readonly AutoTallerDbContext _context;
        public ServiceTypeRepository(AutoTallerDbContext context) : base(context)
        {
            _context = context;
        }
    }
} 