using AxWMPLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reproductor_Nat
{
    internal class Video : Reproductor // Asegúrate de agregar ": Reproductor"
    {
        private AxWindowsMediaPlayer _wmp;
        private PictureBox _pb;

        public Video(AxWindowsMediaPlayer wmp, PictureBox pb)
        {
            _wmp = wmp;
            _pb = pb;
        }

        public void Reproducir(string ruta)
        {
            // 1. EL TRUCO INVERSO: Ocultar la foto y mostrar el WMP
            _pb.Visible = false;
            _wmp.Visible = true;

            // 2. Reproducir el medio
            _wmp.URL = ruta;
            _wmp.Ctlcontrols.play();
        }

        public void Pausar() => _wmp.Ctlcontrols.pause();
        public void Detener() => _wmp.Ctlcontrols.stop();
    }
}
