using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ubus.Business.Models;

namespace Ubus.Data.Mappings
{
    class MotoristaViagemMapping : IEntityTypeConfiguration<MotoristaViagem>
    {
        public void Configure(EntityTypeBuilder<MotoristaViagem> builder)
        {

            builder.HasKey(a => a.Id);

            builder.ToTable("MotoristaViagens");
        }
    }
}
