using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinApp.Models;

namespace XamarinApp.ViewModels
{
    public class ListagemViewModel
    {
        const string URL_GET_VEICULOS = "https://jonasaugust1.github.io/CarApi/cars.json";
        public List<Veiculo> Veiculos { get; set; }
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
                if(value != null)
                {
                    MessagingCenter.Send(_VeiculoSelecionado, "VeiculoSelecionado");
                }
            }
        }
        public ListagemViewModel()
        {
            Veiculos = new List<Veiculo>();
        }

        public async Task GetVeiculos()
        {
            HttpClient client = new HttpClient();
            string resultado = await client.GetStringAsync(URL_GET_VEICULOS);

            /* 
             *Nome das propriedades no Json estão minusculas e da classe Veiculo maiusculas
             *por isso a necessidade do VeiculoJson
            */
            VeiculoJson[] veiculos = JsonConvert.DeserializeObject<VeiculoJson[]>(resultado);
        }
    }
}
