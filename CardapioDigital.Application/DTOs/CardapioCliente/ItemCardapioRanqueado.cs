namespace CardapioDigital.Application.DTOs.CardapioCliente
{
    public class ItemCardapioRanqueado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<string> Tags { get; set; }
        public int Score { get; set; }
    }
}
