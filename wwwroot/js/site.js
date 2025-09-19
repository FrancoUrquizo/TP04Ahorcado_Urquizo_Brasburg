//falta controllers

// hay que pasar topdo esto a java 

function Juego(PalabraAdivinar) {
    let palabraUser = document.getElementById('IdPalabra').value;
    let letra = document.getElementById('IdLetra').value;
    let ComoVa =  document.getElementById('IdComoVa').value;
   
   let GanoONO = false

 CompararLetra(letra, PalabraAdivinar,ComoVa)

 GanoONO = CompararPalabra( PalabraAdivinar,palabraUser)

   
    //document.getElementById('resultado').innerHTML =
      


  }

  function CompararLetra(letra, PalabraAdivinar,ComoVa) 
  {
    for(let i = 0; i <= PalabraAdivinar.length; i++)
    {
        if(PalabraAdivinar[i] == letra)
        {
            ComoVa[i] = letra
        }
    }

    if(PalabraAdivinar == ComoVa)
    {
        esIgual = true
        alert('Ganasteee :)')
    }
    document.getElementById('IdComoVa').innerHTML = ComoVa

  }


  function CompararPalabra(PalabraAdivinar,palabraUser) 
  {
    let esIgual = false
    if(PalabraAdivinar == palabraUser)
    {
         esIgual = true
         alert('Ganasteee :)' )
    }
    else {
        alert('Perdiste :(')
    }
    return esIgual
    


  }










    





























