using Ejercicio2.Formularios;

namespace Ejercicio2
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
        private void vehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVehiculos f = new frmVehiculos();
            f.MdiParent = this;
            formularios.Add(f);
            f.Show();
        }
        private void propietariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPropietarios f = new frmPropietarios();
            f.MdiParent = this;
            formularios.Add(f);
            f.Show();
        }
        private void multasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMultas f = new frmMultas();
            f.MdiParent = this;
            formularios.Add(f);
            f.Show();
        }
        private void salirToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();
    }
}
