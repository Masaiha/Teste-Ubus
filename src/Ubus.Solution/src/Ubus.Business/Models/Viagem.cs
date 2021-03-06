﻿using System;

namespace Ubus.Business.Models
{
    public class Viagem : Entidade
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public bool Finalizado { get; set; }
        public DateTime Saida { get; set; }
        public DateTime Chegada { get; set; }
        public Guid VeiculoId { get; set; }
        public Guid RotaId { get; set; }

        public Rota Rota { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}
