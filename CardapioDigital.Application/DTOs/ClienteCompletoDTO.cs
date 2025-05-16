namespace CardapioDigital.Application.DTOs
{
    public class ClienteCompletoDTO : ClienteDTO
    {
        public List<TagClienteDTO> TagClientes { get; set; } = new List<TagClienteDTO>();
        public List<RestricaoAlimentarClienteDTO> RestricaoAlimentarClientes { get; set; } = new List<RestricaoAlimentarClienteDTO>();
    }
}
