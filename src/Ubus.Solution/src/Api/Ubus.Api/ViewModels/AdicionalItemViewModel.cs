using System;

namespace Ubus.Api.ViewModels
{
    public class AdicionalItemViewModel
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public Guid VeiculoId { get; set; }
        public ItemViewModel Item { get; set; }
        public VeiculoViewModel Veiculo { get; set; }
    }
}
