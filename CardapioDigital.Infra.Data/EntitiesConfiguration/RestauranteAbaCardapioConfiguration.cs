using CardapioDigital.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Infra.Data.EntitiesConfiguration
{
    internal class RestauranteAbaCardapioConfiguration  : IEntityTypeConfiguration<RestauranteAbaCardapio>
    {
        public void Configure(EntityTypeBuilder<RestauranteAbaCardapio> builder)
        {
            builder.HasOne(d => d.Restaurante).WithMany(p => p.RestauranteAbaCardapios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RESTAURANTE_ABA_CARDAPIO_RESTAURANTE_ABA_CARDAPIO");
        }
    }
}
