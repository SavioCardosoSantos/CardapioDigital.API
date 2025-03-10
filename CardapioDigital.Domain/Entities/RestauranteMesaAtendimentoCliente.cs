using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioDigital.Domain.Entities;

[Table("RESTAURANTE_MESA_ATENDIMENTO_CLIENTE")]
public partial class RestauranteMesaAtendimentoCliente
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("restaurante_mesa_atendimento_id")]
    public int RestauranteMesaAtendimentoId { get; set; }

    [Column("cliente_id")]
    public int ClienteId { get; set; }

    [Column("data_hora_abertura", TypeName = "datetime")]
    public DateTime DataHoraAbertura { get; set; }

    [Column("data_hora_fechamento", TypeName = "datetime")]
    public DateTime? DataHoraFechamento { get; set; }

    [Column("valor_total", TypeName = "money")]
    public decimal ValorTotal { get; set; }

    [Column("valor_total_pago", TypeName = "money")]
    public decimal? ValorTotalPago { get; set; }

    [Column("status_pagamento")]
    public int StatusPagamento { get; set; }

    [ForeignKey("ClienteId")]
    [InverseProperty("RestauranteMesaAtendimentoClientes")]
    public virtual Cliente Cliente { get; set; }

    [ForeignKey("RestauranteMesaAtendimentoId")]
    [InverseProperty("RestauranteMesaAtendimentoClientes")]
    public virtual RestauranteMesaAtendimento RestauranteMesaAtendimento { get; set; }
}