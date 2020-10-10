using System;
using System.Collections.Generic;

namespace Ubus.App.ViewModels
{
    public class ItemViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Selected { get; set; }
        //public IEnumerable<AdicionalItemViewModel> AdicionalItens { get; set; }
    }
}
