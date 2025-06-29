using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class StateRepository : GenericRepository<State>, IStateRepository
    {
        private readonly AutoTallerDbContext _context;
        public StateRepository(AutoTallerDbContext context) : base(context)
        {
            _context = context;
        }
    }
} 