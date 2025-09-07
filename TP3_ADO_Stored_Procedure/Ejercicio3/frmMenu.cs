using Ejercicio3.Formularios;

namespace Ejercicio3
{
    public partial class frmMenu : Form
    {
        List<Form> formularios;
        public frmMenu()
        {
            InitializeComponent();
            IsMdiContainer = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            formularios = new List<Form>();
        }
        private void jugadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmJugadores f = new frmJugadores();
            f.MdiParent = this;
            formularios.Add(f);
            f.Show();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategorias f = new frmCategorias();
            f.MdiParent = this;
            formularios.Add(f);
            f.Show();
        }

        private void preguntasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPreguntas f = new frmPreguntas();
            f.MdiParent = this;
            formularios.Add(f);
            f.Show();
        }

        private void opcionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmOpciones f = new frmOpciones();
            f.MdiParent = this;
            formularios.Add(f);
            f.Show();
        }

        private void respuestasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRespuestas f = new frmRespuestas();
            f.MdiParent = this;
            formularios.Add(f);
            f.Show();
        }
        private void salirToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();
    }
}
