using System.Collections.Generic;

namespace Ubus.Business.Models
{
    public class Item : Entidade
    {
        public string Nome { get; set; }
        public IEnumerable<AdicionalItem> AdicionalItens { get; set; }
    }
}
