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
            return await _context.Sinals.Include(t => t.TemporalInformation)
                .ThenInclude(t => t.Surveys)
                .ThenInclude(t => t.Team)
                .ThenInclude(t => t.Technicians)
                .ToListAsync();
        }

        public async Task Create(Signal signal)
        {
            await _context.Sinals.AddAsync(signal);
            await _context.SaveChangesAsync();

        }

        public async Task<Signal?> GetById(int id)
        {
            return await _context.Sinals.Include(t => t.TemporalInformation)
               .ThenInclude(t => t.Surveys)
               .ThenInclude(t => t.Team)
               .ThenInclude(t => t.Technicians)
               .Where(t => t.Id == id).FirstOrDefaultAsync();
        }

        public async Task Update(Signal signal)
        {
            _context.Entry<Signal>(signal).CurrentValues.SetValues(signal);
            await _context.SaveChangesAsync();
        }


        public async Task<Signal?> GetByRef(string refe)
        {
            return await _context.Sinals.Include(t => t.TemporalInformation)
               .ThenInclude(t => t.Surveys)
               .ThenInclude(t => t.Team)
               .ThenInclude(t => t.Technicians)
               .Where(t => t.Ref == refe).FirstOrDefaultAsync();
        }
    }
}
