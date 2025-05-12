using CardapioDigital.Domain.Entities;
using CardapioDigital.Domain.Interfaces;
using CardapioDigital.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CardapioDigital.Infra.Data.Repositiories
{
    public class RestricaoAlimentarClienteRepository : IRestricaoAlimentarClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public RestricaoAlimentarClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InserirRange(IEnumerable<RestricaoAlimentarCliente> listRestricaoCliente)
        {
            _context.RestricaoAlimentarCliente.AddRange(listRestricaoCliente);
            await SaveAllAsync();
        }

        public async Task ExcluirRange(int clienteId)
        {
            var restricoesCliente = _context.RestricaoAlimentarCliente
                .Where(x => x.ClienteId == clienteId)
                .ToList();

            _context.RestricaoAlimentarCliente.RemoveRange(restricoesCliente);
            await SaveAllAsync();
        }

        private async Task SaveAllAsync()
        {
            var success = await _context.SaveChangesAsync() > 0;
            if (!success)
                throw new DbUpdateException();
        }
    }
}
