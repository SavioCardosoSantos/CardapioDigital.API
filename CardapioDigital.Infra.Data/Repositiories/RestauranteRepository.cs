using CardapioDigital.Domain.Entities;
using CardapioDigital.Domain.Interfaces;
using CardapioDigital.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CardapioDigital.Infra.Data.Repositiories
{
    public class RestauranteRepository : IRestauranteRepository
    {
        private readonly ApplicationDbContext _context;

        public RestauranteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Alterar(Restaurante restaurante)
        {
            _context.Entry(restaurante).State = EntityState.Modified;
            await SaveAllAsync();
        }

        public async Task<Restaurante?> BuscarPorEmail(string email)
        {
            return await _context.Restaurante.AsNoTracking()
                .Where(x => x.Email.ToLower() == email.ToLower() && x.Excluido == 0)
                .FirstOrDefaultAsync();
        }

        public async Task<Restaurante?> BuscarPorId(int restauranteId)
        {
            return await _context.Restaurante.AsNoTracking()
                .Where(x => x.Id == restauranteId && x.Excluido == 0)
                .FirstOrDefaultAsync();
        }

        public async Task<Restaurante?> BuscarPorIdWithExcluidos(int restauranteId)
        {
            return await _context.Restaurante.AsNoTracking()
                .Where(x => x.Id == restauranteId)
                .FirstOrDefaultAsync();
        }

        public async Task Inserir(Restaurante restaurante)
        {
            _context.Restaurante.Add(restaurante);
            await SaveAllAsync();
        }

        public async Task<IEnumerable<Restaurante>> ListarTodos()
        {
            return await _context.Restaurante.AsNoTracking()
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
