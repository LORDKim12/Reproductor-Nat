using AxWMPLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reproductor_Nat
{
    internal class Imagen : Reproductor // Asegúrate de agregar ": Reproductor"
    {
        private PictureBox _pb;
        private AxWindowsMediaPlayer _wmp;

        public Imagen(AxWindowsMediaPlayer wmp, PictureBox pb)
        {
            _wmp = wmp;
            _pb = pb;
        }

        public void Reproducir(string ruta)
        {
            // 1. Detener cualquier audio/video que estuviera sonando
            _wmp.Ctlcontrols.stop();

            // 2. EL TRUCO: Ocultar el WMP y mostrar el PictureBox
            _wmp.Visible = false;
            _pb.Visible = true;

            // 3. Cargar la imagen
            _pb.ImageLocation = ruta;
            _pb.SizeMode = PictureBoxSizeMode.Zoom;
        }

        public void Detener()
        {
            _pb.Image = null; // Limpiamos la imagen
            _pb.Visible = false;
        }

        // Las imágenes no se pausan, así que dejamos el método vacío o lanzamos excepción controlada
        public void Pausar() { }
    }
}
