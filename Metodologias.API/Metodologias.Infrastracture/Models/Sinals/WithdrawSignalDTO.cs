using Metodologias.Infrastracture.Models.TemporalInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodologias.Infrastracture.Models.Sinals
{
    public class WithdrawSignalDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TeamId { get; set; }
        public int Quality { get; set; }
    }
}
