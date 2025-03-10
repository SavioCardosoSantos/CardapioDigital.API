using CardapioDigital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardapioDigital.Infra.Data.EntitiesConfiguration
{
    internal class AtendimentoPedidoClienteConfiguration : IEntityTypeConfiguration<AtendimentoPedidoCliente>
    {
        public void Configure(EntityTypeBuilder<AtendimentoPedidoCliente> builder)
        {
            builder.HasOne(d => d.Cliente).WithMany(p => p.AtendimentoPedidoClientes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ATENDIMENTO_PEDIDO_CLIENTE_CLIENTE");

            builder.HasOne(d => d.Item).WithMany(p => p.AtendimentoPedidoClientes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ATENDIMENTO_PEDIDO_CLIENTE_RESTAURANTE_MESA_ATENDIMENTO");

            builder.HasOne(d => d.RestauranteMesaAtendimento).WithMany(p => p.AtendimentoPedidoClientes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ATENDIMENTO_PEDIDO_CLIENTE_RESTAURANTE_MESA_ATENDIMENTO1");
        }
    }
}
