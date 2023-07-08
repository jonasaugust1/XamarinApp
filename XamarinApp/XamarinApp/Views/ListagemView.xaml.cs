using Xamarin.Forms;
using XamarinApp.Models;
using XamarinApp.ViewModels;
using XamarinApp.Views;

namespace XamarinApp.View
{
    public partial class ListagemView : ContentPage
    {
        public ListagemViewModel ViewModel { get; set; }
        public ListagemView()
        {
            InitializeComponent();
            ViewModel = new ListagemViewModel();
            BindingContext = ViewModel;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            //Recebendo a mensagem do veiculo selecionado da ViewModel
            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado", 
                (msg) => 
                {
                    Navigation.PushAsync(new DetalhesView(msg));
                });

            await ViewModel.GetVeiculos();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
        }
    }
}
