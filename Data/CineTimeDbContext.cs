using Microsoft.EntityFrameworkCore;
using Grupo_Celeste.Models;

namespace Grupo_Celeste.Data
{
    public class CineTimeDbContext : DbContext
    {
        public CineTimeDbContext(DbContextOptions<CineTimeDbContext> options) : base(options) { }

        public DbSet<Pelicula> Peliculas { get; set; }
        // Aquí se agregarán más DbSet para otras entidades
    }
}
