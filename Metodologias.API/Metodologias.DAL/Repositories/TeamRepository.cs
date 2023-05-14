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
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDBContext _context;
        public TeamRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Team?> GetById(int Id)
        {
            return await _context.Teams.Include(t => t.Technicians).Where(t => t.Id == Id).FirstOrDefaultAsync();
        }
    }
}
