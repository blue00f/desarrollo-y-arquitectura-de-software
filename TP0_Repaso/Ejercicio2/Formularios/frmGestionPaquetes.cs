using Ejercicio2.Entidades;
using Microsoft.VisualBasic;
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
    public partial class frmGestionPaquetes : Form
    {
        private Empresa empresa;
        public frmGestionPaquetes(Empresa pEmpresa)
        {
            InitializeComponent();
            empresa = pEmpresa;
        }
        private void frmGestionPaquetes_Load(object sender, EventArgs e)
        {
            if (empresa.ObtenerPaquetes().Count > 0)
            {
                Mostrar(grillaPaquetes, empresa.ObtenerPaquetes());
            }
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
        private void Mostrar(DataGridView pGrilla, object pDatos)
        {
            pGrilla.DataSource = null;
            pGrilla.DataSource = pDatos;
        }

        private void btnAgregarPaquete_Click(object sender, EventArgs e)
        {
            try
            {
                string inputCodigo = Interaction.InputBox("Ingrese el código", "Alta paquete");
                if (!int.TryParse(inputCodigo, out int codigo)) throw new Exception("El código debe ser numérico!");
                if (empresa.ValidarCodigoPaquete(codigo)) throw new Exception("El código está repetido!");
                string nombre = Interaction.InputBox("Ingrese el nombre", "Alta paquete");
                if (nombre.Length == 0) throw new Exception("El nombre está vacio!");
                string inputImporte = Interaction.InputBox("Ingrese el precio del paquete", "Alta paquete");
                if (!decimal.TryParse(inputImporte, out decimal importe)) throw new Exception("El precio debe ser numérico!");
                if (importe < 0) throw new Exception("El importe no puede ser negativo!");

                if (radPremium.Checked)
                {
                    Premium paquete = new Premium(codigo, nombre, importe);
                    empresa.AgregarPaquete(paquete);
                }
                else
                {
                    Silver paquete = new Silver(codigo, nombre, importe);
                    empresa.AgregarPaquete(paquete);
                }
                Mostrar(grillaPaquetes, empresa.ObtenerPaquetes());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrarPaquete_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaPaquetes.Rows.Count == 0) throw new Exception("No hay registros de paquetes");
                var paquete = grillaPaquetes.SelectedRows[0].DataBoundItem as Paquete;
                empresa.BorrarPaquete(paquete);
                Mostrar(grillaPaquetes, empresa.ObtenerPaquetes());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarPaquete_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaPaquetes.Rows.Count == 0) throw new Exception("No hay registros de paquetes");
                var paquete = grillaPaquetes.SelectedRows[0].DataBoundItem as Paquete;
                string nombre = Interaction.InputBox("Ingrese el nombre", "Modificar paquete", paquete.Nombre);
                if (nombre.Length == 0) throw new Exception("El nombre está vacio!");
                string inputImporte = Interaction.InputBox("Ingrese el precio del paquete", "Modificar paquete", paquete.Importe.ToString());
                if (!decimal.TryParse(inputImporte, out decimal importe)) throw new Exception("El precio debe ser numérico!");
                if (importe < 0) throw new Exception("El importe no puede ser negativo!");

                if(paquete is Premium)
                {
                    var paqueteActualizado = new Premium(paquete.Codigo ,nombre, importe);
                    empresa.ModificarPaquete(paqueteActualizado);
                }
                else
                {
                    var paqueteActualizado = new Silver(paquete.Codigo, nombre, importe);
                    empresa.ModificarPaquete(paqueteActualizado);
                }
                Mostrar(grillaPaquetes, empresa.ObtenerPaquetes());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
