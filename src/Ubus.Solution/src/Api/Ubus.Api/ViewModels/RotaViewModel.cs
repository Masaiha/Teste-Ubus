using System;
using System.ComponentModel.DataAnnotations;
using Ubus.Api.Constantes;

namespace Ubus.Api.ViewModels
{
    public class RotaViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = MensagemDeErrosViewModel.campoObrigatirio)]
        [StringLength(500, ErrorMessage = MensagemDeErrosViewModel.campoMaxEMinCaracteres, MinimumLength = 3)]
        public string Itinerario { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
