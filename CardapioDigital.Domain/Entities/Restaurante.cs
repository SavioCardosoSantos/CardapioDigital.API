using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioDigital.Domain.Entities;

[Table("RESTAURANTE")]
public partial class Restaurante
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("email")]
    [MaxLength(100)]
    public string Email { get; set; }

    [Required]
    [Column("nome")]
    [MaxLength(100)]
    public string Nome { get; set; }

    [Required]
    [Column("excluido")]
    public int Excluido { get; set; }

    [Column("password_hash")]
    public byte[] PasswordHash { get; set; }

    [Column("password_salt")]
    public byte[] PasswordSalt { get; set; }

    [InverseProperty("Restaurante")]
    public virtual ICollection<RestauranteItemCardapio> RestauranteItemCardapios { get; set; } = new List<RestauranteItemCardapio>();

    [InverseProperty("Restaurante")]
    public virtual ICollection<RestauranteMesa> RestauranteMesas { get; set; } = new List<RestauranteMesa>();
}