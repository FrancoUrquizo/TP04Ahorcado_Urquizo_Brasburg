//falta controllers

// hay que pasar topdo esto a java 
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
