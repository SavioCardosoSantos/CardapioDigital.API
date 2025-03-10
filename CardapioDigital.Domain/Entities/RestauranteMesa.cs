using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioDigital.Domain.Entities;

[Table("RESTAURANTE_MESA")]
public partial class RestauranteMesa
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("restaurante_id")]
    public int RestauranteId { get; set; }

    [Column("numero_mesa")]
    public int NumeroMesa { get; set; }

    [Column("status_mesa")]
    public int StatusMesa { get; set; }

    [ForeignKey("RestauranteId")]
    [InverseProperty("RestauranteMesas")]
    public virtual Restaurante Restaurante { get; set; }

    [InverseProperty("RestauranteMesa")]
    public virtual ICollection<RestauranteMesaAtendimento> RestauranteMesaAtendimentos { get; set; } = new List<RestauranteMesaAtendimento>();
}