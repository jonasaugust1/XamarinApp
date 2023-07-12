﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Exceptions;

namespace XamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<LoginException>(this, "FalhaLogin", async (msg) =>
            {
                await DisplayAlert("Login", msg.Message, "Ok");
            });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<LoginException>(this, "FalhaLogin");
        }
    }
}