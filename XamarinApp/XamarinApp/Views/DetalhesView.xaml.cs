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

        bool _TemFreioABS;
        public bool TemFreioABS 
        { 
            get
            {
                return _TemFreioABS;
            }
            set
            {
                _TemFreioABS = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        bool _TemArCondicionado;
        public bool TemArCondicionado 
        { 
            get
            {
                return _TemArCondicionado;
            }
            set
            {
                _TemArCondicionado = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        bool _TemDispositivoMultimidia;
        public bool TemDispositivoMultimidia
        { 
            get
            {
                return _TemDispositivoMultimidia;
            }
            set
            {
                _TemDispositivoMultimidia = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            } 
        }
        public string ValorTotal
        {
            get
            {
                decimal valorTotal = Veiculo.Preco;

                valorTotal += TemFreioABS ? Veiculo.FREIO_ABS : 0;

                valorTotal += TemArCondicionado ? Veiculo.AR_CONDICIONADO : 0;

                valorTotal += TemDispositivoMultimidia ? Veiculo.DISPOSITIVO_MULTIMIDIA : 0;

                return $"Total: {valorTotal.ToString("C2", CultureInfo.CurrentCulture)}";
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