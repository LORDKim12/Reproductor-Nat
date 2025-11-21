using AxWMPLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reproductor_Nat
{
    // Clase para audio
    internal class Video : Reproductor
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
            // Oculto la foto y muestro el reproductor
            _pb.Visible = false;
            _wmp.Visible = true;

            // Le mando el archivo al WMP y le doy play
            _wmp.URL = ruta;
            _wmp.Ctlcontrols.play();
        }

        public void Pausar()
        {
            _wmp.Ctlcontrols.pause();
        }

        public void Detener()
        {
            _wmp.Ctlcontrols.stop();
        }
    }
}
