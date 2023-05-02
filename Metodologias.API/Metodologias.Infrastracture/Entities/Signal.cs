using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodologias.Infrastracture.Entities
{
    public class Signal
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public int Value { get; set; }
        public string StreetRef { get; set; }
        public DateTime PutDate { get; set; }
        public DateTime? FinalDate { get; set; }
        public int? TemporalInformationId { get; set; }
        public TemporalInformation? TemporalInformation { get; set; }

    }
}
