using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Business.Models;
using Ubus.Data.Context;

namespace Ubus.Data.Repositories
{
    public class ViagemRepository : BaseRepository<Viagem>, IViagemRepository
    {
        public ViagemRepository(UbusContext db) : base(db) { }

        public IEnumerable<ViagemMotorista> ObterTodosViagemMotoristas()
        {
            var result =
                from viagens in Db.Viagens
                join mv in Db.MotoristaViagens
                  on viagens.Id equals mv.ViagemId into viagensMotoristaViagem
                from vmv in viagensMotoristaViagem.DefaultIfEmpty()
                join mt in Db.Motoristas
                  on vmv.MotoristaId equals mt.Id into viagensMotoristas
                from motoristas in viagensMotoristas.DefaultIfEmpty()
                select new
                {
                    viagens,
                    motoristas
                };

            var listViagensMotoristas = new List<ViagemMotorista>();

            foreach (var item in result)
            {
                listViagensMotoristas.Add(new ViagemMotorista()
                {
                    Id = item.viagens.Id,
                    Nome = item.viagens.Nome,
                    Valor = item.viagens.Valor,
                    Finalizado = item.viagens.Finalizado,
                    Saida = item.viagens.Saida,
                    Chegada = item.viagens.Chegada,
                    Rota = item.viagens.Rota,
                    Veiculo = item.viagens.Veiculo,
                    Motorista = item.motoristas
                });
            };

            return listViagensMotoristas;
        }

        public IEnumerable<ViagemMotorista> FiltrarViagemsPorDia()
        {
            var teste = ObterTodosViagemMotoristas();
                    
            var filtrado = teste.Where(t => t.Saida.Date == DateTime.Now.Date);

            return filtrado;
        }

        public override async Task<Viagem> ObterPorId(Guid id)
        {
            return await Db.Viagens.AsNoTracking()
                .Include(v => v.Rota)
                .Include(v => v.Veiculo)
                .FirstOrDefaultAsync(v => v.Id == id);
        }
    }
}
