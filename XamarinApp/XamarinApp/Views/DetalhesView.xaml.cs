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
            Title = veiculo.Nome;
            ViewModel = new DetalhesViewModel(veiculo);
            BindingContext = ViewModel;
        }

        private void BtnProximo_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AgendamentoView(ViewModel.Veiculo));
        }
    }
}