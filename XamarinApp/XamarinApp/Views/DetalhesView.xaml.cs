using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Models;
using XamarinApp.ViewModels;

namespace XamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalhesView : ContentPage
    {
        public DetalhesViewModel ViewModel { get; set; }
        public DetalhesView(Veiculo veiculo)
        {
            InitializeComponent();
            ViewModel = new DetalhesViewModel(veiculo);
            Title = veiculo.Nome;
            BindingContext = ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "Proximo", (msg) =>
            {
                Navigation.PushAsync(new AgendamentoView(msg));
            });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "Proximo");
        }
    }
}