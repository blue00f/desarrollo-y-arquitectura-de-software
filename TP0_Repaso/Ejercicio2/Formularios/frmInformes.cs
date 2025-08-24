using Ejercicio2.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio2.Formularios
{
    public partial class frmInformes : Form
    {
        private Empresa empresa;
        public frmInformes(Empresa pEmpresa)
        {
            InitializeComponent();
            empresa = pEmpresa;
        }

        private void frmInformes_Load(object sender, EventArgs e)
        {
            foreach (var control in Controls)
            {
                if (control is DataGridView grilla)
                {
                    grilla.MultiSelect = false;
                    grilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            foreach (var p in empresa.ObtenerPaquetes())
            {
                cbxPaquetes.Items.Add(p.ToString());
            }
            foreach (var c in empresa.ObtenerClientes())
            {
                cbxClientes.Items.Add(c.ToString());
            }

            Mostrar(grillaSeriesRankingMayor, empresa.ObtenerSeriesConRanking());
            txtTotalRecaudado.Text = $"${empresa.ObtenerTotalRecaudado().ToString()}";

            if (empresa.ExistenVentas())
            {
                Mostrar(grillaInfoPaqueteMasVendido, empresa.ObtenerInfoPaqueteMasVendido());
            }
        }
        private void Mostrar(DataGridView pGrilla, object pDatos)
        {
            pGrilla.DataSource = null;
            pGrilla.DataSource = pDatos;
        }

        private void cbxPaquetes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int codigoPaquete = int.Parse(cbxPaquetes.Text.Split("-")[0].Trim());
                var paquete = empresa.BuscarPaquetePorCodigo(codigoPaquete);
                Mostrar(grillaInfoPaquete, empresa.ObtenerInformacionDelPaquete(paquete));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string codigoCliente = cbxClientes.Text.Split("-")[0].Trim();
                var cliente = empresa.BuscarClientePorCodigo(codigoCliente);
                Mostrar(grillaComprasDelCliente, empresa.ObtenerComprasDelCliente(cliente));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
