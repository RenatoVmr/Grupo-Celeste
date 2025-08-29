using Grupo_Celeste.Data;
using Grupo_Celeste.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Grupo_Celeste.Services
{
    public class AuthService
    {
        private readonly CineTimeDbContext _context;
        public AuthService(CineTimeDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CorreoExisteAsync(string correo)
        {
            return await _context.Clientes.AnyAsync(c => c.Correo == correo);
        }

        public async Task<Cliente?> RegistrarAsync(string nombre, string correo, string celular, string password)
        {
            if (await CorreoExisteAsync(correo)) return null;
            var cliente = new Cliente
            {
                Nombre = nombre,
                Correo = correo,
                Celular = celular,
                PasswordHash = HashPassword(password)
            };
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente?> LoginAsync(string correo, string password)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Correo == correo);
            if (cliente == null) return null;
            if (!VerifyPassword(password, cliente.PasswordHash)) return null;
            return cliente;
        }

        // Hash y verificación de contraseña (SHA256 simple, puedes cambiar a BCrypt si lo prefieres)
        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
        private bool VerifyPassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }
    }
}
