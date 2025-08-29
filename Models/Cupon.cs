using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo_Celeste.Models
{
    public class Cupon
    {
        public int Id { get; set; }
        [Required]
        public string Codigo { get; set; } = string.Empty;
        public decimal Descuento { get; set; } // Porcentaje o monto
        public bool Usado { get; set; } = false;
        public int? ClienteId { get; set; }
        public int PromocionId { get; set; }
        [ForeignKey("PromocionId")]
        public Promocion? Promocion { get; set; }
    }
}
