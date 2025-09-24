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
          string? juegoJson = HttpContext.Session.GetString("Juego");
            Juego juego;
            if (string.IsNullOrEmpty(juegoJson))
            {
                juego = new Juego();
                HttpContext.Session.SetString("Juego", Objeto.ObjectToString(juego));
            }
            else
            {
                juego = Objeto.StringToObject<Juego>(juegoJson!);
            }

            ViewBag.VBIndexJugadores = juego.ListUsu;
       
        return View("Layout");

    }


public IActionResult irAPagPrinc(){

  return View("Index");
}


[HttpPost]
public IActionResult IrAlJuego(string username, int dificultad)
{
    string? juegoJson = HttpContext.Session.GetString("Juego");
    Juego juego = Objeto.StringToObject<Juego>(juegoJson!);
    juego.InicializarJuego(username, dificultad);

  
    ViewBag.PalabraElejida = juego.palabraSeleccionada;
    ViewBag.VBComoVa = juego.Principio();

    ViewBag.ListLetrasUsuario = juego.ListLetrasUsuario;
  
    ViewBag.VBNombre = juego.UsuarioActual.nombre;
    ViewBag.VBIntentos = juego.UsuarioActual.CantidadIntentos;

    HttpContext.Session.SetString("Juego", Objeto.ObjectToString(juego));

    return View("Juego");
}


[HttpPost]

public IActionResult FinJuego(int intentos)
{
    string? juegoJson = HttpContext.Session.GetString("Juego");
            if (string.IsNullOrEmpty(juegoJson)) return RedirectToAction("Index");

            Juego juego = Objeto.StringToObject<Juego>(juegoJson!);
            juego.FinalizarJuego(intentos);

        
            HttpContext.Session.SetString("Juego", Objeto.ObjectToString(juego));

            ViewBag.VBIndexJugadores = juego.ListUsu.OrderBy(u => u.CantidadIntentos).ToList();
            ViewBag.VBIntentos = juego.UsuarioActual?.CantidadIntentos ?? 0;

    return View("Index");

}

}