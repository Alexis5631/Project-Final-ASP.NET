using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ReplacementRepository : GenericRepository<Replacement>, IReplacementRepository
    {
        private readonly AutoTallerDbContext _context;
        public ReplacementRepository(AutoTallerDbContext context) : base(context)
        {
            _context = context;
        }
    }
} 