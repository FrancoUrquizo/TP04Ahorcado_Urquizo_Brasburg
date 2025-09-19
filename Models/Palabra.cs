public class Palabra
{
    public string Texto { get; private set; }
    public int Dificultad { get; private set; }

    public Palabra(string ptexto, int pdificultad)
    {
        Texto = ptexto;
        Dificultad = pdificultad;
    }
}
