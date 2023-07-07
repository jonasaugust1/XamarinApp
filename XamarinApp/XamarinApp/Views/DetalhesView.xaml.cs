﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Models;
using XamarinApp.ViewModels;

namespace XamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalhesView : ContentPage
    {
        public Veiculo Veiculo { get; set; }
        public DetalhesView(Veiculo veiculo)
        {
            InitializeComponent();
            Title = veiculo.Nome;
            Veiculo = veiculo;
            BindingContext = new DetalhesViewModel(veiculo);
        }

        private void BtnProximo_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AgendamentoView(Veiculo));
        }
    }
}