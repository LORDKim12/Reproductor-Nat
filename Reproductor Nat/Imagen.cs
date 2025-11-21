using AxWMPLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reproductor_Nat
{
    // Clase para ver fotos
    internal class Imagen : Reproductor
    {
        private PictureBox _pb;
        private AxWindowsMediaPlayer _wmp;

        // Recibo los controles del formulario
        public Imagen(AxWindowsMediaPlayer wmp, PictureBox pb)
        {
            _wmp = wmp;
            _pb = pb;
        }

        public void Reproducir(string ruta)
        {
            // Paro la musica si habia algo sonando
            _wmp.Ctlcontrols.stop();

            // Oculto el video y muestro la foto
            _wmp.Visible = false;
            _pb.Visible = true;

            // cargo la imagen
            _pb.ImageLocation = ruta;
        }

        public void Detener()
        {
            _pb.Image = null;
            _pb.Visible = false;
        }

        public void Pausar()
        {
            // Las imagenes no se pausan, asi que no hago nada
        }
    }
}
