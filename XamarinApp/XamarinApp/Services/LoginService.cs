using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinApp.Exceptions;
using XamarinApp.Models;

namespace XamarinApp.Services
{
    public class LoginService
    {
        public async Task FazerLogin(Login login)
        {
            using (HttpClient client = new HttpClient())
            {
                FormUrlEncodedContent camposFormulario = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>("email", login.Email),
                        new KeyValuePair<string, string>("senha", login.Senha),
                    });

                client.BaseAddress = new Uri("https://jonasaugust1.github.io/CarApi");

                try
                {
                    HttpResponseMessage resultado = await client.PostAsync("/login", camposFormulario);

                    if (resultado.IsSuccessStatusCode)
                    {
                        MessagingCenter.Send(new Usuario(), "SucessoLogin");
                    }
                    else
                    {
                        MessagingCenter.Send(new LoginException("Usuário ou Senha incorretos."), "FalhaLogin");
                    }
                }
                catch(Exception ex)
                {
                    MessagingCenter.Send(new LoginException(@"Ocorreu um erro de comunicação com o servidor.
Por favor verifique a sua conexão e tente novamente mais tarde"), "FalhaLogin");
                } 
            }
        }
    }
}
