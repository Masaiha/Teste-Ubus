using System;
using System.ComponentModel.DataAnnotations;
using Ubus.App.Constantes;

namespace Ubus.App.ViewModels
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
