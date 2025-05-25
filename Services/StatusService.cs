using Microsoft.EntityFrameworkCore;
using MottuControlApi.Data;
using MottuControlApi.Models;

namespace MottuControlApi.Services
{
    public class StatusService
    {
        private readonly AppDbContext _context;

        public StatusService(AppDbContext context)
        {
            _context = context;
        }

        // Lista todos os status com a moto associada
        public async Task<List<StatusMonitoramento>> GetAllAsync()
        {
            return await _context.StatusMonitoramentos
                .Include(s => s.Moto)
                .ToListAsync();
        }

        // Retorna um status por ID
        public async Task<StatusMonitoramento?> GetByIdAsync(int id)
        {
            return await _context.StatusMonitoramentos
                .Include(s => s.Moto)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        // Lista o histórico de status de uma moto por ID da moto
        public async Task<List<StatusMonitoramento>> GetByMotoIdAsync(int motoId)
        {
            return await _context.StatusMonitoramentos
                .Where(s => s.MotoId == motoId)
                .Include(s => s.Moto)
                .OrderByDescending(s => s.DataHora)
                .ToListAsync();
        }

        // Cria um novo status para uma moto
        public async Task<StatusMonitoramento> CriarAsync(StatusMonitoramento status)
        {
            status.DataHora = DateTime.UtcNow;

            _context.StatusMonitoramentos.Add(status);
            await _context.SaveChangesAsync();
            return status;
        }

        // Atualiza um status existente
        public async Task<bool> AtualizarAsync(int id, StatusMonitoramento status)
        {
            if (id != status.Id) return false;

            _context.Entry(status).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.StatusMonitoramentos.AnyAsync(s => s.Id == id))
                    return false;

                throw;
            }
        }

        // Deleta um status por ID
        public async Task<bool> DeletarAsync(int id)
        {
            var status = await _context.StatusMonitoramentos.FindAsync(id);
            if (status == null) return false;

            _context.StatusMonitoramentos.Remove(status);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
