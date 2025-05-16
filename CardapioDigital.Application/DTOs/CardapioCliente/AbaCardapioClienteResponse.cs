namespace CardapioDigital.Application.DTOs.CardapioCliente
{
    public class AbaCardapioClienteResponse
    {
        public string Nome { get; set; }
        public IEnumerable<ItemCardapioDTO> Itens { get; set; }

        public AbaCardapioClienteResponse() { }

        public AbaCardapioClienteResponse(string nome, IEnumerable<ItemCardapioDTO> itens) 
        { 
            Nome = nome;
            Itens = itens;
        }
    }
}
