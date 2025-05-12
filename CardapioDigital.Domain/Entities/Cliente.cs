using CardapioDigital.Util.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioDigital.Domain.Entities;

[Table("CLIENTE")]
public partial class Cliente
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("cpf")]
    [StringLength(11)]
    public string Cpf { get; set; }

    [Required]
    [Column("nome")]
    [MaxLength(100)]
    public string Nome { get; set; }

    [Column("data_nascimento", TypeName = "date")]
    public DateOnly DataNascimento { get; set; }

    [Column("contato")]
    [MaxLength(30)]
    public string Contato { get; set; }

    [Column("status_adimplencia")]
    public eStatusAdimplencia StatusAdimplencia { get; set; }

    [InverseProperty("Cliente")]
    public virtual ICollection<AtendimentoPedidoClienteCompartilhado> AtendimentoPedidoClienteCompartilhados { get; set; } = new List<AtendimentoPedidoClienteCompartilhado>();

    [InverseProperty("Cliente")]
    public virtual ICollection<AtendimentoPedidoCliente> AtendimentoPedidoClientes { get; set; } = new List<AtendimentoPedidoCliente>();

    [InverseProperty("Cliente")]
    public virtual ICollection<RestauranteMesaAtendimentoCliente> RestauranteMesaAtendimentoClientes { get; set; } = new List<RestauranteMesaAtendimentoCliente>();

    [InverseProperty("Cliente")]
    public virtual ICollection<TagCliente> TagClientes { get; set; } = new List<TagCliente>();

    [InverseProperty("Cliente")]
    public virtual ICollection<RestricaoAlimentarCliente> RestricaoAlimentarClientes { get; set; } = new List<RestricaoAlimentarCliente>();
}