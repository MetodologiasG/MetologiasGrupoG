using Metodologias.Infrastracture.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodologias.Infrastracture.Interfaces.Repositories
{
    public interface ITeamRepository
    {
        Task<Team?> GetById(int Id);
    }
}
