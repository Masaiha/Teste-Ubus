using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ubus.Business.Models;

namespace Ubus.Data.Mappings
{
    public class ViagemMapping : IEntityTypeConfiguration<Viagem>
    {
        public void Configure(EntityTypeBuilder<Viagem> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Valor)
                .IsRequired()
                .HasColumnType("decimal");

            builder.Property(i => i.Saida)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(i => i.Chegada)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(i => i.Finalizado)
                .IsRequired()
                .HasColumnType("bit");

            builder.ToTable("Viagens");
        }
    }
}
