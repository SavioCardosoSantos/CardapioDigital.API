namespace CardapioDigital.Application.DTOs
{
    public class PedidoClienteDTO
    {
        public int Id { get; set; }
        public int RestauranteMesaAtendimentoId { get; set; }
        public int ClienteId { get; set; }
        public ItemCardapioDTO Item { get; set; }
    }
}
