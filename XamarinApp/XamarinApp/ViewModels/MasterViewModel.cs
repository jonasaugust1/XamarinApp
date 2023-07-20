﻿using System;
using System.Collections.Generic;
using System.Text;
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

        public string Email
        {
            get { return _Usuario.Email; }
            set { _Usuario.Email = value; }
        }

        private readonly Usuario _Usuario;

        public MasterViewModel(Usuario usuario)
        {
            _Usuario = usuario;
        }
    }
}