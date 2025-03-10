using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioDigital.Domain.Entities;

[Table("ATENDIMENTO_PEDIDO_CLIENTE_COMPARTILHADO")]
public partial class AtendimentoPedidoClienteCompartilhado
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("atendimento_pedido_cliente_id")]
    public int AtendimentoPedidoClienteId { get; set; }

    [Column("cliente_id")]
    public int ClienteId { get; set; }

    [ForeignKey("AtendimentoPedidoClienteId")]
    [InverseProperty("AtendimentoPedidoClienteCompartilhados")]
    public virtual AtendimentoPedidoCliente AtendimentoPedidoCliente { get; set; }

    [ForeignKey("ClienteId")]
    [InverseProperty("AtendimentoPedidoClienteCompartilhados")]
    public virtual Cliente Cliente { get; set; }
}