using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodologias.Infrastracture.Entities
{
    public class TemporalInformation
    {
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Temporal Information Id cannot be negative.");
                id = value;
            }
        }

        public int Quality { get; set; }

        private DateTime firstDate;
        public DateTime FirstDate
        {
            get { return firstDate; }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Temporal Information First Date cannot be in the future.");
                firstDate = value;
            }
        }

        private DateTime? removeDate;
        public DateTime? RemoveDate
        {
            get { return removeDate; }
            set
            {
                if (value.HasValue && value < FirstDate)
                    throw new ArgumentException("Temporal Information Remove Date cannot be earlier than First Date.");
                removeDate = value;
            }
        }
        public string StreetRef { get; set; }
        public int SignalId { get; set; }
        public Signal Signal { get; set; }
        public ICollection<Survey> Surveys { get; set; }

        public TemporalInformation()
        {

        }

        public TemporalInformation(int quality, DateTime putDate, DateTime? removeDate, string streetRef, Team team)
        {
            this.Quality = quality;
            this.FirstDate = putDate;
            this.RemoveDate = removeDate;
            this.StreetRef = streetRef;
            this.Surveys?.Add(new Survey(quality, putDate, team, this));
        }
    }
}
