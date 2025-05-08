using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioDigital.Domain.Entities
{
    [Table("TAG")]
    public class Tag
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("texto")]
        [MaxLength(30)]
        public string Texto { get; set; }


        [InverseProperty("Tag")]
        public virtual ICollection<TagItemCardapio> TagItemCardapios { get; set; } = new List<TagItemCardapio>();

        [InverseProperty("Tag")]
        public virtual ICollection<TagCliente> TagClientes { get; set; } = new List<TagCliente>();

        public Tag() { }
        public Tag(string texto)
        {
            this.Texto = texto; 
        }
    }
}
