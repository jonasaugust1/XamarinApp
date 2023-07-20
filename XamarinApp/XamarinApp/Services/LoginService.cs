using Newtonsoft.Json;
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
                        new KeyValuePair<string, string>("login", login.Email),
                        new KeyValuePair<string, string>("password", login.Senha),
                    });

                client.BaseAddress = new Uri("https://jonasaugust1.github.io/CarApi");

                HttpResponseMessage resultado = new HttpResponseMessage();
                try
                {
                    resultado = await client.PostAsync("/login", camposFormulario);
                }
                catch
                {
                    MessagingCenter.Send(new LoginException(@"Ocorreu um erro de comunicação com o servidor.
Por favor verifique a sua conexão e tente novamente mais tarde"), "FalhaLogin");
                }

                //trecho de validação "admin" colocado somente para fazer o login já que não tem API
                if (resultado.IsSuccessStatusCode || (login.Email == "admin" && login.Senha == "admin"))
                {
                    string conteudoResultado = await resultado.Content.ReadAsStringAsync();
                    ResultadoLogin resultadoLogin = JsonConvert.DeserializeObject<ResultadoLogin>(conteudoResultado);

                    MessagingCenter.Send(resultadoLogin.Usuario, "SucessoLogin");
                }
                else
                {
                    MessagingCenter.Send(new LoginException("Usuário ou Senha incorretos."), "FalhaLogin");
                }
            }
        }
    }
}
