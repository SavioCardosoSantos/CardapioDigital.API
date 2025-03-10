using CardapioDigital.Domain.Entities;
using CardapioDigital.Domain.Interfaces;
using CardapioDigital.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CardapioDigital.Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Alterar(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await SaveAllAsync();
        }

        public async Task<Cliente?> BuscarClientePorCpf(string cpf)
        {
            return await _context.Cliente.Where(x => x.Cpf == cpf).FirstOrDefaultAsync();
        }

        public async Task<Cliente?> BuscarClientePorId(int clienteId)
        {
            return await _context.Cliente.Where(x => x.Id == clienteId).FirstOrDefaultAsync();
        }

        public async Task Excluir(Cliente cliente)
        {
            _context.Cliente.Remove(cliente);
            await SaveAllAsync();
        }

        public async Task Inserir(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            await SaveAllAsync();
        }

        public async Task<IEnumerable<Cliente>> ListarTodos()
        {
            return await _context.Cliente.ToListAsync();
        }

        private async Task SaveAllAsync()
        {
            var success = await _context.SaveChangesAsync() > 0;
            if (!success)
                throw new DbUpdateException();
        }
    }
}
