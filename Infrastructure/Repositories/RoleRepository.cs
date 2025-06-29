using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly AutoTallerDbContext _context;
        public RoleRepository(AutoTallerDbContext context) : base(context)
        {
            _context = context;
        }
    }
} 