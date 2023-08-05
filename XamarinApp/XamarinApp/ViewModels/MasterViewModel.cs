using System;
using System.Globalization;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinApp.Models;

namespace XamarinApp.ViewModels
{
    public class MasterViewModel : BaseViewModel
    {
        public string Nome
        {
            get { return _Usuario.Nome; }
            set { _Usuario.Nome = value; }
        }

        public string DataNascimento
        {
            get { return _Usuario.DataNascimento.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture); }
            set { _Usuario.DataNascimento = DateTime.Parse(value); }
        }

        public string Telefone
        {
            get { return _Usuario.Telefone; }
            set { _Usuario.Telefone = value; }
        }

        public string Email
        {
            get { return _Usuario.Email; }
            set { _Usuario.Email = value; }
        }

        private bool _Ativado = false;
        public bool Ativado
        {
            get { return _Ativado; }
            private set 
            {
                _Ativado = value;
                OnPropertyChanged();
            }
        }

        private ImageSource _FotoPerfil = "perfil.png";
        public ImageSource FotoPerfil
        {
            get { return _FotoPerfil; }
            private set
            {
                _FotoPerfil = value;
                OnPropertyChanged();
            }
        }

        private readonly Usuario _Usuario;
        public ICommand EditarPerfilCommand {get; private set;}
        public ICommand SalvarCommand { get; private set; }
        public ICommand EditarCommand { get; private set; }

        public MasterViewModel(Usuario usuario)
        {
            _Usuario = usuario;
            DefinirComandos(usuario);
        }
        private void DefinirComandos(Usuario usuario)
        {
            EditarPerfilCommand = new Command(() =>
            {
                MessagingCenter.Send(usuario, "EditarPerfil");
            });

            SalvarCommand = new Command(() =>
            {
                Ativado = false;

                MessagingCenter.Send(usuario, "SalvarPerfil");
            });

            EditarCommand = new Command(() =>
            {
                Ativado = true;
            });
        }
    }
}
