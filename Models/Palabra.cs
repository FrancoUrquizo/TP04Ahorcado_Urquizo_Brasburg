public class Palabra
{
    private string texto { get; private set; }
    private int dificultad { get; private set; }

    public Palabra(string ptexto, int pdificultad)
    {
        texto = ptexto;
        dificultad = pdificultad;
    }
}
