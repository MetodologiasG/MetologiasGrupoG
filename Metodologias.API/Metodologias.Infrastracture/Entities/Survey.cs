using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodologias.Infrastracture.Entities
{
    public class Survey
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int Quality { get; set; }
        public int TempotalInformationId { get; set; }
        public TemporalInformation TemporalInformation { get; set; }


    }
}
