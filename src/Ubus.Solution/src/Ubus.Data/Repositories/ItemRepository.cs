using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Business.Models;
using Ubus.Data.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Ubus.Data.Repositories
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {

        public ItemRepository(UbusContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Item>> ObterSomenteVinculadosAoVeiculo(Guid idVeiculo)
        {
            var teste =
                from ai in Db.AdicionalItens
                join i in Db.Itens
                  on ai.ItemId equals i.Id into coco
                from das in coco
                where (ai.VeiculoId == idVeiculo)
                select new { das };

            var lista = new List<Item>();

            await teste.ForEachAsync(x =>
                lista.Add(new Item() { 
                    Id = x.das.Id,
                    Nome = x.das.Nome
                })
            );

            return lista;
                 
        }
    }
}
