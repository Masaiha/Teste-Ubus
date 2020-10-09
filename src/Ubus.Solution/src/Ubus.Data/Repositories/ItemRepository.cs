using System.Threading.Tasks;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Business.Models;
using Ubus.Data.Context;

namespace Ubus.Data.Repositories
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {

        public ItemRepository(UbusContext db) : base(db)
        {
        }


    }
}
