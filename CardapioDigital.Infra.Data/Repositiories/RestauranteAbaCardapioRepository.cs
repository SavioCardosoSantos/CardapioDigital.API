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
                .ToListAsync();
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
