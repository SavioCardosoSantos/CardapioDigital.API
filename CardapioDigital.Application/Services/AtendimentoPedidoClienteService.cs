using AutoMapper;
using CardapioDigital.Application.DTOs;
using CardapioDigital.Application.Interfaces;
using CardapioDigital.Domain.Interfaces;

namespace CardapioDigital.Application.Services
{
    public class AtendimentoPedidoClienteService : IAtendimentoPedidoClienteService
    {
        private readonly IAtendimentoPedidoClienteRepository _repository;
        private readonly IMapper _mapper;

        public AtendimentoPedidoClienteService(IAtendimentoPedidoClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PedidoClienteDTO>> BuscarTodosPedidosPorClienteIdIncludingItens(int clienteId)
        {
            var pedidos = await _repository.BuscarTodosPedidosPorClienteIdIncludingItens(clienteId);
            
            var pedidosDto = new List<PedidoClienteDTO>();
            foreach (var pedido in pedidos)
            {
                var pedidoDto = _mapper.Map<PedidoClienteDTO>(pedido);
                foreach (var tagItem in pedido.Item.TagItemCardapios)
                    pedidoDto.Item.Tags.Add(tagItem.Tag.Texto);

                pedidosDto.Add(pedidoDto);
            }

            return pedidosDto;
        }
    }
}
