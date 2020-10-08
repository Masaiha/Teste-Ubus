using System;

namespace Ubus.Business.Models
{
    public class AdicionalItem : Entidade
    {
        public Guid ItemId { get; set; }
        public Guid AdicionalId { get; set; }
        public Item Item { get; set; }
        public Adicional Adicional { get; set; }
    }
}
