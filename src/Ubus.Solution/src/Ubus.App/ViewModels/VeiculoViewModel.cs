using System;
using System.Collections.Generic;

namespace Ubus.App.ViewModels
{
    public class VeiculoViewModel
    {
        public Guid Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }

        public IEnumerable<AdicionalItemViewModel> Adicionais { get; set; }
    }
}
