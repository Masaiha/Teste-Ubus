using System;
using System.Collections.Generic;

namespace Ubus.Business.Models
{
    public class AdicionalItem : Entidade
    {
        public Guid ItemId { get; set; }
        public Guid VeiculoId { get; set; }
        public Item Item { get; set; }
        //public Item Item { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}
