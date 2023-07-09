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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "Agendar", async (msg) =>
            {
                bool confirma = await DisplayAlert("Salvar Agendamento", "Deseja mesmo enviar o agendamento?", "Sim", "Não");

                if(confirma)
                {
                    await ViewModel.SalvarAgendamento();
                }
            });

            MessagingCenter.Subscribe<Agendamento>(this, "SucessoAgendamento", (msg) =>
            {
                DisplayAlert("Agendamento", "Agendamento salvo com sucesso.", "Ok");
            });

            MessagingCenter.Subscribe<ArgumentException>(this, "FalhaAgendamento", (msg) =>
            {
                DisplayAlert("Agendamento", "Falha ao salvar agendamento. Verifique os dados e tente novamente mais tarde", "Ok");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "Agendar");
            MessagingCenter.Unsubscribe<Agendamento>(this, "SucessoAgendamento");
            MessagingCenter.Unsubscribe<ArgumentException>(this, "FalhaAgendamento");
        }
    }
}