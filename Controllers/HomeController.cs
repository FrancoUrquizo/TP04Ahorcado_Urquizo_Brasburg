using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP04_Urquizo_Brasburg.Models;

namespace TP04_Urquizo_Brasburg.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Juego juego = new Juego();
        
       
        ViewBag.VBIndexJugadores = juego.ListUsu;
HttpContext.Session.SetString("Juego", Objeto.ObjectToString(juego));
       
        return View("Index");

    }

[HttpPost]
    public IActionResult IrAlJuego(string username, int dificultad)
    {
        string? juegoJson = HttpContext.Session.GetString("Juego");
        Juego juego = Objeto.StringToObject<Juego>(juegoJson!);
      
        juego.InicializarJuego(username, dificultad);
   
ViewBag.VBListJugadores = juego.ListUsu ?? new List<Usuario>();
        ViewBag.VBNombre = juego.UsuarioActual.nombre;
        ViewBag.VBComoVa = juego.Principio();
        ViewBag.ListLetrasUsuario = juego.ListLetrasUsuario;
        ViewBag.PalabraElejida = juego.CargarPalabra(dificultad);
ViewBag.VBIntentos = Usuario.CantidadIntentos;
 HttpContext.Session.SetString("Juego", Objeto.ObjectToString(juego));

        return View("Juego");
    }

[HttpPost]

public IActionResult FinJuego(int intentos)
{
    string? juegoJson = HttpContext.Session.GetString("Juego");
    Juego juego = Objeto.StringToObject<Juego>(juegoJson!);

     ViewBag.VBIntentos = juego.UsuarioActual.CantidadIntentos;
juego.FinalizarJuego(intentos);

    return View("Index");

}


















}