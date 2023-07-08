using System.Windows.Input;
using Xamarin.Forms;
using XamarinApp.Models;

namespace XamarinApp.ViewModels
{
    public class DetalhesViewModel : BaseViewModel
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
        public ICommand ProximoCommand { get; set; }
        public DetalhesViewModel(Veiculo veiculo)
        {
            Veiculo = veiculo;
            ProximoCommand = new Command(() =>
            {
                MessagingCenter.Send(Veiculo, "Proximo");
            });
        }
    }
}
