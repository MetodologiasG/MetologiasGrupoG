using Metodologias.Infrastracture.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodologias.Infrastracture.Interfaces.Repositories
{
    public interface ISinalRepository
    {
        Task<List<Signal>> GetAll();
        Task Create(Signal signal);

        Task<Signal?> GetById(int id);

        Task Update(Signal signal);

        Task<Signal?> GetByRef(string refe);
    }
}
