using Metodologias.Infrastracture.Entities;
using Metodologias.Infrastracture.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodologias.DAL.Repositories
{
    public class SinalsRepository : ISinalRepository
    {
        private readonly ApplicationDBContext _context;

        public SinalsRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Signal>> GetAll()
        {
            return await _context.Sinals.ToListAsync();
        }

        public async Task Create(Signal signal)
        {
            await _context.Sinals.AddAsync(signal);
            await _context.SaveChangesAsync();

        }
    }
}
