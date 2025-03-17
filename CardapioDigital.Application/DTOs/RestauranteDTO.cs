using CardapioDigital.Util.Enums;

namespace CardapioDigital.Application.DTOs
{
    public class RestauranteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public eStatusRestaurante Status { get; set; }
    }
}
