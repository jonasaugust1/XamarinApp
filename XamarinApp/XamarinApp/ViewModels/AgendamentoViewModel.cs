using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinApp.Models;

namespace XamarinApp.ViewModels
{
    public class AgendamentoViewModel : BaseViewModel
    {
        const string URL_POST_AGENDAMENTO = "https://jonasaugust1.github.io/CarApi/salvarAgendamento";
        public Agendamento Agendamento { get; set; }
        public Veiculo Veiculo
        {
            get
            {
                return Agendamento.Veiculo;
            }
            set
            {
                Agendamento.Veiculo = value;
            }
        }
        public string Nome
        {
            get
            {
                return Agendamento.Nome;
            }
            set
            {
                Agendamento.Nome = value;
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }
        }
        public string Telefone
        {
            get
            {
                return Agendamento.Telefone;
            }
            set
            {
                Agendamento.Telefone = value;
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }
        }
        public string Email
        {
            get
            {
                return Agendamento.Email;
            }
            set
            {
                Agendamento.Email = value;
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }
        }
        public DateTime Data
        {
            get
            {
                return Agendamento.DataAgendamento;
            }
            set
            {
                Agendamento.DataAgendamento = value;
            }
        }
        public DateTime DataMinima
        {
            get
            {
                return Agendamento.DataMinimaAgendamento;
            }
        }
        public TimeSpan Hora
        {
            get
            {
                return Agendamento.HoraAgendamento;
            }
            set
            {
                Agendamento.HoraAgendamento = value;
            }
        }
        public ICommand AgendarCommand { get; set; }
        public AgendamentoViewModel(Veiculo veiculo)
        {
            Agendamento = new Agendamento()
            {
                Veiculo = veiculo
            };
            AgendarCommand = new Command(() =>
            {
                MessagingCenter.Send(Veiculo, "Agendar");
            },
            () =>
            {
                return !string.IsNullOrEmpty(Nome)
                && string.IsNullOrEmpty(Telefone)
                && string.IsNullOrEmpty(Email);
            }
            );
        }
        public async Task SalvarAgendamento()
        {
            HttpClient client = new HttpClient();
            DateTime dataHoraAgendamento = new DateTime(
                Data.Year,
                Data.Month,
                Data.Day,
                Hora.Hours,
                Hora.Minutes,
                Hora.Seconds);

            string json = JsonConvert.SerializeObject(new
            {
                nome = Nome,
                fone = Telefone,
                email = Email,
                carro = Veiculo.Nome,
                preco = Veiculo.Preco,
                dataAgendamento = dataHoraAgendamento
            });

            StringContent conteudo = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage resposta = await client.PostAsync(URL_POST_AGENDAMENTO, conteudo);

            if(resposta.IsSuccessStatusCode)
            {
                MessagingCenter.Send(Agendamento, "SucessoAgendamento");
            }
            else
            {
                MessagingCenter.Send(new ArgumentException(), "FalhaAgendamento");
            }
        }
    }
}
