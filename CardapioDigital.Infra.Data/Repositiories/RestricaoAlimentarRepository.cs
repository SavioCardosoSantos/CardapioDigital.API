using CardapioDigital.Domain.Entities;
using CardapioDigital.Domain.Interfaces;
using CardapioDigital.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CardapioDigital.Infra.Data.Repositiories
{
    public class RestricaoAlimentarRepository : IRestricaoAlimentarRepository
    {
        private readonly ApplicationDbContext _context;

        public RestricaoAlimentarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Inserir(RestricaoAlimentar restricao)
        {
            _context.RestricaoAlimentar.Add(restricao);
            await SaveAllAsync();
        }

        public async Task Alterar(RestricaoAlimentar restricao)
        {
            _context.Entry(restricao).State = EntityState.Modified;
            await SaveAllAsync();
        }

        public async Task<RestricaoAlimentar?> BuscarPorTexto(string texto)
        {
            return await _context.RestricaoAlimentar.AsNoTracking()
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
