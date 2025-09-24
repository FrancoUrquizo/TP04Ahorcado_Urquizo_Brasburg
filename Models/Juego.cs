using System;
using System.Collections.Generic;
using System.Linq;

public class Juego
{
    //poner lo de jasopnProperty
   
    public List<char> ListLetrasUsuario = new List<char>();

    public int contadorInt { get; set; }
    public int ultimoId { get; private set; }
    public List<Palabra> posiblesPalabras = new List<Palabra>();
    public Usuario UsuarioActual;
    public List<Usuario> ListUsu { get; set; } = new List<Usuario>();

    public string palabraSeleccionada = "";
    private static readonly Random rng = new Random();

    public void InicializarJuego(string NombreUsuario, int dificultad)
    {
        LlenarPalabras();
        ListLetrasUsuario = new List<char>();
        contadorInt = 0;

        palabraSeleccionada = CargarPalabra(dificultad)?.ToUpper() ?? "";

    
        ultimoId++;
        UsuarioActual = new Usuario(NombreUsuario, contadorInt);
    }



    public char[] Principio()
    {
        char[] comoVa = new char[palabraSeleccionada.Length];

        for (int i = 0; i < palabraSeleccionada.Length; i++)
        {
            comoVa[i] = '_';
        }
        
        return comoVa;
        
    }

    private void LlenarPalabras()
    {
        posiblesPalabras = new List<Palabra>
        {
            // Dificultad 1
            new Palabra("gato", 1),
            new Palabra("sol", 1),
            new Palabra("mesa", 1),
            new Palabra("luz", 1),
            new Palabra("flor", 1),
            new Palabra("pan", 1),
            new Palabra("pez", 1),
            new Palabra("libro", 1),
            new Palabra("casa", 1),
            new Palabra("perro", 1),
            // Dificultad 2
            new Palabra("ratón", 2),
            new Palabra("planta", 2),
            new Palabra("camisa", 2),
            new Palabra("zapato", 2),
            new Palabra("jardín", 2),
            new Palabra("silla", 2),
            new Palabra("escuela", 2),
            new Palabra("amigo", 2),
            new Palabra("estrella", 2),
            new Palabra("pelota", 2),
            // Dificultad 3
            new Palabra("murciélago", 3),
            new Palabra("elefante", 3),
            new Palabra("computadora", 3),
            new Palabra("carretera", 3),
            new Palabra("mariposa", 3),
            new Palabra("tormenta", 3),
            new Palabra("cementerio", 3),
            new Palabra("cuchara", 3),
            new Palabra("pirámide", 3),
            new Palabra("ventana", 3),
            // Dificultad 4
            new Palabra("hipopótamo", 4),
            new Palabra("biblioteca", 4),
            new Palabra("microondas", 4),
            new Palabra("paralelepípedo", 4),
            new Palabra("refrigerador", 4),
            new Palabra("desoxirribonucleico", 4),
            new Palabra("circunferencia", 4),
            new Palabra("inconstitucional", 4),
            new Palabra("otorrinolaringólogo", 4),
            new Palabra("transustanciación", 4)
        };
    }


      public string CargarPalabra(int dificultad)
    {
        var candidatos = posiblesPalabras.Where(p => p.Dificultad == dificultad).ToList();
        if (candidatos.Count == 0) return string.Empty;

        int idx = rng.Next(0, candidatos.Count);
        return candidatos[idx].Texto;
    }

    public void FinalizarJuego(int intentos)
    {
        UsuarioActual.ActualizarIntentos(intentos);
        ListUsu.Add(UsuarioActual);
    }

    public List<Usuario> DevolverListaUsuarios()
    {

        ListUsu = ListUsu.OrderBy(UsuarioActual => UsuarioActual.CantidadIntentos).ToList();
        return ListUsu;
    }

}