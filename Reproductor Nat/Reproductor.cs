using System;
using System.Collections.Generic;
using System.Text;

namespace Reproductor_Nat
{
    
    internal interface Reproductor
    {
        void Reproducir(string ruta);
        void Pausar();
        void Detener();
        
    }
}
