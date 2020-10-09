using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ubus.Business.Models;

namespace Ubus.Data.Context
{
    public class UbusContext : DbContext
    {
        public UbusContext(DbContextOptions<UbusContext> options) : base(options) { }

        public DbSet<Rota> Rotas { get; set; }
        public DbSet<MotoristaViagem> MotoristaViagens { get; set; }
        public DbSet<Motorista> Motoristas { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<AdicionalItem> AdicionalItens { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Viagem> Viagens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UbusContext).Assembly);

            foreach (var relationship in modelBuilder.Model
                        .GetEntityTypes()
                        .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;


            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
