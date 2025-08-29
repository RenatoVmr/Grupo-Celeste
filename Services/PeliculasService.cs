using Grupo_Celeste.Data;
using Grupo_Celeste.Models;
using Microsoft.EntityFrameworkCore;

namespace Grupo_Celeste.Services
{
    public class PeliculasService
    {
        private readonly CineTimeDbContext _context;
        public PeliculasService(CineTimeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pelicula>> ObtenerPeliculasCarteleraAsync()
        {
            // Aquí puedes agregar lógica para filtrar solo las películas en cartelera
            return await _context.Peliculas.OrderByDescending(p => p.FechaEstreno).ToListAsync();
        }
    }
}
