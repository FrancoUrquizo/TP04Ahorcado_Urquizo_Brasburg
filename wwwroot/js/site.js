function Juego(PPalabraAdivinar) {
    const palabraUser = document.getElementById('IdPalabra')?.value || "";
    const letra = (document.getElementById('IdLetra')?.value || "").trim();
    const ComoVa = document.getElementById('IdComoVa');
    const intentosVisual = document.getElementById('intentosVisual');

    let PalabraAdivinar = (PPalabraAdivinar !== undefined && PPalabraAdivinar !== null)
        ? String(PPalabraAdivinar) : "";

    if (ComoVa && PalabraAdivinar) {
        const cur = (ComoVa.textContent || "").trim();
        if (!cur || cur.length !== PalabraAdivinar.length) {
            ComoVa.textContent = '_'.repeat(PalabraAdivinar.length);
        }
    }

    const letrasUsadasElem = document.getElementById('letrasUsadas');
    let LetrasUsadas = (letrasUsadasElem?.textContent || "").trim();
    let letrasArray = LetrasUsadas.split(',').map(l => l.trim().toUpperCase()).filter(l => l);

    if (letra) {
        let letraMayus = letra.toUpperCase().trim();

        if (letrasArray.includes(letraMayus)) {
            alert("Ya usaste esa letra!");
        } else {
            const acierto = CompararLetra(letra, PalabraAdivinar, ComoVa);
            LetrasUsadas = (LetrasUsadas ? LetrasUsadas + " " : "") + letraMayus + ",";
            if (letrasUsadasElem) letrasUsadasElem.textContent = LetrasUsadas;
            if (!acierto) {
                IncrementarIntentos();
            }
        }
    }

 
    if (ComoVa && !ComoVa.textContent.includes("_")) {
        alert("Ganastee  con " + intentosVisual.textContent + " intentos, la Palabra era " + PalabraAdivinar.toLowerCase());
        
         ocultarFormularios();
         document.getElementById('mensajeFinal').style.display = 'block';
    }

  
    if (palabraUser) {
        const igual = CompararPalabra(PalabraAdivinar, palabraUser);
        if (igual) {
           
            ComoVa.innerHTML = PalabraAdivinar;
             ocultarFormularios();
             document.getElementById('mensajeFinal').style.display = 'block';
        }
        else {
             ocultarFormularios();
             document.getElementById('mensajeFinal').style.display = 'block';
        }
    }

    document.getElementById('letrasUsadas').innerHTML = LetrasUsadas;
}
function CompararLetra(letra, PalabraAdivinar, comoVa) 
{
    if (!comoVa || !PalabraAdivinar || !letra) return false;

    let comoVaArr = (comoVa.textContent || "").split('');
    if (comoVaArr.length !== PalabraAdivinar.length) {
        comoVaArr = Array.from('_'.repeat(PalabraAdivinar.length));
    }

    let acierto = false;
    for (let i = 0; i < PalabraAdivinar.length; i++)
    {
        if (PalabraAdivinar[i].toUpperCase().trim() === letra.toUpperCase().trim())
        {
            comoVaArr[i] = PalabraAdivinar[i].toUpperCase().trim();
            acierto = true;
        }
    }

    const nuevoComoVa = comoVaArr.join('');
    comoVa.textContent = nuevoComoVa;

    return acierto; 

}
function CompararPalabra(PalabraAdivinar, palabraUser) {
    var intentosVisual = document.getElementById('intentosVisual');
    var inputIntentos = document.getElementById('intentos');
    let esIgual = false;

    if (PalabraAdivinar == palabraUser.toUpperCase().trim()) {
        esIgual = true;
        var intentosMostrados = intentosVisual ? intentosVisual.textContent : (inputIntentos ? inputIntentos.value : "0");
        alert("Ganaste con " + intentosMostrados + " intentos, la Palabra era " + PalabraAdivinar.toLowerCase());
      

    } else {
        IncrementarIntentos();
        alert('Perdiste, la palabra era ' + PalabraAdivinar);
    }
    return esIgual;
}

  function IncrementarIntentos (){
  
    var inputIntentos = document.getElementById('intentos');
    var intentosVisual = document.getElementById('intentosVisual');
    var intentosActuales = parseInt(inputIntentos.value, 10) || 0;
    intentosActuales++;
    inputIntentos.value = intentosActuales;
    intentosVisual.textContent = intentosActuales;
}
function ocultarFormularios() {
    document.querySelectorAll('form').forEach(form => {
        if (form.id !== 'Fin') {
            form.style.display = 'none';
        }
    });
  
    let mensajeFinal = document.getElementById('mensajeFinal');
    if (mensajeFinal) mensajeFinal.style.display = 'block';
}