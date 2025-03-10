using System.ComponentModel.DataAnnotations;

namespace CardapioDigital.Application.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(11, ErrorMessage = "O CPF deve ter exatamente 11 caracteres")]
        public string Cpf { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "O nome deve ter, no máximo, 100 caracteres")]
        public string Nome { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "O contato deve ter, no máximo, 30 caracteres")]
        public string Contato { get; set; }

        public int StatusAdimplencia { get; set; }
    }
}
