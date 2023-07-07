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

            Veiculos = new ListagemVeiculos().Veiculos;

            BindingContext = this;
        }

        private void ListViewVeiculos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Veiculo veiculo = (Veiculo)e.Item;

            Navigation.PushAsync(new DetalhesView(veiculo));
        }
    }
}
