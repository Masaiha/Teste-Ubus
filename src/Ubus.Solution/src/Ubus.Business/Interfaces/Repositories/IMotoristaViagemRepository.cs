using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ubus.Business.Models;

namespace Ubus.Business.Interfaces.Repositories
{
    public interface IMotoristaViagemRepository : IBaseRepository<MotoristaViagem>
    {
        Task<MotoristaViagem> ObterMotoristaViagemPorIdViagem(Guid idViagem);
        Task AdicionaMotoristaViagem(MotoristaViagem motoristaViagem);
    }
}
