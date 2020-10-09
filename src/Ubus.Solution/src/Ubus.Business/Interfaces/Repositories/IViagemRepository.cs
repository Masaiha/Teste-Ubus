using System.Collections.Generic;
using Ubus.Business.Models;

namespace Ubus.Business.Interfaces.Repositories
{
    public interface IViagemRepository : IBaseRepository<Viagem>
    {
        IEnumerable<ViagemMotorista> ObterTodosViagemMotoristas();
        IEnumerable<ViagemMotorista> FiltrarViagemsPorDia();
    }
}
