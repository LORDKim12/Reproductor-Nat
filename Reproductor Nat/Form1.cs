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
            InitializeComponent(); // Aquí se crea el pictureBox1 automáticamente

            // Configuración inicial extra si la necesitas
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
            if (listBox1.SelectedIndex == -1) return;

            string ruta = listaRutas[listBox1.SelectedIndex];
            string extension = Path.GetExtension(ruta).ToLower();

            // FÁBRICA:
            if (extension == ".mp3" || extension == ".wav")
            {
                // Pasamos el pictureBox1 que ya existe en el formulario
                reproductorActual = new Musica(axWindowsMediaPlayer2, pictureBox1);
            }
            else if (extension == ".mp4" || extension == ".avi" || extension == ".mkv")
            {
                reproductorActual = new Video(axWindowsMediaPlayer2, pictureBox1);
            }
            else if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
            {
                reproductorActual = new Imagen(axWindowsMediaPlayer2, pictureBox1);
            }

            // POLIMORFISMO:
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
    }
}
