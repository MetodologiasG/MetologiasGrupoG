using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodologias.Infrastracture.Models.Sinals
{
    public class SetSignalDTO
    {
        public int SignalId { get; set; }
        public int TeamId { get; set; }
        public string StreetRef { get; set; }
        public int Quality { get; set; }
        public DateTime Date { get; set; }
    }
}
