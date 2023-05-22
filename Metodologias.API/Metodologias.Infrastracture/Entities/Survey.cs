using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodologias.Infrastracture.Entities
{
    public class Survey
    {
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Survey Id cannot be negative.");
                id = value;
            }
        }

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Survey Date cannot be in the future.");
                date = value;
            }
        }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int Quality { get; set; }
        public int TempotalInformationId { get; set; }
        public TemporalInformation TemporalInformation { get; set; }

        public Survey()
        {

        }

        public Survey(int quality, DateTime date, Team team, TemporalInformation ti)
        {
            this.Quality = quality;
            this.Date = date;
            this.Team = team;
            this.TemporalInformation = ti;
        }
    }
}
