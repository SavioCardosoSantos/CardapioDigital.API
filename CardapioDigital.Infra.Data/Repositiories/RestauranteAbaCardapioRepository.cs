using CardapioDigital.Domain.Entities;
using CardapioDigital.Domain.Interfaces;
using CardapioDigital.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CardapioDigital.Infra.Data.Repositiories
{
    public class RestauranteAbaCardapioRepository : IRestauranteAbaCardapioRepository
    {
        private readonly ApplicationDbContext _context;

        public RestauranteAbaCardapioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Alterar(RestauranteAbaCardapio aba)
        {
            _context.Entry(aba).State = EntityState.Modified;
            await SaveAllAsync();
        }

        public async Task AlterarRange(IEnumerable<RestauranteAbaCardapio> abas)
        {
            foreach (var aba in abas)
                _context.Entry(aba).State = EntityState.Modified;

            await SaveAllAsync();
        }

        public async Task<RestauranteAbaCardapio?> BuscarPorId(int abaId)
        {
            return await _context.RestauranteAbaCardapio.AsNoTracking()
                .Where(x => x.Id == abaId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<RestauranteAbaCardapio>> BuscarPorRestauranteId(int restauranteId)
        {
            return await _context.RestauranteAbaCardapio.AsNoTracking()
                .Where(x => x.RestauranteId == restauranteId)
                .OrderBy(x => x.Ordenacao)
                .ToListAsync();
        }

        public async Task<IEnumerable<RestauranteAbaCardapio>> BuscarPorRestauranteIdIncludeItens(int restauranteId)
        {
            return await _context.RestauranteAbaCardapio.AsNoTracking()
                .Where(x => x.RestauranteId == restauranteId &&
                    x.Itens.Any(i => i.Excluido == 0))
                .Include(x => x.Itens.Where(i => i.Excluido == 0))
                    .ThenInclude(i => i.TagItemCardapios)
                        .ThenInclude(j => j.Tag)
                .OrderBy(x => x.Ordenacao)
                .ToListAsync();
        }

        public async Task<int> BuscarProximaOrdenacao(int restauranteId)
        {
            var aba = await _context.RestauranteAbaCardapio.AsNoTracking()
                .Where(x => x.RestauranteId == restauranteId)
                .OrderByDescending(x => x.Ordenacao)
                .FirstOrDefaultAsync();

            if (aba == null)
                return 1;
            else
                return aba.Ordenacao + 1;
        }

        public async Task Excluir(RestauranteAbaCardapio aba)
        {
            _context.RestauranteAbaCardapio.Remove(aba);
            await SaveAllAsync();
        }

        public async Task Inserir(RestauranteAbaCardapio aba)
        {
            _context.RestauranteAbaCardapio.Add(aba);
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
