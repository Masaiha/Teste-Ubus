using System;
using System.Threading.Tasks;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Business.Models;
using Ubus.Data.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Ubus.Data.Repositories
{
    public class AdicionalRepository : BaseRepository<AdicionalItem>, IAdicionalRepository
    {

        public AdicionalRepository(UbusContext db) : base(db)
        {
        }

        public async Task ExcluirItemVeiculo(Guid idAdicionalItem)
        {
            var veiculoItens = Db.AdicionalItens;

            var coco =
                (from vi in veiculoItens
                 where (vi.Id == idAdicionalItem)
                 select new { vi });
            
            await Remover(coco.AsNoTracking().FirstOrDefault().vi.Id);

            return;
        }
    }
}
