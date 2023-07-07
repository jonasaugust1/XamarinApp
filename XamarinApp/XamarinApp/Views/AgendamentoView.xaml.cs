using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Models;

namespace XamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendamentoView : ContentPage
    {
        public Veiculo Veiculo { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        DateTime _Data;
        public DateTime Data
        {
            get
            {
                return _Data;
            }
            set
            {
                _Data = value;
                OnPropertyChanged();
            }
        }

        public DateTime DataMinima
        {
            get
            {
                return DateTime.Now;
            }
        }

        TimeSpan _Hora;
        public TimeSpan Hora
        {
            get
            {
                return _Hora;
            }
            set
            {
                _Hora = value;
                OnPropertyChanged();
            }
        }
        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            Title = veiculo.Nome;
            Veiculo = veiculo;

            BindingContext = this;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Agendamento", 
$@"
Nome: {Nome}
Telefone: {Telefone}
Email: {Email}
Data: {Data.ToString("dd/MM/yyyy")}
Hora: {Hora}
Modelo: {Veiculo.Nome}", "Ok");
        }
    }
}