using CardapioDigital.Domain.Entities;
using CardapioDigital.Domain.Interfaces;
using CardapioDigital.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CardapioDigital.Infra.Data.Repositiories
{
    public class TagItemCardapioRepository : ITagItemCardapioRepository
    {
        private readonly ApplicationDbContext _context;

        public TagItemCardapioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Inserir(TagItemCardapio tagItemCardapio)
        {
            _context.TagItemCardapio.Add(tagItemCardapio);
            await SaveAllAsync();
        }

        public async Task Alterar(TagItemCardapio tagItemCardapio)
        {
            _context.Entry(tagItemCardapio).State = EntityState.Modified;
            await SaveAllAsync();
        }

        public async Task Excluir(TagItemCardapio tagItemCardapio)
        {
            _context.TagItemCardapio.Remove(tagItemCardapio);
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
