namespace Ejercicio1
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void sociosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSocio frmSocio = new frmSocio();
            frmSocio.Show();
        }

        private void paísToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPais frmPais = new frmPais();
            frmPais.Show();
        }

        private void provinciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProvincia frmProvincia = new frmProvincia();
            frmProvincia.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
