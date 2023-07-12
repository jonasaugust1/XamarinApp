using System.Windows.Input;
using Xamarin.Forms;
using XamarinApp.Models;
using XamarinApp.Services;

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
                LoginService service = new LoginService();
                await service.FazerLogin(new Login(_Usuario, _Senha));
            }, () =>
            {
                return !string.IsNullOrWhiteSpace(_Usuario) && !string.IsNullOrWhiteSpace(_Senha);
            });
        }
    }
}
