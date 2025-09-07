using Ejercicio1.Formularios;

namespace Ejercicio1
{
    public partial class frmMenu : Form
    {
        List<Form> formularios;
        public frmMenu()
        {
            InitializeComponent();
            IsMdiContainer = true;
        }
        private void frmMenu_Load(object sender, EventArgs e)
        {
            formularios = new List<Form>();
        }
        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAlumnos f = new frmAlumnos();
            f.MdiParent = this;
            formularios.Add(f);
            f.Show();
        }
        private void obrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmObras f = new frmObras();
            f.MdiParent = this;
            formularios.Add(f);
            f.Show();
        }
        private void ejemplaresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEjemplares f = new frmEjemplares();
            f.MdiParent = this;
            formularios.Add(f);
            f.Show();
        }
        private void prestamosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrestamos f = new frmPrestamos();
            f.MdiParent = this;
            formularios.Add(f);
            f.Show();
        }
        private void salirToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();

    }
}
