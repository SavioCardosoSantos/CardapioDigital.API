using CardapioDigital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardapioDigital.Infra.Data.EntitiesConfiguration
{
    internal class RestauranteMesaConfiguration : IEntityTypeConfiguration<RestauranteMesa>
    {
        public void Configure(EntityTypeBuilder<RestauranteMesa> builder)
        {
            builder.HasOne(d => d.Restaurante).WithMany(p => p.RestauranteMesas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RESTAURANTE_MESA_RESTAURANTE");
        }
    }
}
