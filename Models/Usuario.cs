public class Usuario
{

    public string nombre { get; private set; }
    public int CantidadIntentos { get; private set; }

    public Usuario(string pnombre, int PCantidadIntentos)
    {
        nombre = pnombre;
        CantidadIntentos = PCantidadIntentos;


    }


    public void ActualizarIntentos(int intentos)
    {
        CantidadIntentos = intentos;
    }
}