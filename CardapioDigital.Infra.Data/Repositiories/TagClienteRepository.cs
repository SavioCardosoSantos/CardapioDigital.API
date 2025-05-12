using CardapioDigital.Domain.Entities;
using CardapioDigital.Domain.Interfaces;
using CardapioDigital.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CardapioDigital.Infra.Data.Repositiories
{
    public class TagClienteRepository : ITagClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public TagClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InserirRange(IEnumerable<TagCliente> listTagCliente)
        {
            _context.TagCliente.AddRange(listTagCliente);
            await SaveAllAsync();
        }

        public async Task ExcluirRange(int clienteId)
        {
            var tagsCliente = _context.TagCliente
                .Where(x => x.ClienteId == clienteId)
                .ToList();

            _context.TagCliente.RemoveRange(tagsCliente);
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
