using System;
using System.ComponentModel.DataAnnotations;
using Ubus.Api.Constantes;

namespace Ubus.Api.ViewModels
{
    public class ViagemMotoristaViewModel
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
        public MotoristaViewModel Motorista { get; set; }
        public RotaViewModel Rota { get; set; }
        public VeiculoViewModel Veiculo { get; set; }
    }
}
