using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ubus.Business.Models;

namespace Ubus.Business.Interfaces.Repositories
{
    public interface IItemRepository : IBaseRepository<Item>
    {
        Task<IEnumerable<Item>> ObterSomenteVinculadosAoVeiculo(Guid idVeiculo);
    }
}
