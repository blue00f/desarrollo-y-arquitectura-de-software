using Ejercicio2.Entidades;
using Ejercicio2.Formularios;

namespace Ejercicio2;

public partial class frmMenu : Form
{
    Empresa empresa;
    public frmMenu()
    {
        InitializeComponent();
    }
    private void frmMenu_Load(object sender, EventArgs e)
    {
        empresa = new Empresa();
        foreach (var control in Controls)
        {
            if (control is DataGridView grilla)
            {
                grilla.MultiSelect = false;
                grilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
    }
    private void gestionClientesToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        frmGestionClientes frmClientes = new frmGestionClientes(this.empresa);
        frmClientes.Show();
    }

    private void gestionPaquetesToolStripMenuItem_Click_1(object sender, EventArgs e)
    {
        frmGestionPaquetes frmPaquetes = new frmGestionPaquetes(this.empresa);
        frmPaquetes.Show();
    }
    private void contratacionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmContratacion frmContratacion = new frmContratacion(this.empresa);
        frmContratacion.Show();
    }


    private void gestionCanalesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmGestionCanales frmCanales = new frmGestionCanales(this.empresa);
        frmCanales.Show();
    }

    private void gestionSeriesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmGestionSeries frmSeries = new frmGestionSeries(this.empresa);
        frmSeries.Show();
    }
    private void informesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmInformes frmInformes = new frmInformes(this.empresa);
        frmInformes.Show();
    }
    private void salirToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();
}
