using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ubus.Business.Models;

namespace Ubus.Data.Mappings
{
    class AdicionaItemMapping : IEntityTypeConfiguration<AdicionalItem>
    {
        public void Configure(EntityTypeBuilder<AdicionalItem> builder)
        {

            builder.HasKey(a => a.Id);

            builder.ToTable("AdicionalItens");
        }
    }
}
