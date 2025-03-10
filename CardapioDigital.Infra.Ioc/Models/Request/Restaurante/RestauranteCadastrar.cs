using CardapioDigital.Infra.Ioc.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CardapioDigital.Infra.Ioc.Models.Request.Restaurante
{
    public class RestauranteCadastrar : RestauranteBase
    {
        [Required(ErrorMessage = "A senha é obrigatória")]
        [MaxLength(50, ErrorMessage = "A senha deve ter, no máximo, 50 caracteres")]
        [MinLength(8, ErrorMessage = "A senha deve ter, no mínimo, 8 caracteres")]
        [NotMapped]
        public string Senha { get; set; }
    }
}
