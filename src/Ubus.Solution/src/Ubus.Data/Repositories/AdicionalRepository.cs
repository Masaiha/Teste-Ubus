using System;
using System.Threading.Tasks;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Business.Models;
using Ubus.Data.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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

        public async Task<IEnumerable<AdicionalItem>> ObterPorIdVeiculo(Guid id)
        {
            return await Db.AdicionalItens.Where(x => x.VeiculoId == id).ToListAsync();
        }

        public IEnumerable<AdicionalItem> ObterVeiculosItensPorRotaId(Guid idRota)
        {
            var all =
                from rotas in Db.Rotas
                join viagens in Db.Viagens
                  on rotas.Id equals viagens.RotaId
                join veiculos in Db.Veiculos
                  on viagens.VeiculoId equals veiculos.Id
                join adicionalItens in Db.AdicionalItens
                  on veiculos.Id equals adicionalItens.VeiculoId
                join itens in Db.Itens
                  on adicionalItens.ItemId equals itens.Id
                select new
                {
                    veiculos,
                    itens
                };

            var listitensVeiculo = new List<AdicionalItem>();

            foreach (var item in all)
            {
                listitensVeiculo.Add(new AdicionalItem()
                {
                    VeiculoId = item.veiculos.Id,
                    Item = new Item() { Id = item.itens.Id, Nome = item.itens.Nome }
                });
            }

            return listitensVeiculo;

        }
    }
}
