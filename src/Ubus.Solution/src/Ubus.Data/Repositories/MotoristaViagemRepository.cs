using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Business.Models;
using Ubus.Data.Context;

namespace Ubus.Data.Repositories
{
    public class MotoristaViagemRepository : BaseRepository<MotoristaViagem>, IMotoristaViagemRepository
    {

        public MotoristaViagemRepository(UbusContext db) : base(db)
        {
        }

        public async Task<MotoristaViagem> ObterMotoristaViagemPorIdViagem(Guid idViagem)
        {
            return await Db.MotoristaViagens.AsNoTracking()
                            .Where(x => x.ViagemId == idViagem)
                            .FirstOrDefaultAsync();
        }

        public async Task AdicionaMotoristaViagem(MotoristaViagem motoristaViagem)
        {
            var mv =
                from x in Db.MotoristaViagens
                where x.ViagemId == motoristaViagem.ViagemId
                select x;

            mv.FirstOrDefault().MotoristaId = motoristaViagem.MotoristaId;

            await Atualizar(mv.FirstOrDefault());

            return;
        }

        private MotoristaViagem ObterPorIdMotoristaEIdViagem(Guid idViagem)
        {
            var mv = Db.MotoristaViagens.AsNoTracking()
                .Where(x => x.ViagemId == idViagem)
                .FirstOrDefault();

            return mv;
        }
    }
}
