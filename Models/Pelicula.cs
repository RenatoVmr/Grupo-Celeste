using System.ComponentModel.DataAnnotations;

namespace Grupo_Celeste.Models
{
    public class Pelicula
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; } = string.Empty;
        public string? Sinopsis { get; set; }
        public string? Genero { get; set; }
        public string? Clasificacion { get; set; }
        public string? ImagenUrl { get; set; }
        public string? TrailerUrl { get; set; }
        public DateTime FechaEstreno { get; set; }
    }
}
