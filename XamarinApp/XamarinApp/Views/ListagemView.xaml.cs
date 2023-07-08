using Xamarin.Forms;
using XamarinApp.Models;
using XamarinApp.Views;

namespace XamarinApp.View
{
    public partial class ListagemView : ContentPage
    {
        public ListagemView()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Recebendo a mensagem do veiculo selecionado da ViewModel
            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado", 
                (msg) => 
                {
                    Navigation.PushAsync(new DetalhesView(msg));
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
        }
    }
}
