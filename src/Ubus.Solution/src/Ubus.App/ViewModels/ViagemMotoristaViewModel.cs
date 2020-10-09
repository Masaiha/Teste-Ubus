using System;

namespace Ubus.App.ViewModels
{
    public class ViagemMotoristaViewModel
    {

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public bool Finalizado { get; set; }
        public DateTime Saida { get; set; }
        public DateTime Chegada { get; set; }
        public Guid VeiculoId { get; set; }
        public Guid RotaId { get; set; }
        public MotoristaViewModel Motorista { get; set; }
        public RotaViewModel Rota { get; set; }
        public VeiculoViewModel Veiculo { get; set; }
    }
}
