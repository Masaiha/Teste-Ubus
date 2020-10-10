using Ubus.Business.Interfaces.Repositories;
using Ubus.Business.Models;
using Ubus.Data.Context;

namespace Ubus.Data.Repositories
{
    public class RotaRepository : BaseRepository<Rota>, IRotaRepository
    {
        public RotaRepository(UbusContext db) : base(db)
        {
        }
    }
}
