using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioDigital.Domain.Entities
{
    [Table("TAG_ITEM_CARDAPIO")]
    public class TagItemCardapio
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("item_id")]
        public int ItemId { get; set; }

        [Required]
        [Column("tag_id")]
        public int TagId { get; set; }


        [ForeignKey("ItemId")]
        [InverseProperty("TagItemCardapios")]
        public virtual RestauranteItemCardapio Item { get; set; }

        [ForeignKey("TagId")]
        [InverseProperty("TagItemCardapios")]
        public virtual Tag Tag { get; set; }

        public TagItemCardapio() { }
        public TagItemCardapio(int itemId, int tagId) 
        { 
            ItemId = itemId;
            TagId = tagId;
        }
    }
}
