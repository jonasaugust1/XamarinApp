using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Models;
using XamarinApp.ViewModels;

namespace XamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendamentoView : ContentPage
    {
        public AgendamentoViewModel ViewModel { get; set; }
        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            Title = veiculo.Nome;
            ViewModel = new AgendamentoViewModel(veiculo);
            BindingContext = ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "Agendar", async (msg) =>
            {
                bool confirma = await DisplayAlert("Salvar Agendamento", "Deseja mesmo enviar o agendamento?", "Sim", "Não");

                if(confirma)
                {
                    await DisplayAlert("Agendamento",
$@"
Nome: {ViewModel.Nome}
Telefone: {ViewModel.Telefone}
Email: {ViewModel.Email}
Data: {ViewModel.Data:dd/MM/yyyy}
Hora: {ViewModel.Hora}
Modelo: {ViewModel.Veiculo.Nome}", "Ok");
                }
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "Agendar");
        }
    }
}