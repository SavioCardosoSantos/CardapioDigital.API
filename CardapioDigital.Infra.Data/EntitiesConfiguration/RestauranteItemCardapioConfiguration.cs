using CardapioDigital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardapioDigital.Infra.Data.EntitiesConfiguration
{
    internal class RestauranteItemCardapioConfiguration : IEntityTypeConfiguration<RestauranteItemCardapio>
    {
        public void Configure(EntityTypeBuilder<RestauranteItemCardapio> builder)
        {
            builder.HasOne(d => d.Restaurante).WithMany(p => p.RestauranteItemCardapios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RESTAURANTE_ITEM_CARDAPIO_RESTAURANTE_ITEM_CARDAPIO");
        }
    }
}
