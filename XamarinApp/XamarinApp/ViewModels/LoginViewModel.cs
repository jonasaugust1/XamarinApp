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
            LogarCommand = new Command(() =>
            {
                MessagingCenter.Send(new Usuario(), "SucessoLogin");
            }, () =>
            {
                return !string.IsNullOrWhiteSpace(_Usuario) && !string.IsNullOrWhiteSpace(_Senha);
            });
        }
    }
}
