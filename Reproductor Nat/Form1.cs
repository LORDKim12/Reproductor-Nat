using AxWMPLib;

namespace Reproductor_Nat
{
    public partial class Form1 : Form
    {
        // Variable para guardar el objeto que se esta reproduciendo actualmente.
        // Uso la interfaz 'Reproductor' para que pueda ser Musica, Video o Imagen.
        private Reproductor reproductorActual;

        // Lista para guardar las rutas de los archivos porque el ListBox solo muestra los nombres
        private List<string> listaRutas = new List<string>();

        // Clase auxiliar para poder meter el nombre y la ruta juntos en el ListBox
        // y asi poder separarlos por secciones.
        public class ArchivoMultimedia
        {
            public string Nombre { get; set; }
            public string Ruta { get; set; }
            public bool EsTitulo { get; set; } // Para saber si es un encabezado (ej: --- MUSICA ---)

            public override string ToString()
            {
                return Nombre; // Esto es lo que se ve en la lista
            }
        }

        public Form1()
        {
            InitializeComponent();

            // Conecto el doble clic de la lista aqui porque a veces falla desde el diseñador
            listBox1.DoubleClick += ListBox1_DoubleClick;

            // Oculto la imagen al principio y ajusto el modo de zoom
            pictureBox1.Visible = false;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            // Quito los botones feos del reproductor de windows
            axWindowsMediaPlayer2.uiMode = "full";
        }

        private void Form1_Load(object sender, EventArgs e) { }

        // Este metodo sirve para limpiar la lista y volver a llenarla ordenada por tipo
        private void OrdenarLista()
        {
            listBox1.Items.Clear();

            // Listas temporales para separar los archivos
            List<string> audios = new List<string>();
            List<string> videos = new List<string>();
            List<string> fotos = new List<string>();

            // Recorro todas las rutas que hemos cargado y las clasifico
            foreach (string ruta in listaRutas)
            {
                string ext = Path.GetExtension(ruta).ToLower();

                if (ext == ".mp3" || ext == ".wav") audios.Add(ruta);
                else if (ext == ".mp4" || ext == ".avi") videos.Add(ruta);
                else if (ext == ".jpg" || ext == ".png" || ext == ".jpeg") fotos.Add(ruta);
            }

            // Ahora agrego todo al ListBox con sus titulos
            if (audios.Count > 0)
            {
                listBox1.Items.Add(new ArchivoMultimedia { Nombre = "--- MUSICA ---", EsTitulo = true });
                foreach (var ruta in audios)
                    listBox1.Items.Add(new ArchivoMultimedia { Nombre = Path.GetFileName(ruta), Ruta = ruta, EsTitulo = false });
            }

            if (videos.Count > 0)
            {
                listBox1.Items.Add(new ArchivoMultimedia { Nombre = "--- VIDEOS ---", EsTitulo = true });
                foreach (var ruta in videos)
                    listBox1.Items.Add(new ArchivoMultimedia { Nombre = Path.GetFileName(ruta), Ruta = ruta, EsTitulo = false });
            }

            if (fotos.Count > 0)
            {
                listBox1.Items.Add(new ArchivoMultimedia { Nombre = "--- IMAGENES ---", EsTitulo = true });
                foreach (var ruta in fotos)
                    listBox1.Items.Add(new ArchivoMultimedia { Nombre = Path.GetFileName(ruta), Ruta = ruta, EsTitulo = false });
            }
        }

        // Metodo principal que decide que reproducir
        private void ReproducirSeleccionado()
        {
            if (listBox1.SelectedIndex == -1) return;

            // Recupero el objeto seleccionado
            ArchivoMultimedia archivo = listBox1.SelectedItem as ArchivoMultimedia;

            // Si es un titulo o es nulo, no hago nada
            if (archivo == null || archivo.EsTitulo) return;

            string ruta = archivo.Ruta;
            string ext = Path.GetExtension(ruta).ToLower();

            // Aqui creo la instancia correspondiente segun el archivo
            // Le paso los controles para que la clase los maneje
            if (ext == ".mp3" || ext == ".wav")
            {
                reproductorActual = new Musica(axWindowsMediaPlayer2, pictureBox1);
            }
            else if (ext == ".mp4" || ext == ".avi")
            {
                reproductorActual = new Video(axWindowsMediaPlayer2, pictureBox1);
            }
            else if (ext == ".jpg" || ext == ".png" || ext == ".jpeg")
            {
                reproductorActual = new Imagen(axWindowsMediaPlayer2, pictureBox1);
            }

            // Si se creo bien, le doy play
            if (reproductorActual != null)
            {
                reproductorActual.Reproducir(ruta);
            }
        }

        // Boton para cargar archivos sueltos
        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "Archivos|*.mp3;*.wav;*.mp4;*.avi;*.jpg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                listaRutas.AddRange(ofd.FileNames);
                OrdenarLista(); // Actualizo la vista
            }
        }

        // Boton para cargar carpeta completa
        private void btnCarpeta_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    // Busco todos los archivos de la carpeta
                    string[] archivos = Directory.GetFiles(fbd.SelectedPath);

                    // Solo guardo los que me sirven
                    foreach (string archivo in archivos)
                    {
                        string ext = Path.GetExtension(archivo).ToLower();
                        if (ext == ".mp3" || ext == ".wav" || ext == ".mp4" || ext == ".jpg" || ext == ".png")
                        {
                            listaRutas.Add(archivo);
                        }
                    }
                    OrdenarLista();
                }
            }
        }

        private void ListBox1_DoubleClick(object sender, EventArgs e)
        {
            ReproducirSeleccionado();
        }

        // Boton siguiente con logica para saltar los titulos
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            int i = listBox1.SelectedIndex + 1;

            // Busco hacia abajo el siguiente archivo que no sea titulo
            while (i < listBox1.Items.Count)
            {
                ArchivoMultimedia item = listBox1.Items[i] as ArchivoMultimedia;
                if (!item.EsTitulo)
                {
                    listBox1.SelectedIndex = i;
                    ReproducirSeleccionado();
                    return;
                }
                i++;
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // No hago nada aqui, la reproduccion se maneja con el doble clic
        }
        // Boton anterior (igual que el siguiente pero hacia atras)
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            int i = listBox1.SelectedIndex - 1;

            while (i >= 0)
            {
                ArchivoMultimedia item = listBox1.Items[i] as ArchivoMultimedia;
                if (!item.EsTitulo)
                {
                    listBox1.SelectedIndex = i;
                    ReproducirSeleccionado();
                    return;
                }
                i--;
            }
        }
    }
}
