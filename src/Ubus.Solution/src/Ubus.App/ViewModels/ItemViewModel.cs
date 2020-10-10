using System;
using System.ComponentModel.DataAnnotations;
using Ubus.App.Constantes;

namespace Ubus.App.ViewModels
{
    public class ItemViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = MensagemDeErrosViewModel.campoObrigatirio)]
        [StringLength(200, ErrorMessage = MensagemDeErrosViewModel.campoMaxEMinCaracteres, MinimumLength = 3)]
        public string Nome { get; set; }

        public bool Selected { get; set; }
        //public IEnumerable<AdicionalItemViewModel> AdicionalItens { get; set; }
    }
}
