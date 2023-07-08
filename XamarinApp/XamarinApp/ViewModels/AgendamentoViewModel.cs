﻿using System;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinApp.Models;

namespace XamarinApp.ViewModels
{
    public class AgendamentoViewModel : BaseViewModel
    {
        public Agendamento Agendamento { get; set; }
        public Veiculo Veiculo
        {
            get
            {
                return Agendamento.Veiculo;
            }
            set
            {
                Agendamento.Veiculo = value;
            }
        }
        public string Nome
        {
            get
            {
                return Agendamento.Nome;
            }
            set
            {
                Agendamento.Nome = value;
            }
        }
        public string Telefone
        {
            get
            {
                return Agendamento.Telefone;
            }
            set
            {
                Agendamento.Telefone = value;
            }
        }
        public string Email
        {
            get
            {
                return Agendamento.Email;
            }
            set
            {
                Agendamento.Email = value;
            }
        }
        public DateTime Data
        {
            get
            {
                return Agendamento.DataAgendamento;
            }
            set
            {
                Agendamento.DataAgendamento = value;
            }
        }
        public DateTime DataMinima
        {
            get
            {
                return Agendamento.DataMinimaAgendamento;
            }
        }
        public TimeSpan Hora
        {
            get
            {
                return Agendamento.HoraAgendamento;
            }
            set
            {
                Agendamento.HoraAgendamento = value;
            }
        }
        public ICommand AgendarCommand { get; set; }
        public AgendamentoViewModel(Veiculo veiculo)
        {
            Agendamento = new Agendamento()
            {
                Veiculo = veiculo
            };
            AgendarCommand = new Command(() =>
            {
                MessagingCenter.Send(Veiculo, "Agendar");
            });
        }
    }
}
