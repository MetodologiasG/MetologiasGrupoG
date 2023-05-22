using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodologias.Infrastracture.Entities
{
    public class Team
    {

        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Team Id cannot be negative.");
                id = value;
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Team Name cannot be null or empty.");
                name = value;
            }
        }
        public ICollection<Technician> Technicians { get; set; }
        public ICollection<Survey> Surveys { get; set; }
    }
}
