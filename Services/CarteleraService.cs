using Grupo_Celeste.Data;
using Grupo_Celeste.Models;
using Microsoft.EntityFrameworkCore;

namespace Grupo_Celeste.Services
{
    public class CarteleraService
    {
        private readonly CineTimeDbContext _context;
        public CarteleraService(CineTimeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pelicula>> ObtenerPeliculasConHorariosAsync(string? genero = null, string? ciudad = null, string? cine = null, DateTime? fecha = null)
        {
            var query = _context.Peliculas.Include(p => p.Horarios).AsQueryable();
            if (!string.IsNullOrEmpty(genero))
                query = query.Where(p => p.Genero == genero);
            if (fecha.HasValue)
                query = query.Where(p => p.Horarios.Any(h => h.Fecha.Date == fecha.Value.Date));
            if (!string.IsNullOrEmpty(ciudad))
                query = query.Where(p => p.Horarios.Any(h => h.Ciudad == ciudad));
            if (!string.IsNullOrEmpty(cine))
                query = query.Where(p => p.Horarios.Any(h => h.Cine == cine));
            return await query.ToListAsync();
        }

        public async Task<Pelicula?> ObtenerPeliculaPorIdAsync(int id)
        {
            return await _context.Peliculas.Include(p => p.Horarios).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
