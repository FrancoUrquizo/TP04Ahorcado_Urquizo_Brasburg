public static class Juego
{
    public static Dictionary<int, string> DicPalabraJuego = new Dictionary<int, string>();
    public static List<char> ListLetrasUsuario = new List<char>();

    public static int contadorInt { get; set; }
    public static int ultimoId { get; private set; }
    public static List<string> posiblesPalabras = new List<string> { "auto", "vaso", "casa", "gatos", "mouse", "perro" };
    public static string palabraSeleccionada = "";
    public static void InicializarJuego()
    {
        Random random = new Random();
        ListLetrasUsuario = new List<char>();
        contadorInt = 0;
        palabraSeleccionada = posiblesPalabras[random.Next(posiblesPalabras.Count)];
        ultimoId++;
        DicPalabraJuego.Add(ultimoId, palabraSeleccionada);
        

    }

    public static char[] MostarComoVa(char LetrasUsuario)
    {
       
        char[] comoVa = new char[palabraSeleccionada.Length];

        comoVa = Principio(); 
        
        contadorInt++;


      

       if (!ListLetrasUsuario.Contains(LetrasUsuario))
        {
            ListLetrasUsuario.Add(LetrasUsuario);
             
        }

        for (int i = 0; i < palabraSeleccionada.Length ; i++)
        {

           
                if (ListLetrasUsuario.Contains(palabraSeleccionada[i] ))
                {
                    comoVa[i] = palabraSeleccionada[i];
                }

           

        }
       
        return comoVa;

    }
   
public static char[] Principio ()
{
        char[] comoVa = new char[palabraSeleccionada.Length];

      for (int i = 0; i < palabraSeleccionada.Count(); i++)
        {
            comoVa[i] = '_';

        }
        return comoVa;
}




}