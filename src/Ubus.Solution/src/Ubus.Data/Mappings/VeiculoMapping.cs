using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ubus.Business.Models;

namespace Ubus.Data.Mappings
{
    public class VeiculoMapping : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Marca)
                .IsRequired();

            builder.Property(i => i.Modelo)
                .IsRequired();

            builder.ToTable("Veiculos");
        }
    }
}
