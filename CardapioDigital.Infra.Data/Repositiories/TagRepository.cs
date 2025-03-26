using CardapioDigital.Domain.Entities;
using CardapioDigital.Domain.Interfaces;
using CardapioDigital.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CardapioDigital.Infra.Data.Repositiories
{
    public class TagRepository : ITagRepository
    {
        private readonly ApplicationDbContext _context;

        public TagRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Inserir(Tag tag)
        {
            _context.Tag.Add(tag);
            await SaveAllAsync();
        }

        public async Task Alterar(Tag tag)
        {
            _context.Entry(tag).State = EntityState.Modified;
            await SaveAllAsync();
        }

        public async Task<Tag?> BuscarPorTexto(string texto)
        {
            return await _context.Tag.AsNoTracking()
                .Where(x => x.Texto.ToLower() == texto.ToLower())
                .FirstOrDefaultAsync();
        }

        private async Task SaveAllAsync()
        {
            var success = await _context.SaveChangesAsync() > 0;
            if (!success)
                throw new DbUpdateException();
        }
    }
}
