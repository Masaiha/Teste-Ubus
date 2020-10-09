using System.Collections.Generic;
using System.Threading.Tasks;
using Ubus.Business.Models;

namespace Ubus.Business.Interfaces.Repositories
{
    public interface IViagemRepository : IBaseRepository<Viagem>
    {
        IEnumerable<ViagemMotorista> ObterTodosViagemMotoristas();
        IEnumerable<ViagemMotorista> FiltrarViagemsPorDia();

        void AtualizarViagensFinalizadas();
    }
}
