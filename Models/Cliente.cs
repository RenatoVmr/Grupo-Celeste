using System.ComponentModel.DataAnnotations;

namespace Grupo_Celeste.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Correo { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Celular { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        // Otros campos: historial, promociones, etc. pueden agregarse luego
    }
}
