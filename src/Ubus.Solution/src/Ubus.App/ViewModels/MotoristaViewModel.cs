using System;
using System.ComponentModel.DataAnnotations;
using Ubus.App.Constantes;

namespace Ubus.App.ViewModels
{
    public class MotoristaViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = MensagemDeErrosViewModel.campoObrigatirio)]
        [StringLength(200, ErrorMessage = MensagemDeErrosViewModel.campoMaxEMinCaracteres, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required(ErrorMessage = MensagemDeErrosViewModel.campoObrigatirio)]
        [StringLength(11, ErrorMessage = MensagemDeErrosViewModel.campoMaxEMinCaracteres, MinimumLength = 11)]
        public string Cpf { get; set; }
        public bool Ativo { get; set; }

        public Guid ViagemId { get; set; }
    }
}
