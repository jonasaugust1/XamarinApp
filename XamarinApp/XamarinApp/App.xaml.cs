﻿using Xamarin.Forms;
using XamarinApp.Models;
using XamarinApp.Views;

namespace XamarinApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginView());
        }

        protected override void OnStart()
        {
            MessagingCenter.Subscribe<Usuario>(this, "SucessoLogin", (msg) =>
            {
                //MainPage = new NavigationPage(new ListagemView());
                MainPage = new MasterDetailView(msg);
            });
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
