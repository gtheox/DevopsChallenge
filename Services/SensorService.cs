using Microsoft.EntityFrameworkCore;
using MottuControlApi.Data;
using MottuControlApi.Models;

namespace MottuControlApi.Services
{
    public class SensorService
    {
        private readonly AppDbContext _context;

        public SensorService(AppDbContext context)
        {
            _context = context;
        }

        // Listar todos os sensores com suas motos vinculadas
        public async Task<List<SensorIoT>> GetAllAsync()
        {
            return await _context.Sensores
                .Include(s => s.Moto)
                .ToListAsync();
        }

        // Obter sensor por ID com moto vinculada
        public async Task<SensorIoT?> GetByIdAsync(int id)
        {
            return await _context.Sensores
                .Include(s => s.Moto)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        // Buscar sensores por tipo (ex: GPS, RFID)
        public async Task<List<SensorIoT>> BuscarPorTipoAsync(string tipo)
        {
            return await _context.Sensores
                .Where(s => s.Tipo.ToLowerInvariant().Contains(tipo.ToLowerInvariant()))
                .Include(s => s.Moto)
                .ToListAsync();
        }

        // Criar novo sensor
        public async Task<SensorIoT> CriarAsync(SensorIoT sensor)
        {
            _context.Sensores.Add(sensor);
            await _context.SaveChangesAsync();
            return sensor;
        }

        // Atualizar sensor existente
        public async Task<bool> AtualizarAsync(int id, SensorIoT sensor)
        {
            if (id != sensor.Id) return false;

            _context.Entry(sensor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Sensores.AnyAsync(s => s.Id == id))
                    return false;

                throw;
            }
        }

        // Deletar sensor por ID
        public async Task<bool> DeletarAsync(int id)
        {
            var sensor = await _context.Sensores.FindAsync(id);
            if (sensor == null) return false;

            _context.Sensores.Remove(sensor);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
