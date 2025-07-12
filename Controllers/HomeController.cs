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
        juego.InicializarJuego();
        ViewBag.VBIndex = Juego.DicPalabraJuego;
        return View();
    }

    public IActionResult IrAlJuego()
    {
        Juego juego = new Juego();
        juego.InicializarJuego();
        ViewBag.VBJuego = Juego.DicPalabraJuego;
        
        string juegoJson = Objeto.ObjectToString(juego);
        HttpContext.Session.SetString("Juego", juegoJson);

        ViewBag.VBComoVa = juego.Principio();
        ViewBag.ListLetrasUsuario = juego.ListLetrasUsuario;

        return View("Juego");
    }

    public IActionResult CompararLetra(char letra)
    {
        char letraMayus = char.ToUpper(letra);

        string? juegoJson = HttpContext.Session.GetString("Juego");
        if (string.IsNullOrEmpty(juegoJson))
        {
            return RedirectToAction("Index");
        }

        Juego juego = Objeto.StringToObject<Juego>(juegoJson!);

       

        var comoVa = juego.MostarComoVa(letraMayus);

        ViewBag.comoVa = comoVa;
        ViewBag.VBComoVa = comoVa;
        ViewBag.Intentos = juego.contadorInt;
        ViewBag.ListLetrasUsuario = juego.ListLetrasUsuario;
       ViewBag.VBPalabraSelect= juego.palabraSeleccionada;

        if (comoVa != null && !comoVa.Contains('_'))
        {
            ViewBag.VBFrase = "Ganaste";
            ViewBag.VBComoVa = juego.palabraSeleccionada;
        }

        HttpContext.Session.SetString("Juego", Objeto.ObjectToString(juego));

        return View("Juego");
    }
public IActionResult CompararPalabra(string? PalabraUsuario)
{
   
    if (string.IsNullOrEmpty(PalabraUsuario))
    {
        ViewBag.VBFrase = "Perdiste";
        ViewBag.Gano_Perdio = null;
        return View("Juego");
    }

    string? juegoJson = HttpContext.Session.GetString("Juego");
    if (string.IsNullOrEmpty(juegoJson))
    {
        return RedirectToAction("Index");
    }

    Juego juego = Objeto.StringToObject<Juego>(juegoJson!);

    string palabraUsuarioMayus = PalabraUsuario.Trim().ToUpper();
    string palabraCorrectaMayus = juego.palabraSeleccionada.ToUpper();

    if (palabraUsuarioMayus == palabraCorrectaMayus)
    {
        ViewBag.VBFrase = "Ganaste";
        ViewBag.VBComoVa = palabraCorrectaMayus;
      
    }
    else
    {
       ViewBag.VBFrase = "Perdiste";
     ViewBag.VBComoVa = palabraCorrectaMayus;
      
     ViewBag.VBPalabraSelect = palabraCorrectaMayus;
       
       
    }
   
    ViewBag.Intentos = juego.contadorInt;
    ViewBag.ListLetrasUsuario = juego.ListLetrasUsuario;
 ViewBag.VBPalabraSelect = palabraCorrectaMayus;

    HttpContext.Session.SetString("Juego", Objeto.ObjectToString(juego));

    return View("Juego");
}
}