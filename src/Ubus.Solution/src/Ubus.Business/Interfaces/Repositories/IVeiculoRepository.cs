using System;
using System.Threading.Tasks;
using Ubus.Business.Models;

namespace Ubus.Business.Interfaces.Repositories
{
    public interface IVeiculoRepository : IBaseRepository<Veiculo>
    {
        Task AlterarItens(AdicionalItem adicionalItem);
        VeiculoItens ObterItensVeiculo(Guid id);
    }
}
