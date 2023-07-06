using System.Collections.Generic;
using Xamarin.Forms;
using XamarinApp.Models;

namespace XamarinApp
{
    public partial class MainPage : ContentPage
    {
        public List<Veiculo> Veiculos { get; set; }
        public MainPage()
        {
            InitializeComponent();

            Veiculos = new List<Veiculo>
            {
                new Veiculo
                {
                    Nome = "Azera V6",
                    Preco = 60000
                },
                new Veiculo
                {
                    Nome = "Fiesta 2.0",
                    Preco = 50000
                },
                new Veiculo
                {
                    Nome = "HB20 S",
                    Preco = 32000
                }
            };

            BindingContext = this;
        }
    }
}
