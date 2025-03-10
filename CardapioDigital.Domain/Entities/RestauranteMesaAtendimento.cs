using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioDigital.Domain.Entities;

[Table("RESTAURANTE_MESA_ATENDIMENTO")]
public partial class RestauranteMesaAtendimento
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("restaurante_mesa_id")]
    public int RestauranteMesaId { get; set; }

    [Column("data_hora_inicio", TypeName = "datetime")]
    public DateTime DataHoraInicio { get; set; }

    [Column("data_hora_fim", TypeName = "datetime")]
    public DateTime? DataHoraFim { get; set; }

    [Column("qtd_pessoas")]
    public int QtdPessoas { get; set; }

    [Column("valor_total", TypeName = "money")]
    public decimal ValorTotal { get; set; }

    [Column("valor_total_pago", TypeName = "money")]
    public decimal? ValorTotalPago { get; set; }

    [Column("status_atendimento")]
    public int StatusAtendimento { get; set; }

    [InverseProperty("RestauranteMesaAtendimento")]
    public virtual ICollection<AtendimentoPedidoCliente> AtendimentoPedidoClientes { get; set; } = new List<AtendimentoPedidoCliente>();

    [ForeignKey("RestauranteMesaId")]
    [InverseProperty("RestauranteMesaAtendimentos")]
    public virtual RestauranteMesa RestauranteMesa { get; set; }

    [InverseProperty("RestauranteMesaAtendimento")]
    public virtual ICollection<RestauranteMesaAtendimentoCliente> RestauranteMesaAtendimentoClientes { get; set; } = new List<RestauranteMesaAtendimentoCliente>();
}