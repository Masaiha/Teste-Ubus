using System;
using System.Collections.Generic;

namespace Ubus.Business.Models
{
    public class Adicional : Entidade
    {
        public Guid VeiculoId { get; set; }
        public IEnumerable<Item> Items { get; set; }

        public Veiculo Veiculo { get; set; }
    }
}
