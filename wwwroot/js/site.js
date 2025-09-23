
function Juego(PalabraAdivinar, letra) {
    let palabraUser = document.getElementById('IdPalabra').value;
    let letra = document.getElementById('IdLetra').value;
    let ComoVa =  document.getElementById('IdComoVa').value;
   
   let GanoONO = false

   let resultado = "";
    for (let letra of palabra) {
        if (letrasAdivinadas.includes(letra)) {
            resultado += letra + " ";
        } else {
            resultado += "_ ";
        }
    }
    document.getElementById("palabraSecreta").innerText = resultado.trim();

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










    





























