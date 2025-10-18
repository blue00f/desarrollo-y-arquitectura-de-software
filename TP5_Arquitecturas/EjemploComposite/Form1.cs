using EjemploComposite.Entidades;

namespace EjemploComposite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCargarEstructura_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            Carpeta raiz = new Carpeta("C:\\");
            Carpeta videos = new Carpeta("Videos");
            Carpeta imagenes = new Carpeta("Imagenes");
            Carpeta musica = new Carpeta("Música");
            Carpeta album1 = new Carpeta("Wings Over America");
            Carpeta album2 = new Carpeta("Abbey Road");

            videos.Agregar(new Archivo("Help.mp4"));
            videos.Agregar(new Archivo("Yesterday.mp4"));
            videos.Agregar(new Archivo("Ive Just Seen a Face.mp4"));

            imagenes.Agregar(new Archivo("Foto1.jpg"));
            imagenes.Agregar(new Archivo("Foto2.jpg"));
            imagenes.Agregar(new Archivo("Foto3.jpg"));
            imagenes.Agregar(new Archivo("Foto4.jpg"));

            album1.Agregar(new Archivo("Letting Go (Live).mp3"));
            album1.Agregar(new Archivo("Call Me Back Again (Live).mp3"));
            album1.Agregar(new Archivo("Silly Love Songs (Live).mp3"));
            album1.Agregar(new Archivo("Beware My Love (Live).mp3"));

            album2.Agregar(new Archivo("Come Together.mp3"));
            album2.Agregar(new Archivo("Something.mp3"));
            album2.Agregar(new Archivo("Oh Darling!.mp3"));

            musica.Agregar(album1);
            musica.Agregar(album2);

            raiz.Agregar(videos);
            raiz.Agregar(imagenes);
            raiz.Agregar(musica);
            raiz.Mostrar(treeView1.Nodes);
            treeView1.ExpandAll();
        }
    }
}
