using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Grupo_Celeste.Models;

namespace Grupo_Celeste.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Grupo_Celeste.Services.PeliculasService _peliculasService;

    public HomeController(ILogger<HomeController> logger, Grupo_Celeste.Services.PeliculasService peliculasService)
    {
        _logger = logger;
        _peliculasService = peliculasService;
    }

    public async Task<IActionResult> Index()
    {
        var peliculas = await _peliculasService.ObtenerPeliculasCarteleraAsync();
        return View(peliculas);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
