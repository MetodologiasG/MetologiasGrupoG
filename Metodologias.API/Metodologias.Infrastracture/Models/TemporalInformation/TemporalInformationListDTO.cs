using Metodologias.Infrastracture.Entities;
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
        public string RemovedDateString { get { if (this.RemovedDate == null) { return ""; } else return this.RemovedDate.Value.ToString("dd-MM-yyyy"); } }
        public string StreetRef { get; set; }

        public TemporalInformationListDTO(Metodologias.Infrastracture.Entities.TemporalInformation ti)
        {
            this.Id = ti.Id;
            this.Quality = ti.Quality;
            this.FirstDate = ti.FirstDate;
            this.RemovedDate = ti.RemoveDate;
            this.StreetRef = ti.StreetRef;
        }
    }
}
