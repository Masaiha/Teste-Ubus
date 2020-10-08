using System;
using System.Collections.Generic;

namespace Ubus.Business.Models
{
    public class Veiculo : Entidade
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        
        public Guid RotaId { get; set; }

        public Rota Rota { get; set; }
        public IEnumerable<Adicional> Adicionais { get; set; }
    }
}
