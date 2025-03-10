using System.ComponentModel.DataAnnotations;

namespace CardapioDigital.Infra.Ioc.Models.Base
{
    public class ClienteBase
    {
        [Required]
        [MaxLength(14, ErrorMessage = "O CPF deve ter, no máximo, 14 caracteres")]
        public string Cpf { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "O nome deve ter, no máximo, 100 caracteres")]
        public string Nome { get; set; }

        [Required]
        public DateOnly DataNascimento { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "O contato deve ter, no máximo, 30 caracteres")]
        public string Contato { get; set; }
    }
}
