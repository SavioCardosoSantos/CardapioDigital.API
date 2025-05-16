using CardapioDigital.Domain.Entities;
using CardapioDigital.Domain.Interfaces;
using CardapioDigital.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CardapioDigital.Infra.Data.Repositiories
{
    public class AtendimentoPedidoClienteRepository : IAtendimentoPedidoClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public AtendimentoPedidoClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AtendimentoPedidoCliente>> BuscarTodosPedidosPorClienteIdIncludingItens(int clienteId)
        {
            return await _context.AtendimentoPedidoCliente.AsNoTracking()
                .Where(x => x.ClienteId == clienteId)
                .Include(x => x.Item)
                    .ThenInclude(i => i.TagItemCardapios)
                        .ThenInclude(j => j.Tag)
                .ToListAsync();
        }
    }
}
