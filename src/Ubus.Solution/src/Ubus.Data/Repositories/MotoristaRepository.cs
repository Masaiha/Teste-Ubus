using System.Threading.Tasks;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Business.Models;
using Ubus.Data.Context;

namespace Ubus.Data.Repositories
{
    public class MotoristaRepository : BaseRepository<Motorista>, IMotoristaRepository
    {

        public MotoristaRepository(UbusContext db) : base(db)
        {
        }


    }
}
