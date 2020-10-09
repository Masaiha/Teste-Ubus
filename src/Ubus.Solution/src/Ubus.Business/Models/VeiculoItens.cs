using System;
using System.Collections.Generic;

namespace Ubus.Business.Models
{
    public class VeiculoItens : Entidade
    {
        public VeiculoItens()
        {
            Itens = new List<Item>();
        }

        public Guid VeiculoId { get; set; }
        public List<Item> Itens { get; set; }
    }
}
