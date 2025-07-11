using System;
using System.Collections.Generic;
using System.Linq;

public class Juego
{
    public static Dictionary<int, string> DicPalabraJuego = new Dictionary<int, string>();
    public List<char> ListLetrasUsuario = new List<char>();

    public int contadorInt { get; set; }
    public int ultimoId { get; private set; }
    public List<string> posiblesPalabras = new List<string> { "auto", "vaso", "casa", "gatos", "mouse", "perro" };
    public string palabraSeleccionada = "";

    public void InicializarJuego()
    {
        Random random = new Random();
        ListLetrasUsuario = new List<char>();
        contadorInt = 0;
        palabraSeleccionada = posiblesPalabras[random.Next(posiblesPalabras.Count)].ToUpper(); 
        ultimoId++;
        DicPalabraJuego[ultimoId] = palabraSeleccionada;
    } 

    public char[] MostarComoVa(char LetrasUsuario)
    {
        LetrasUsuario = char.ToUpper(LetrasUsuario); 
        char[] comoVa = Principio();

      

        if (!ListLetrasUsuario.Contains(LetrasUsuario) && LetrasUsuario != ' ')
        {
            ListLetrasUsuario.Add(LetrasUsuario);
           
             contadorInt++;
        }
       

        for (int i = 0; i < palabraSeleccionada.Length; i++)
        {
            if (ListLetrasUsuario.Contains(palabraSeleccionada[i]))
            {
                comoVa[i] = palabraSeleccionada[i];
            }
        }

        return comoVa;
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
}