using Grupo_Celeste.Models;
using Grupo_Celeste.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Grupo_Celeste.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        // GET: /Auth/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Auth/Register
        [HttpPost]
        public async Task<IActionResult> Register(string nombre, string correo, string celular, string password)
        {
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(celular) || string.IsNullOrWhiteSpace(password))
            {
                ViewBag.Error = "Todos los campos son obligatorios.";
                return View();
            }
            var cliente = await _authService.RegistrarAsync(nombre, correo, celular, password);
            if (cliente == null)
            {
                ViewBag.Error = "El correo ya está registrado.";
                return View();
            }
            // Guardar sesión
            HttpContext.Session.SetInt32("ClienteId", cliente.Id);
            HttpContext.Session.SetString("ClienteNombre", cliente.Nombre);
            return RedirectToAction("Perfil");
        }

        // GET: /Auth/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Auth/Login
        [HttpPost]
        public async Task<IActionResult> Login(string correo, string password)
        {
            var cliente = await _authService.LoginAsync(correo, password);
            if (cliente == null)
            {
                ViewBag.Error = "Correo o contraseña incorrectos.";
                return View();
            }
            HttpContext.Session.SetInt32("ClienteId", cliente.Id);
            HttpContext.Session.SetString("ClienteNombre", cliente.Nombre);
            return RedirectToAction("Perfil");
        }

        // GET: /Auth/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        // GET: /Auth/Perfil
        public IActionResult Perfil()
        {
            if (!HttpContext.Session.TryGetValue("ClienteId", out _))
                return RedirectToAction("Login");
            ViewBag.Nombre = HttpContext.Session.GetString("ClienteNombre");
            return View();
        }
    }
}
