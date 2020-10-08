using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ubus.Business.Models;

namespace Ubus.Data.Mappings
{
    public class MotoristaMapping : IEntityTypeConfiguration<Motorista>
    {
        public void Configure(EntityTypeBuilder<Motorista> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(m => m.Cpf)
                .IsRequired()
                .HasColumnType("varchar(11)");

            builder.Property(m => m.Ativo)
                .IsRequired()
                .HasColumnType("bit");

            builder.ToTable("Motoristas");
        }
    }
}
