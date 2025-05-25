using Microsoft.EntityFrameworkCore;
using MottuControlApi.Data;
using MottuControlApi.Models;

namespace MottuControlApi.Services
{
    public class PatioService
    {
        private readonly AppDbContext _context;

        public PatioService(AppDbContext context)
        {
            _context = context;
        }

        // Listar todos os pátios com suas motos e imagens
        public async Task<List<Patio>> GetAllAsync()
        {
            return await _context.Patios
                .Include(p => p.Motos)
                .Include(p => p.Imagens)
                .ToListAsync();
        }

        // Buscar um pátio pelo ID com suas motos e imagens
        public async Task<Patio?> GetByIdAsync(int id)
        {
            return await _context.Patios
                .Include(p => p.Motos)
                .Include(p => p.Imagens)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        // Buscar pátios por nome contendo uma substring
        public async Task<List<Patio>> BuscarPorNomeAsync(string nome)
        {
            return await _context.Patios
                .Include(p => p.Motos)
                .Include(p => p.Imagens)
                .Where(p => p.Nome.ToLowerInvariant().Contains(nome.ToLowerInvariant()))
                .ToListAsync();
        }

        // Criar novo pátio
        public async Task<Patio> CriarAsync(Patio patio)
        {
            _context.Patios.Add(patio);
            await _context.SaveChangesAsync();
            return patio;
        }

        // Atualizar dados de um pátio
        public async Task<bool> AtualizarAsync(int id, Patio patio)
        {
            if (id != patio.Id) return false;

            _context.Entry(patio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Patios.AnyAsync(p => p.Id == id))
                    return false;

                throw;
            }
        }

        // Remover pátio
        public async Task<bool> DeletarAsync(int id)
        {
            var patio = await _context.Patios.FindAsync(id);
            if (patio == null) return false;

            _context.Patios.Remove(patio);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
