using CardapioDigital.Domain.Entities;
using CardapioDigital.Domain.Interfaces;
using CardapioDigital.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CardapioDigital.Infra.Data.Repositiories
{
    public class RestauranteItemCardapioRepository : IRestauranteItemCardapioRepository
    {
        private readonly ApplicationDbContext _context;

        public RestauranteItemCardapioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Inserir(RestauranteItemCardapio item)
        {
            _context.RestauranteItemCardapio.Add(item);
            await SaveAllAsync();
        }

        public async Task Alterar(RestauranteItemCardapio item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await SaveAllAsync();
        }

        public async Task<RestauranteItemCardapio?> BuscarPorId(int itemId)
        {
            return await _context.RestauranteItemCardapio.AsNoTracking()
                .Where(i => i.Id == itemId && i.Excluido == 0)
                .Include(i => i.TagItemCardapios)
                .ThenInclude(tic => tic.Tag)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<RestauranteItemCardapio>> ListarPorRestauranteId(int restauranteId)
        {
            return await _context.RestauranteItemCardapio.AsNoTracking()
                .Where(i => i.RestauranteId == restauranteId && i.Excluido == 0)
                .Include(i => i.TagItemCardapios)
                .ThenInclude(tic => tic.Tag)
                .ToListAsync();
        }

        public async Task<IEnumerable<RestauranteItemCardapio>> ListarPorAbaId(int abaId)
        {
            return await _context.RestauranteItemCardapio.AsNoTracking()
                .Where(i => i.AbaCardapioId == abaId && i.Excluido == 0)
                .Include(i => i.TagItemCardapios)
                .ThenInclude(tic => tic.Tag)
                .ToListAsync();
        }

        private async Task SaveAllAsync()
        {
            var success = await _context.SaveChangesAsync() > 0;
            if (!success)
                throw new DbUpdateException();
        }
    }
}
