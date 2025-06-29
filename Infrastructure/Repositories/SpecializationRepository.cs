using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SpecializationRepository : GenericRepository<Specialization>, ISpecializationRepository
    {
        private readonly AutoTallerDbContext _context;
        public SpecializationRepository(AutoTallerDbContext context) : base(context)
        {
            _context = context;
        }
    }
} 