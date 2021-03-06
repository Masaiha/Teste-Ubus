﻿using System;
using System.ComponentModel.DataAnnotations;
using Ubus.App.Constantes;

namespace Ubus.App.ViewModels
{
    public class ViagemViewModel
    {

        public Guid Id { get; set; }
        
        [Required(ErrorMessage = MensagemDeErrosViewModel.campoObrigatirio)]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = MensagemDeErrosViewModel.campoObrigatirio)]
        public decimal Valor { get; set; }
        
        [Required(ErrorMessage = MensagemDeErrosViewModel.campoObrigatirio)]
        public bool Finalizado { get; set; }
        
        [Required(ErrorMessage = MensagemDeErrosViewModel.campoObrigatirio)]
        public DateTime Saida { get; set; }
        
        [Required(ErrorMessage = MensagemDeErrosViewModel.campoObrigatirio)]
        public DateTime Chegada { get; set; }
        public Guid VeiculoId { get; set; }
        public Guid RotaId { get; set; }

        public RotaViewModel Rota { get; set; }
        public VeiculoViewModel Veiculo { get; set; }
    }
}
