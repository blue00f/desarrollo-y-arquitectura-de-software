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
    public partial class frmContratacion : Form
    {
        private Empresa empresa;
        public frmContratacion(Empresa pEmpresa)
        {
            InitializeComponent();
            empresa = pEmpresa;
        }

        private void frmContratacion_Load(object sender, EventArgs e)
        {
            foreach (var c in empresa.ObtenerClientes())
            {
                cbxClientes.Items.Add(c.ToString());
            }
            foreach (var p in empresa.ObtenerPaquetes())
            {
                cbxPaquetes.Items.Add(p.ToString());
            }
        }

        private void btnContratar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxClientes.SelectedIndex != -1 && cbxPaquetes.SelectedIndex != -1)
                {
                    string codigoCliente = cbxClientes.Text.Split("-")[0].Trim();
                    var cliente = empresa.BuscarClientePorCodigo(codigoCliente);
                    int codigoPaquete = int.Parse(cbxPaquetes.Text.Split("-")[0].Trim());
                    var paquete = empresa.BuscarPaquetePorCodigo(codigoPaquete);

                    empresa.AsignarClienteConPaquete(cliente, paquete);
                    MessageBox.Show("Operación exitosa!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
