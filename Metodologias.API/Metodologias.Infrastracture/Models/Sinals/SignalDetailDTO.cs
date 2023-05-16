using Metodologias.Infrastracture.Models.TemporalInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodologias.Infrastracture.Models.Sinals
{
    public class SignalDetailDTO
    {
        public int ID { get; set; }
        public string Ref { get; set; }
        public string Value { get; set; }
        public bool SetSignal { get; set; }
        public List<TemporalInformationListDTO> TemporalInformationLists { get; set; }
    }
}
