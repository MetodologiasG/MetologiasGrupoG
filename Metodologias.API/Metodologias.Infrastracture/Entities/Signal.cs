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
        public int Id { get; set; }
        public string Ref { get; set; }
        public int Value { get; set; }
        public ICollection<TemporalInformation> TemporalInformation { get; set; }

        public Signal()
        {

        }

        public MessagingHelper SetSignal(Team team, SetSignalDTO setSignal)
        {
            MessagingHelper response = new MessagingHelper();
            var currentTemporalInformation = TemporalInformation.Where(t => t.RemoveDate == null).FirstOrDefault();
            if (currentTemporalInformation != null)
            {
                response.Success = false;
                response.Message = $"Este sinal ainda não foi removido da {currentTemporalInformation.StreetRef}, se deseja inserir neste local por favor remova-o";
                return response;
            }
            this.TemporalInformation.Add(new TemporalInformation(setSignal.Quality, setSignal.Date, null, setSignal.StreetRef, team));
            response.Success = true;
            return response;
        }

        public MessagingHelper WithdrawSignal(Team team, DateTime date, int quality)
        {
            MessagingHelper response = new MessagingHelper();
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
