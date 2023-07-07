using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Models;

namespace XamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalhesView : ContentPage
    {
        public Veiculo Veiculo { get; set; }
        public string TextoFreioABS
        {
            get
            {
                return $"Freio ABS R$ {Veiculo.FREIO_ABS}";
            }
        }
        public string TextoArCondicionado
        {
            get
            {
                return $"Ar-condicionado R$ {Veiculo.AR_CONDICIONADO}";
            }
        }
        public string TextoDispositivoMultimidia
        {
            get
            {
                return $"Dispositivo multimídia R$ {Veiculo.DISPOSITIVO_MULTIMIDIA}";
            }
        }
        public bool TemFreioABS 
        { 
            get
            {
                return Veiculo.TemFreioABS;
            }
            set
            {
                Veiculo.TemFreioABS = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }
        public bool TemArCondicionado 
        { 
            get
            {
                return Veiculo.TemArCondicionado;
            }
            set
            {
                Veiculo.TemArCondicionado = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }
        public bool TemDispositivoMultimidia
        { 
            get
            {
                return Veiculo.TemDispositivoMultimidia;
            }
            set
            {
                Veiculo.TemDispositivoMultimidia = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            } 
        }
        public string ValorTotal
        {
            get
            {
                return Veiculo.ValorTotal;
            }
        }

        public DetalhesView(Veiculo veiculo)
        {
            InitializeComponent();
            Title = veiculo.Nome;

            Veiculo = veiculo;

            BindingContext = this;
        }

        private void BtnProximo_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AgendamentoView(Veiculo));
        }
    }
}