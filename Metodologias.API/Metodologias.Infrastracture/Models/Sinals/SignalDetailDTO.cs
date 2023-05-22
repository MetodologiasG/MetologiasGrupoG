using Metodologias.Infrastracture.Entities;
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
        public int Id { get; set; }
        public string Ref { get; set; }
        public int Value { get; set; }
        public bool SetSignal { get; set; }
        public List<TemporalInformationListDTO> TemporalInformationLists { get; set; }

        public SignalDetailDTO(Signal signal)
        {
            this.Id = signal.Id;
            this.Ref = signal.Ref;
            this.Value = signal.NominalValue;
            if (signal.TemporalInformation.Where(t => t.RemoveDate == null).Any() == true)
            {
                this.SetSignal = false;
            }
            else
            {
                this.SetSignal = true;
            }
            this.TemporalInformationLists = signal.TemporalInformation.Select(t => new TemporalInformationListDTO(t)).ToList();
        }
    }
}
