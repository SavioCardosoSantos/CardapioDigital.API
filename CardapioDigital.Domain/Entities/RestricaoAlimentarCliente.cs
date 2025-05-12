using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioDigital.Domain.Entities
{
    [Table("RESTRICAO_ALIMENTAR_CLIENTE")]
    public class RestricaoAlimentarCliente
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("cliente_id")]
        public int ClienteId { get; set; }

        [Required]
        [Column("restricao_id")]
        public int RestricaoId { get; set; }


        [ForeignKey("ClienteId")]
        [InverseProperty("RestricaoAlimentarClientes")]
        public virtual Cliente Cliente { get; set; }

        [ForeignKey("RestricaoId")]
        [InverseProperty("RestricaoAlimentarClientes")]
        public virtual RestricaoAlimentar RestricaoAlimentar { get; set; }

        public RestricaoAlimentarCliente() { }
        public RestricaoAlimentarCliente(int clienteId, int restricaoId)
        {
            ClienteId = clienteId;
            RestricaoId = restricaoId;
        }
    }
}
