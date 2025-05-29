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
        Juego.InicializarJuego();
        ViewBag.VBIndex = Juego.DicPalabraJuego;
        return View();
    }
    public IActionResult IrAlJuego()
    {
         Juego juego = new Juego();
        Juego.InicializarJuego();
        ViewBag.VBJuego = Juego.DicPalabraJuego;
        
        //lo guardamos 
     HttpContext.Session.ObjectToString ("Juego", Objetos.ToString(juego));
        
        ViewBag.VBComoVa = Juego.Principio();
        ViewBag.ListLetrasUsuario = Juego.ListLetrasUsuario;

        return View("Juego");
    }
    public IActionResult CompararLetra(char letra)
    {
       
        Juego juego = new Juego();
        HttpContext.Session.ObjectToString ("Juego", Objetos.ListToString(juego));


        if (!Juego.ListLetrasUsuario.Contains(letra))
        {

            Juego.ListLetrasUsuario.Add(letra);
        }
        var comoVa = Juego.MostarComoVa(letra);
             ViewBag.comoVa = comoVa;
            ViewBag.VBComoVa = comoVa;
            ViewBag.Intentos = Juego.contadorInt;
            

        
            ViewBag.ListLetrasUsuario = Juego.ListLetrasUsuario;

        if (comoVa != null && !comoVa.Contains('_'))
        {
            ViewBag.VBGano_Perdio = "Ganaste";
            ViewBag.VBComoVa = Juego.palabraSeleccionada;
            ViewBag.ListLetrasUsuario = Juego.ListLetrasUsuario;
            ViewBag.Intentos = Juego.contadorInt;
        }
        return View("Juego");

    }



    public IActionResult CompararPalabra(string PalabraUsario)
    {
       
        if (! (PalabraUsario == null || PalabraUsario.Trim() == ""))
        {

            if (PalabraUsario != null && PalabraUsario.Trim().ToLower() == Juego.palabraSeleccionada.Trim().ToLower())
            {
                ViewBag.VBGano_Perdio = "Ganaste";
                ViewBag.VBComoVa = Juego.palabraSeleccionada;
                ViewBag.ListLetrasUsuario = Juego.ListLetrasUsuario;
                ViewBag.Intentos = Juego.contadorInt;
            }
            else
            {
                ViewBag.VBGano_Perdio = "Perdiste";
                Juego.contadorInt++;
                ViewBag.VBPalabraSelect = Juego.palabraSeleccionada;
                ViewBag.ListLetrasUsuario = Juego.ListLetrasUsuario;
                ViewBag.Intentos = Juego.contadorInt;
            }
        }
       ;
        return View("Juego");

    }




}
