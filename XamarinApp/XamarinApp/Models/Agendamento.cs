using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinApp.Models
{
    public class Agendamento
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Veiculo Veiculo { get; set; }
        public DateTime DataAgendamento { get; set; }
        public TimeSpan HoraAgendamento { get; set; }
        public DateTime DataMinimaAgendamento
        {
            get
            {
                return DateTime.Now;
            }
        }
        public Agendamento()
        {

        }
    }
}
