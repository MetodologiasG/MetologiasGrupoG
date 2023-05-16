using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodologias.Infrastracture.Models.TemporalInformation
{
    public class TemporalInformationListDTO
    {
        public int Id { get; set; }

        public int Quality { get; set; }

        public DateTime FirstDate { get; set; }
        public string FirstDateString { get { return this.FirstDate.ToString("dd-MM-yyyy"); } }

        public DateTime? RemovedDate { get; set; }
        public string? removedDate { get { if (this.RemovedDate == null) { return null; } else return this.RemovedDate.Value.ToString("dd-MM-yyyy"); } }
        public string StreetRef { get; set; }
    }
}
