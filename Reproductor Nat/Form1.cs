using AxWMPLib;

namespace Reproductor_Nat
{
    public partial class Form1 : Form
    {
        // Variable polimórfica (esta SÍ se queda)
        private Reproductor reproductorActual;

        private List<string> listaRutas = new List<string>();

        // NOTA: No declaramos pictureBox1 aquí porque ya existe en el diseño.

        public Form1()
        {
            InitializeComponent();

            // --- AGREGA ESTA LÍNEA PARA QUE FUNCIONEN LOS CLICS ---
            listBox1.DoubleClick += ListBox1_DoubleClick;
            // ------------------------------------------------------

            // Configuración inicial del PictureBox
            pictureBox1.Visible = false;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btnCargar_Click(object sender, EventArgs e)
        {
            // ... (El mismo código que tenías para cargar archivos) ...
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "Archivos Multimedia|*.mp3;*.wav;*.mp4;*.avi;*.jpg;*.png;*.jpeg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string archivo in ofd.FileNames)
                {
                    listaRutas.Add(archivo);
                    listBox1.Items.Add(Path.GetFileName(archivo));
                }
            }
        }

        private void ListBox1_DoubleClick(object sender, EventArgs e)
        {
            ReproducirSeleccionado();
        }
        private void ReproducirSeleccionado()
        {
            if (listBox1.SelectedIndex == -1) return;

            string ruta = listaRutas[listBox1.SelectedIndex];
            string extension = Path.GetExtension(ruta).ToLower();

            // --- FÁBRICA (Tu lógica actual) ---
            if (extension == ".mp3" || extension == ".wav" || extension == ".wma")
            {
                reproductorActual = new Musica(axWindowsMediaPlayer2, pictureBox1);
            }
            else if (extension == ".mp4" || extension == ".avi" || extension == ".mkv" || extension == ".mov")
            {
                reproductorActual = new Video(axWindowsMediaPlayer2, pictureBox1);
            }
            else if (extension == ".jpg" || extension == ".png" || extension == ".jpeg" || extension == ".bmp")
            {
                reproductorActual = new Imagen(axWindowsMediaPlayer2, pictureBox1);
            }

            // --- EJECUCIÓN POLIMÓRFICA ---
            if (reproductorActual != null)
            {
                reproductorActual.Reproducir(ruta);
            }
        }
        private void btnCarpeta_Click(object sender, EventArgs e)
        {
            // 1. Crear el diálogo para seleccionar carpetas
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                // 2. Si el usuario seleccionó una carpeta y dio OK
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    // 3. Obtenemos TODOS los archivos de esa carpeta
                    string[] archivosEncontrados = Directory.GetFiles(fbd.SelectedPath);

                    foreach (string archivo in archivosEncontrados)
                    {
                        string extension = Path.GetExtension(archivo).ToLower();

                        // 4. Filtramos solo los que nos sirven (Música, Video, Imagen)
                        if (extension == ".mp3" || extension == ".wav" ||
                            extension == ".mp4" || extension == ".avi" || extension == ".mkv" ||
                            extension == ".jpg" || extension == ".png" || extension == ".jpeg")
                        {
                            // Agregamos a nuestras listas (igual que el botón de cargar archivo)
                            listaRutas.Add(archivo);
                            listBox1.Items.Add(Path.GetFileName(archivo));
                        }
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            // Verificamos que haya algo seleccionado y que no sea el último de la lista
            if (listBox1.Items.Count > 0 && listBox1.SelectedIndex < listBox1.Items.Count - 1)
            {
                listBox1.SelectedIndex++; // Avanzamos el índice
                ReproducirSeleccionado(); // Reproducimos el nuevo índice
            }
            else if (listBox1.Items.Count > 0 && listBox1.SelectedIndex == listBox1.Items.Count - 1)
            {
                // Opcional: Volver al principio si es el último (Loop)
                listBox1.SelectedIndex = 0;
                ReproducirSeleccionado();
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            // Verificamos que no estemos ya en el primero
            if (listBox1.SelectedIndex > 0)
            {
                listBox1.SelectedIndex--; // Retrocedemos el índice
                ReproducirSeleccionado();
            }
        }
    }
}
