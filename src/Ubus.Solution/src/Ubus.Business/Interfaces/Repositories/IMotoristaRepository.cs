using System;
using System.Collections;
using System.Collections.Generic;
using Ubus.Business.Models;

namespace Ubus.Business.Interfaces.Repositories
{
    public interface IMotoristaRepository : IBaseRepository<Motorista>
    {
        IEnumerable<Motorista> ObterMotoristasPorRota(Guid idRota);
    }
}
