using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo_Celeste.Models
{
    public class Horario
    {
        public int Id { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public string Hora { get; set; } = string.Empty; // Ejemplo: "19:30"
        [Required]
        public string Cine { get; set; } = string.Empty;
        [Required]
        public string Ciudad { get; set; } = string.Empty;
        public string? Sala { get; set; }

        // Relación con Pelicula
        public int PeliculaId { get; set; }
        [ForeignKey("PeliculaId")]
        public Pelicula? Pelicula { get; set; }
    }
}
