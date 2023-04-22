using Metodologias.Infrastracture.Models.Helpers;
using Metodologias.Infrastracture.Models.Sinals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodologias.Infrastracture.Interfaces.Services
{
    public interface ISignalService
    {
        Task<MessagingHelper<List<SignalListDTO>>> GetAll();
        Task<MessagingHelper> Create(CreateSignalDTO createSignal);
    }
}
