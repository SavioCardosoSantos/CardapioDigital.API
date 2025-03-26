using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Domain.Entities
{
    [Table("RESTAURANTE_ABA_CARDAPIO")]
    public partial class RestauranteAbaCardapio
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


        [ForeignKey("RestauranteId")]
        [InverseProperty("RestauranteAbaCardapios")]
        public virtual Restaurante Restaurante { get; set; }

        [InverseProperty("AbaCardapio")]
        public virtual ICollection<RestauranteItemCardapio> Itens { get; set; } = new List<RestauranteItemCardapio>();
    }
}
