using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodologias.Infrastracture.Entities
{
    public class Technician
    {
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Technician Id cannot be negative.");
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
                    throw new ArgumentException("Technician Name cannot be null or empty.");
                name = value;
            }
        }

        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 9)
                    throw new ArgumentException("Technician Phone Number must have at least 9 characters.");
                phoneNumber = value;
            }
        }
        public string Address { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
