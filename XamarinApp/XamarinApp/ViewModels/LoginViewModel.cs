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
            }
        }
        public ICommand Logar { get; private set; }
        public LoginViewModel()
        {
            Logar = new Command(() =>
            {
                MessagingCenter.Send(new Usuario(), "SucessoLogin");
            });
        }
    }
}
