using System.ComponentModel.DataAnnotations;

namespace Grupo_Celeste.Models
{
    public class Promocion
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Activa { get; set; } = true;
        public ICollection<Cupon>? Cupones { get; set; }
    }
}
