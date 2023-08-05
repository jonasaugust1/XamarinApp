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

        private bool _InputAtivado = false;
        public bool InputAtivado
        {
            get { return _InputAtivado; }
            private set 
            {
                _InputAtivado = value;
                OnPropertyChanged();
            }
        }

        private bool _BtnEditarVisivel = true;
        public bool BtnEditarVisivel
        {
            get { return _BtnEditarVisivel; }
            private set
            {
                _BtnEditarVisivel = value;
                OnPropertyChanged();
            }
        }

        private bool _BtnSalvarVisivel = false;
        public bool BtnSalvarVisivel
        {
            get { return _BtnSalvarVisivel; }
            private set
            {
                _BtnSalvarVisivel = value;
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
                MessagingCenter.Send(usuario, "SalvarPerfil");

                InputAtivado = false;
                BtnSalvarVisivel = false;
                BtnEditarVisivel = true;
            });

            EditarCommand = new Command(() =>
            {
                InputAtivado = true;
                BtnSalvarVisivel = true;
                BtnEditarVisivel = false;
            });
        }
    }
}
