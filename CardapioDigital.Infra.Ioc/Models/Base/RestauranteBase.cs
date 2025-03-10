using System.ComponentModel.DataAnnotations;

namespace CardapioDigital.Infra.Ioc.Models.Base
{
    public class RestauranteBase
    {

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O E-mail é obrigatório")]
        [MaxLength(100, ErrorMessage = "O E-mail não pode ter mais de 100 caracteres")]
        public string Email { get; set; }

    }
}
