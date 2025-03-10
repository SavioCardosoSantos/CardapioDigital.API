﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioDigital.Domain.Entities;

[Table("RESTAURANTE_ITEM_CARDAPIO")]
public partial class RestauranteItemCardapio
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("restaurante_id")]
    public int RestauranteId { get; set; }

    [Required]
    [Column("nome")]
    [MaxLength(100)]
    public string Nome { get; set; }

    [Column("descricao")]
    [MaxLength(500)]
    public string Descricao { get; set; }

    [Column("imagem")]
    public byte[] Imagem { get; set; }

    [Column("preco", TypeName = "money")]
    public decimal Preco { get; set; }

    [Column("disponivel")]
    public int Disponivel { get; set; }

    [Column("serve_qtd_pessoas")]
    public int ServeQtdPessoas { get; set; }


    [InverseProperty("Item")]
    public virtual ICollection<AtendimentoPedidoCliente> AtendimentoPedidoClientes { get; set; } = new List<AtendimentoPedidoCliente>();

    [InverseProperty("Item")]
    public virtual ICollection<TagItemCardapio> TagItemCardapios { get; set; } = new List<TagItemCardapio>();

    [ForeignKey("RestauranteId")]
    [InverseProperty("RestauranteItemCardapios")]
    public virtual Restaurante Restaurante { get; set; }
}