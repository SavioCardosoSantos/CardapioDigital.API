using CardapioDigital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardapioDigital.Infra.Data.EntitiesConfiguration
{
    internal class RestauranteMesaAtendimentoConfiguration : IEntityTypeConfiguration<RestauranteMesaAtendimento>
    {
        public void Configure(EntityTypeBuilder<RestauranteMesaAtendimento> builder)
        {
            builder.HasOne(d => d.RestauranteMesa).WithMany(p => p.RestauranteMesaAtendimentos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RESTAURANTE_MESA_ATENDIMENTO_RESTAURANTE_MESA");
        }
    }
}
