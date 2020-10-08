using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ubus.Business.Models;

namespace Ubus.Data.Mappings
{
    public class RotaMapping : IEntityTypeConfiguration<Rota>
    {
        public void Configure(EntityTypeBuilder<Rota> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Itinerario)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.ToTable("Rotas");
        }
    }
}
