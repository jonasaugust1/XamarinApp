using System;
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

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Agendamento", 
$@"
Nome: {ViewModel.Nome}
Telefone: {ViewModel.Telefone}
Email: {ViewModel.Email}
Data: {ViewModel.Data:dd/MM/yyyy}
Hora: {ViewModel.Hora}
Modelo: {ViewModel.Veiculo.Nome}", "Ok");
        }
    }
}