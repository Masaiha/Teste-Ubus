using System;
using System.Threading.Tasks;
using Ubus.Business.Models;

namespace Ubus.Business.Interfaces.Repositories
{
    public interface IAdicionalRepository : IBaseRepository<AdicionalItem>
    {
        Task ExcluirItemVeiculo(Guid idAdicionalItem);
    }
}
