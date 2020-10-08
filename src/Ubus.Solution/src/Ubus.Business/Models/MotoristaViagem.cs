using System;

namespace Ubus.Business.Models
{
    public class MotoristaViagem : Entidade
    {
        public Guid ViagemId { get; set; }
        public Viagem Viagem { get; set; }
        public Guid MotoristaId { get; set; }
        public Motorista Motorista { get; set; }
    }
}
