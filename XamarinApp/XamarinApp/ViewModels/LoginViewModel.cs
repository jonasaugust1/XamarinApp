using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinApp.Models;

namespace XamarinApp.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        private string _Usuario;
        public string Usuario
        {
            get
            {
                return _Usuario;
            }
            set
            {
                _Usuario = value;
                ((Command)LogarCommand).ChangeCanExecute();
            }
        }
        private string _Senha;
        public string Senha
        {
            get
            {
                return _Senha;
            }
            set
            {
                _Senha = value;
                ((Command)LogarCommand).ChangeCanExecute();
            }
        }
        public ICommand LogarCommand { get; private set; }
        public LoginViewModel()
        {
            LogarCommand = new Command(async () =>
            {
                using(HttpClient client = new HttpClient())
                {
                    FormUrlEncodedContent camposFormulario = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("email", _Usuario),
                        new KeyValuePair<string, string>("senha", _Senha),
                    });

                    client.BaseAddress = new Uri("https://jonasaugust1.github.io/CarApi");
                    HttpResponseMessage resultado = await client.PostAsync("/login", camposFormulario);

                    if(resultado.IsSuccessStatusCode)
                    {
                        MessagingCenter.Send(new Usuario(), "SucessoLogin");
                    }
                }
            }, () =>
            {
                return !string.IsNullOrWhiteSpace(_Usuario) && !string.IsNullOrWhiteSpace(_Senha);
            });
        }
    }
}
