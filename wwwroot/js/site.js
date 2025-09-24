
function Juego(PPalabraAdivinar) {
 const palabraUser = document.getElementById('IdPalabra')?.value || "";
    const letra = (document.getElementById('IdLetra')?.value || "").trim();
    const ComoVa = document.getElementById('IdComoVa'); 

   let GanoONO = false


let PalabraAdivinar = (PPalabraAdivinar !== undefined && PPalabraAdivinar !== null)
        ? String(PPalabraAdivinar) : "";

    if (ComoVa && PalabraAdivinar) {
        const cur = (ComoVa.textContent || "").trim();
        if (!cur || cur.length !== PalabraAdivinar.length) {
            ComoVa.textContent = '_'.repeat(PalabraAdivinar.length);
        }
    }

   let resultado = "";


 const letrasUsadasElem = document.getElementById('letrasUsadas');
    let LetrasUsadas = (letrasUsadasElem?.textContent || "").trim();

    if (letra) {
        CompararLetra(letra, PalabraAdivinar, ComoVa);
        LetrasUsadas = (LetrasUsadas ? LetrasUsadas + " " : "") + letra.toUpperCase() + ",";
        if (letrasUsadasElem) letrasUsadasElem.textContent = LetrasUsadas;
        const li = document.getElementById('IdLetra');
      
    }

    if (palabraUser) {
        CompararPalabra(PalabraAdivinar, palabraUser);
        const pi = document.getElementById('IdPalabra');
      
    }

    //document.getElementById('resultado').innerHTML =
    document.getElementById('letrasUsadas').innerHTML = LetrasUsadas;
  }


 function CompararLetra(letra, PalabraAdivinar, comoVa) 
{
    if (!comoVa || !PalabraAdivinar || !letra) return false;

    let comoVaArr = (comoVa.textContent || "").split('');
    if (comoVaArr.length !== PalabraAdivinar.length) {
        comoVaArr = Array.from('_'.repeat(PalabraAdivinar.length));
    }

    for (let i = 0; i < PalabraAdivinar.length; i++)
    {
        if (PalabraAdivinar[i].toUpperCase() === letra.toUpperCase())
        {
            comoVaArr[i] = PalabraAdivinar[i].toUpperCase();
        }
    }

    const nuevoComoVa = comoVaArr.join('');
    comoVa.textContent = nuevoComoVa;

   

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










    





























