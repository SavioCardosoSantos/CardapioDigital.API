using CardapioDigital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardapioDigital.Infra.Data.EntitiesConfiguration
{
    internal class RestauranteMesaAtendimentoClienteConfiguration : IEntityTypeConfiguration<RestauranteMesaAtendimentoCliente>
    {
        public void Configure(EntityTypeBuilder<RestauranteMesaAtendimentoCliente> builder)
        {
            builder.HasOne(d => d.Cliente).WithMany(p => p.RestauranteMesaAtendimentoClientes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RESTAURANTE_MESA_ATENDIMENTO_CLIENTE_RESTAURANTE_MESA_ATENDIMENTO");

            builder.HasOne(d => d.RestauranteMesaAtendimento).WithMany(p => p.RestauranteMesaAtendimentoClientes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RESTAURANTE_MESA_ATENDIMENTO_CLIENTE_RESTAURANTE_MESA_ATENDIMENTO1");
        }
    }
}
