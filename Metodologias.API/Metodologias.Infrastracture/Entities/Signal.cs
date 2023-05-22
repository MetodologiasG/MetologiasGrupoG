using Metodologias.Infrastracture.Models.Helpers;
using Metodologias.Infrastracture.Models.Sinals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodologias.Infrastracture.Entities
{
    public class Signal
    {
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Signal Id cannot be negative.");
                id = value;
            }
        }

        private string reference;
        public string Ref
        {
            get { return reference; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Signal reference cannot be null or empty.");
                reference = value;
            }
        }

        private int nominalValue;
        public int NominalValue
        {
            get { return nominalValue; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException($"Signal nominal value cannot be equal or less than 0.");
                nominalValue = value;
            }
        }
        public ICollection<TemporalInformation> TemporalInformation { get; set; }

        public Signal()
        {

        }

        public Signal(int id, string refe, int vaue)
        {
            Id = id;
            Ref = refe;
            nominalValue = vaue;
        }

        public MessagingHelper SetSignal(Team team, SetSignalDTO setSignal)
        {
            MessagingHelper response = new MessagingHelper();
            if (TemporalInformation != null)
            {
                var currentTemporalInformation = TemporalInformation.Where(t => t.RemoveDate == null).FirstOrDefault();
                if (currentTemporalInformation != null)
                {
                    response.Success = false;
                    response.Message = $"Este sinal ainda não foi removido da {currentTemporalInformation.StreetRef}, se deseja inserir neste local por favor remova-o";
                    return response;
                }
            }
            else
            {
                this.TemporalInformation = new List<TemporalInformation>();

            }
            this.TemporalInformation.Add(new TemporalInformation(setSignal.Quality, setSignal.Date, null, setSignal.StreetRef, team));
            response.Success = true;


            return response;
        }

        public MessagingHelper WithdrawSignal(Team team, DateTime date, int quality)
        {
            MessagingHelper response = new MessagingHelper();
            if (TemporalInformation == null)
            {
                response.Message = "Este sinal ainda não está colocado em lado nenhum";
                return response;
            }
            var OpenTemporalInformation = this.TemporalInformation.Where(t => t.RemoveDate == null).FirstOrDefault();
            if (OpenTemporalInformation == null)
            {
                response.Message = "Este sinal ainda não está colocado em lado nenhum";
                return response;
            }

            OpenTemporalInformation.RemoveDate = date;
            OpenTemporalInformation.Surveys.Add(new Survey(quality, DateTime.Now, team, OpenTemporalInformation));
            response.Success = true;
            return response;
        }

    }
}
