using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioDigital.Domain.Entities;

[Table("ATENDIMENTO_PEDIDO_CLIENTE")]
public partial class AtendimentoPedidoCliente
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("restaurante_mesa_atendimento_id")]
    public int RestauranteMesaAtendimentoId { get; set; }

    [Column("cliente_id")]
    public int ClienteId { get; set; }

    [Column("item_id")]
    public int ItemId { get; set; }

    [Column("qtd_pessoas_divisao")]
    public int QtdPessoasDivisao { get; set; }

    [Column("status_pedido")]
    public int StatusPedido { get; set; }

    [InverseProperty("AtendimentoPedidoCliente")]
    public virtual ICollection<AtendimentoPedidoClienteCompartilhado> AtendimentoPedidoClienteCompartilhados { get; set; } = new List<AtendimentoPedidoClienteCompartilhado>();

    [ForeignKey("ClienteId")]
    [InverseProperty("AtendimentoPedidoClientes")]
    public virtual Cliente Cliente { get; set; }

    [ForeignKey("ItemId")]
    [InverseProperty("AtendimentoPedidoClientes")]
    public virtual RestauranteItemCardapio Item { get; set; }

    [ForeignKey("RestauranteMesaAtendimentoId")]
    [InverseProperty("AtendimentoPedidoClientes")]
    public virtual RestauranteMesaAtendimento RestauranteMesaAtendimento { get; set; }
}