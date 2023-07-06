using System.Collections.Generic;
using Xamarin.Forms;
using XamarinApp.Models;
using XamarinApp.Views;

namespace XamarinApp.View
{
    public partial class ListagemView : ContentPage
    {
        public List<Veiculo> Veiculos { get; set; }
        public ListagemView()
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

        private void ListViewVeiculos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Veiculo veiculo = (Veiculo)e.Item;

            Navigation.PushAsync(new DetalhesView(veiculo));
        }
    }
}
