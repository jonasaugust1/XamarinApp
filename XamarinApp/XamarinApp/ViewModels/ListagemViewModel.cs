using System.Collections.Generic;
using Xamarin.Forms;
using XamarinApp.Models;

namespace XamarinApp.ViewModels
{
    public class ListagemViewModel
    {
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
            Veiculos = new ListagemVeiculos().Veiculos;
        }
    }
}
