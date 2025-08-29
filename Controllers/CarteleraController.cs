using Grupo_Celeste.Models;
using Grupo_Celeste.Services;
using Microsoft.AspNetCore.Mvc;

namespace Grupo_Celeste.Controllers
{
    public class CarteleraController : Controller
    {
        private readonly CarteleraService _carteleraService;
        public CarteleraController(CarteleraService carteleraService)
        {
            _carteleraService = carteleraService;
        }

        // GET: /Cartelera
        public async Task<IActionResult> Index(string? genero, string? ciudad, string? cine, DateTime? fecha)
        {
            var peliculas = await _carteleraService.ObtenerPeliculasConHorariosAsync(genero, ciudad, cine, fecha);
            ViewBag.Filtros = new { genero, ciudad, cine, fecha };
            return View(peliculas);
        }

        // GET: /Cartelera/Detalle/5
        public async Task<IActionResult> Detalle(int id)
        {
            var pelicula = await _carteleraService.ObtenerPeliculaPorIdAsync(id);
            if (pelicula == null) return NotFound();
            return View(pelicula);
        }
    }

}
// Llave de cierre agregada para corregir el error de sintaxis
