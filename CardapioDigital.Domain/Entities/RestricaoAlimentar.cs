using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioDigital.Domain.Entities
{
    [Table("RESTRICAO_ALIMENTAR")]
    public class RestricaoAlimentar
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("texto")]
        [MaxLength(30)]
        public string Texto { get; set; }


        [InverseProperty("RestricaoAlimentar")]
        public virtual ICollection<RestricaoAlimentarCliente> RestricaoAlimentarClientes { get; set; } = new List<RestricaoAlimentarCliente>();

        public RestricaoAlimentar() { }
        public RestricaoAlimentar(string texto)
        {
            this.Texto = texto;
        }
    }
}
