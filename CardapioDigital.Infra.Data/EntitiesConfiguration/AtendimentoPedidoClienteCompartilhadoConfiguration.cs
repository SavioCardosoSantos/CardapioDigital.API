using CardapioDigital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardapioDigital.Infra.Data.EntitiesConfiguration
{
    internal class AtendimentoPedidoClienteCompartilhadoConfiguration : IEntityTypeConfiguration<AtendimentoPedidoClienteCompartilhado>
    {
        public void Configure(EntityTypeBuilder<AtendimentoPedidoClienteCompartilhado> builder)
        {
            builder.HasOne(d => d.AtendimentoPedidoCliente).WithMany(p => p.AtendimentoPedidoClienteCompartilhados)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ATENDIMENTO_PEDIDO_CLIENTE_COMPARTILHADO_ATENDIMENTO_PEDIDO_CLIENTE1");

            builder.HasOne(d => d.Cliente).WithMany(p => p.AtendimentoPedidoClienteCompartilhados)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ATENDIMENTO_PEDIDO_CLIENTE_COMPARTILHADO_ATENDIMENTO_PEDIDO_CLIENTE");
        }
    }
}
