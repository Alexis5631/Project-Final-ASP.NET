using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AuditoryRepository : GenericRepository<Auditory>, IAuditoryRepository
    {
        private readonly AutoTallerDbContext _context;
        public AuditoryRepository(AutoTallerDbContext context) : base(context)
        {
            _context = context;
        }
    }
} 