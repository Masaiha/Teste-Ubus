using System;
using System.Collections.Generic;

namespace Ubus.Api.ViewModels
{
    public class VeiculoItensViewModel
    {
        public VeiculoItensViewModel()
        {
            Itens = new List<ItemViewModel>();
        }
        public Guid Id { get; set; }
        public Guid VeiculoId { get; set; }
        public List<ItemViewModel> Itens { get; set; }
    }
}
