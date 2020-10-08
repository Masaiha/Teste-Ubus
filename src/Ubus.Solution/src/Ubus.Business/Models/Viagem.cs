using System;

namespace Ubus.Business.Models
{
    public class Viagem : Entidade
    {
        public decimal Valor { get; set; }
        public DateTime Saida { get; set; }
        public DateTime Chegada { get; set; }
        public Guid VeiculoId { get; set; }
        
        public Veiculo Veiculo { get; set; }
    }
}
