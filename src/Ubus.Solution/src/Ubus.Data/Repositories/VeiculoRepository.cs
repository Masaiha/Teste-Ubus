using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Business.Models;
using Ubus.Data.Context;
using System.Linq;
using System.Xml.Linq;

namespace Ubus.Data.Repositories
{
    public class VeiculoRepository : BaseRepository<Veiculo>, IVeiculoRepository
    {
        private readonly IAdicionalRepository _adicionalRepository;
        private readonly IItemRepository _itemRepository;

        public VeiculoRepository(IAdicionalRepository adicionalRepository, 
                                 IItemRepository itemRepository, 
                                 UbusContext db) : base(db)
        {
            _adicionalRepository = adicionalRepository;
            _itemRepository = itemRepository;
        }

        public Task AlterarItens(AdicionalItem adicionalItem)
        {
            throw new System.NotImplementedException();
        }

        public VeiculoItens ObterItensVeiculo(Guid id)
        {
            var veiculos = Db.Veiculos;
            var veiculoItens = Db.AdicionalItens;
            var itens = Db.Itens;
            
            var veiculoItensPopulados =
                from v in veiculos
                join vi in veiculoItens
                  on v.Id equals vi.VeiculoId
                join i in itens
                  on vi.ItemId equals i.Id
                where (v.Id == id)
                select new { i.Id, i.Nome, vi, v };

            var listVI = new VeiculoItens();

            foreach (var item in veiculoItensPopulados)
            {
                listVI.Id = item.vi.Id;
                listVI.VeiculoId = item.v.Id;
                listVI.Itens.Add(new Item()
                {
                    Id = item.Id,
                    Nome = item.Nome
                });
            }

            return listVI;
        }


    }
}
