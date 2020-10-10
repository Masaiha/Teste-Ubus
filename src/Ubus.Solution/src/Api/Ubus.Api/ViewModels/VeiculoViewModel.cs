using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ubus.Api.Constantes;

namespace Ubus.Api.ViewModels
{
    public class VeiculoViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = MensagemDeErrosViewModel.campoObrigatirio)]
        public string Marca { get; set; }

        [Required(ErrorMessage = MensagemDeErrosViewModel.campoObrigatirio)]
        public string Modelo { get; set; }

        public IEnumerable<AdicionalItemViewModel> Adicionais { get; set; }
    }
}
