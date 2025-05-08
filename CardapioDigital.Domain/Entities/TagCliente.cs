using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioDigital.Domain.Entities
{
    [Table("TAG_CLIENTE")]
    public class TagCliente
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("cliente_id")]
        public int ClienteId { get; set; }

        [Required]
        [Column("tag_id")]
        public int TagId { get; set; }


        [ForeignKey("ClienteId")]
        [InverseProperty("TagClientes")]
        public virtual Cliente Cliente { get; set; }

        [ForeignKey("TagId")]
        [InverseProperty("TagClientes")]
        public virtual Tag Tag { get; set; }

        public TagCliente() { }
        public TagCliente(int clienteId, int tagId)
        {
            ClienteId = clienteId;
            TagId = tagId;
        }
    }
}
