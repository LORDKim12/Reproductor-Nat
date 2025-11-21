using System;
using System.Collections.Generic;
using System.Text;

namespace Reproductor_Nat
{
    internal interface Reproductor
    {
        void Reproducir();
        void Pausar();
        void Detener();
        void Siguiente();
        void Anterior();

    }
}
