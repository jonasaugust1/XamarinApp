using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinApp.Models;

namespace XamarinApp.ViewModels
{
    public class MasterViewModel
    {
        public string Nome
        {
            get { return _Usuario.Nome; }
            set { _Usuario.Nome = value; }
        }

        public DateTime DataNascimento
        {
            get { return _Usuario.DataNascimento; }
            set { _Usuario.DataNascimento = value; }
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

        private readonly Usuario _Usuario;
        public ICommand EditarPerfilCommand {get; private set;}
        public ICommand SalvarPerfilCommand { get; private set; }

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

            SalvarPerfilCommand = new Command(() =>
            {
                MessagingCenter.Send(usuario, "SalvarPerfil");
            });
        }
    }
}
