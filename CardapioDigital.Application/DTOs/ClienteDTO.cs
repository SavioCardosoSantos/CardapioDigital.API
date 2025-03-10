using CardapioDigital.Util.Models.Enum;

namespace CardapioDigital.Application.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string Contato { get; set; }
        public eStatusAdimplencia StatusAdimplencia { get; set; }
    }
}
