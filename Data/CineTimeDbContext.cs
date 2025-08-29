using Microsoft.EntityFrameworkCore;
using Grupo_Celeste.Models;

namespace Grupo_Celeste.Data
{
    public class CineTimeDbContext : DbContext
    {
        public CineTimeDbContext(DbContextOptions<CineTimeDbContext> options) : base(options) { }

    public DbSet<Pelicula> Peliculas { get; set; }
    public DbSet<Horario> Horarios { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Promocion> Promociones { get; set; }
    public DbSet<Cupon> Cupones { get; set; }
    }
}
