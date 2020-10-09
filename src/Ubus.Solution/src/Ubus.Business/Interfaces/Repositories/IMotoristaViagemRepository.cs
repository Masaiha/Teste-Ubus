using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ubus.Business.Models;

namespace Ubus.Business.Interfaces.Repositories
{
    public interface IMotoristaViagemRepository : IBaseRepository<MotoristaViagem>
    {
        IEnumerable<MotoristaViagem> ObterTodosViagemMotoristas();
        Task AdicionaMotoristaViagem(MotoristaViagem motoristaViagem);
    }
}
