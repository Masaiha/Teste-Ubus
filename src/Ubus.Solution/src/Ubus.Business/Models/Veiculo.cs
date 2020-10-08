using System;
using System.Collections.Generic;

namespace Ubus.Business.Models
{
    public class Veiculo : Entidade
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        
        public IEnumerable<AdicionalItem> Adicionais { get; set; }
    }
}
