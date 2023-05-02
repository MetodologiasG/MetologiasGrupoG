using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodologias.Infrastracture.Entities
{
    public class TemporalInformation
    {
        public int Id { get; set; }
        public int Quality { get; set; }
        public bool Removed { get; set; }
        public bool Losted { get; set; }

        public int SignalId { get; set; }
        public Signal Signal { get; set; }
    }
}
