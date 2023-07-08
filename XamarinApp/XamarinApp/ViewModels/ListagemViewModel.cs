using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinApp.Models;

namespace XamarinApp.ViewModels
{
    public class ListagemViewModel : BaseViewModel
    {
        const string URL_GET_VEICULOS = "https://jonasaugust1.github.io/CarApi/cars.json";
        public ObservableCollection<Veiculo> Veiculos { get; set; }
        private Veiculo _VeiculoSelecionado;
        public Veiculo VeiculoSelecionado
        {
            get
            {
                return _VeiculoSelecionado;
            }
            set
            {
                _VeiculoSelecionado = value;

                /*
                 * Implementando mensageria.
                 * Desacoplamento do código.
                */
                if (value != null)
                {
                    MessagingCenter.Send(_VeiculoSelecionado, "VeiculoSelecionado");
                }
            }
        }
        private bool _Carregando;
        public bool Carregando
        {
            get
            {
                return _Carregando;
            }
            set
            {
                _Carregando = value;
                OnPropertyChanged();
            }
        }
        public ListagemViewModel()
        {
            Veiculos = new ObservableCollection<Veiculo>();
        }
        public async Task GetVeiculos()
        {
            Carregando = true;
            HttpClient client = new HttpClient();
            string resultado = await client.GetStringAsync(URL_GET_VEICULOS);

            /* 
             *Nome das propriedades no Json estão minusculas e da classe Veiculo maiusculas
             *por isso a necessidade do VeiculoJson
            */
            VeiculoJson[] veiculosJson = JsonConvert.DeserializeObject<VeiculoJson[]>(resultado);

            foreach (VeiculoJson veiculoJson in veiculosJson)
            {
                Veiculos.Add(new Veiculo
                {
                    Nome = veiculoJson.nome,
                    Preco = veiculoJson.preco
                });
            }
            Carregando = false;
        }
    }
}
