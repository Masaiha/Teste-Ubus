using System;

namespace Ubus.App.ViewModels
{
    public class MotoristaViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public bool Ativo { get; set; }

        public Guid ViagemId { get; set; }
    }
}
