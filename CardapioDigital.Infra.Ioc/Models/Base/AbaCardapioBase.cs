using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioDigital.Infra.Ioc.Models.Base
{
    public class AbaCardapioBase
    {
        [Required]
        [Column("nome")]
        [MaxLength(100, ErrorMessage = "O nome deve ter, no máximo, 100 caracteres")]
        [MinLength(1, ErrorMessage = "O nome não pode ser vazio")]
        public string Nome { get; set; }
    }
}
