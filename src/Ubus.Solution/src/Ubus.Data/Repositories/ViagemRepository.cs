using Ubus.Business.Interfaces.Repositories;
using Ubus.Business.Models;
using Ubus.Data.Context;

namespace Ubus.Data.Repositories
{
    public class ViagemRepository : BaseRepository<Viagem>, IViagemRepository
    {
        public ViagemRepository(UbusContext db) : base(db)
        {
        }
    }
}
