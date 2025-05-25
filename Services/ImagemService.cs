using Microsoft.EntityFrameworkCore;
using MottuControlApi.Data;
using MottuControlApi.Models;

namespace MottuControlApi.Services
{
    public class ImagemService
    {
        private readonly AppDbContext _context;

        public ImagemService(AppDbContext context)
        {
            _context = context;
        }

        // Retorna todas as imagens com seus respectivos pátios
        public async Task<List<ImagemPatio>> GetAllAsync()
        {
            return await _context.ImagensPatio
                .Include(i => i.Patio)
                .ToListAsync();
        }

        // Retorna uma imagem específica por ID
        public async Task<ImagemPatio?> GetByIdAsync(int id)
        {
            return await _context.ImagensPatio
                .Include(i => i.Patio)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        // Lista todas as imagens de um determinado pátio, ordenadas por data
        public async Task<List<ImagemPatio>> GetByPatioIdAsync(int patioId)
        {
            return await _context.ImagensPatio
                .Where(i => i.PatioId == patioId)
                .Include(i => i.Patio)
                .OrderByDescending(i => i.DataCaptura)
                .ToListAsync();
        }

        // Cria uma nova imagem associada a um pátio
        public async Task<ImagemPatio> CriarAsync(ImagemPatio imagem)
        {
            imagem.DataCaptura = DateTime.UtcNow;

            _context.ImagensPatio.Add(imagem);
            await _context.SaveChangesAsync();
            return imagem;
        }

        // Atualiza uma imagem existente
        public async Task<bool> AtualizarAsync(int id, ImagemPatio imagem)
        {
            if (id != imagem.Id) return false;

            _context.Entry(imagem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.ImagensPatio.AnyAsync(i => i.Id == id))
                    return false;

                throw;
            }
        }

        // Deleta uma imagem por ID
        public async Task<bool> DeletarAsync(int id)
        {
            var imagem = await _context.ImagensPatio.FindAsync(id);
            if (imagem == null) return false;

            _context.ImagensPatio.Remove(imagem);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
