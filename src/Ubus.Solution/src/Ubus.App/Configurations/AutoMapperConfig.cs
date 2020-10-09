using AutoMapper;
using Ubus.App.ViewModels;
using Ubus.Business.Models;

namespace Ubus.App.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AdicionalItemViewModel, AdicionalItem>().ReverseMap();
            CreateMap<ItemViewModel, Item>().ReverseMap();
            CreateMap<MotoristaViewModel, Motorista>().ReverseMap();
            CreateMap<RotaViewModel, Rota>().ReverseMap();
            CreateMap<VeiculoViewModel, Veiculo>().ReverseMap();
            CreateMap<ViagemMotoristaViewModel, ViagemMotorista>().ReverseMap();
            CreateMap<ViagemViewModel, Viagem>().ReverseMap();
            CreateMap<MotoristaViagemViewModel, MotoristaViagem>().ReverseMap();
            CreateMap<VeiculoItensViewModel, VeiculoItens>().ReverseMap();

        }
    }
}
