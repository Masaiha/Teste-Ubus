using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Motorista> ObterMotoristasPorRota(Guid idRota)
        {
            var rotas = Db.Rotas;
            var viagens = Db.Viagens;
            var motoristaViagens = Db.MotoristaViagens;
            var motoristas = Db.Motoristas;

            var _motoristas =
                from r in rotas
                join v in viagens
                  on r.Id equals v.RotaId
                join mv in motoristaViagens
                  on v.Id equals mv.ViagemId
                join m in motoristas
                  on mv.MotoristaId equals m.Id
                select ( m );


            var listaMotoristas = new List<Motorista>();

            foreach (var item in _motoristas)
            {
                listaMotoristas.Add(new Motorista()
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Cpf = item.Cpf,
                    Ativo = item.Ativo
                });
            }

            return listaMotoristas;
        }
    }
}
