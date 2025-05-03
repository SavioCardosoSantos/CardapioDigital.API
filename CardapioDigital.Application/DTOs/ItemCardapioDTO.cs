namespace CardapioDigital.Application.DTOs
{
    public class ItemCardapioDTO
    {
        public int Id { get; set; }
        public int RestauranteId { get; set; }
        public int AbaCardapioId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string ImagemBase64 { get; set; }
        public decimal Preco { get; set; }
        public int Disponivel { get; set; }
        public int ServeQtdPessoas { get; set; }
    }
}
