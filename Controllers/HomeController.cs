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
         juego juego = new Juego();
        juego.InicializarJuego();
        ViewBag.VBJuego = Juego.DicPalabraJuego;
        
     var miObjeto = new Juego();
     string juegoJson = Objeto.ObjectToString(miObjeto);
     HttpContext.Session.SetString("Juego", juegoJson);
        
        ViewBag.VBComoVa = Juego.Principio();
        ViewBag.ListLetrasUsuario = Juego.ListLetrasUsuario;

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
   
    if (!juego.ListLetrasUsuario.Contains(letraMayus))
    {
        juego.ListLetrasUsuario.Add(letraMayus);
    }

   
    var comoVa = juego.MostarComoVa(letraMayus);

    
    ViewBag.comoVa = comoVa;
    ViewBag.VBComoVa = comoVa;
    ViewBag.Intentos = juego.contadorInt;
    ViewBag.ListLetrasUsuario = juego.ListLetrasUsuario;

   
    if (comoVa != null && !comoVa.Contains('_'))
    {
        ViewBag.VBFrase = "Ganaste!";
        ViewBag.VBComoVa = juego.palabraSeleccionada;
    }

   
    HttpContext.Session.SetString("Juego", Objeto.ObjectToString(juego));

    return View("Juego");
}



   public IActionResult CompararPalabra(string PalabraUsuario)
{
 string? juegoJson = HttpContext.Session.GetString("Juego");
if (string.IsNullOrEmpty(juegoJson))
{
    return RedirectToAction("Index");
}

Juego juego = Objeto.StringToObject<Juego>(juegoJson!);
   
    string palabraUsuarioMayus = PalabraUsuario.ToUpper();
    string palabraCorrectaMayus = juego.palabraSeleccionada.ToUpper();

    if (palabraUsuarioMayus == palabraCorrectaMayus)
    {
        ViewBag.VBFrase = "Ganaste!";
        ViewBag.VBComoVa = palabraCorrectaMayus;
    }
    else
    {
        ViewBag.VBFrase = "Perdiste!";
        ViewBag.VBComoVa = juego.MostarComoVa(' '); 
        juego.contadorInt++; 
    }

    ViewBag.Intentos = juego.contadorInt;
    ViewBag.ListLetrasUsuario = juego.ListLetrasUsuario;

  
    HttpContext.Session.SetString("Juego", Objeto.ObjectToString(juego));

    return View("Juego");
}




}
