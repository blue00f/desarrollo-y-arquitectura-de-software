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
    public partial class frmGestionCanales : Form
    {
        private Empresa empresa;
        public frmGestionCanales(Empresa pEmpresa)
        {
            InitializeComponent();
            empresa = pEmpresa;
        }
        private void frmGestionCanales_Load(object sender, EventArgs e)
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
        }

        private void Mostrar(DataGridView pGrilla, object pDatos)
        {
            pGrilla.DataSource = null;
            pGrilla.DataSource = pDatos;
        }
        private Paquete ObtenerPaquete()
        {
            if (cbxPaquetes.SelectedIndex == -1) throw new Exception("Debe haber un paquete seleccionado!");
            int codigoPaquete = int.Parse(cbxPaquetes.Text.Split("-")[0].Trim());
            var paquete = empresa.BuscarPaquetePorCodigo(codigoPaquete);
            return paquete;
        }
        private void btnAgregarCanal_Click(object sender, EventArgs e)
        {
            try
            {
                Paquete paquete = ObtenerPaquete();
                string codigo = Interaction.InputBox("Ingrese el código", "Alta canal");
                if (paquete.ValidarCanalRepetido(codigo)) throw new Exception("Código del canal repetido!");
                string nombre = Interaction.InputBox("Ingrese el nombre", "Alta canal");
                if (nombre.Length == 0) throw new Exception("El nombre está vacio!");

                var canal = new Canal(codigo, nombre);
                paquete.AgregarCanal(canal);
                Mostrar(grillaCanales, paquete.ObtenerCanales());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBorrarCanal_Click(object sender, EventArgs e)
        {
            try
            {
                Paquete paquete = ObtenerPaquete();
                if (paquete.ObtenerCanales().Count == 0) throw new Exception("El paquete no tiene canales!");
                var canal = grillaCanales.SelectedRows[0].DataBoundItem as Canal;
                paquete.BorrarCanal(canal);
                Mostrar(grillaCanales, paquete.ObtenerCanales());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarCanal_Click(object sender, EventArgs e)
        {
            try
            {
                Paquete paquete = ObtenerPaquete();
                if (paquete.ObtenerCanales().Count == 0) throw new Exception("El paquete no tiene canales!");
                var canal = grillaCanales.SelectedRows[0].DataBoundItem as Canal;
                string nombre = Interaction.InputBox("Ingrese el nombre", "Modificación del canal", canal.Nombre);
                if (nombre.Length == 0) throw new Exception("El nombre está vacio!");
                var nuevoCanal = new Canal(canal.Codigo, nombre);
                paquete.ModificarCanal(nuevoCanal);
                Mostrar(grillaCanales, paquete.ObtenerCanales());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxPaquetes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxPaquetes.SelectedIndex == -1) throw new Exception("Debe haber un paquete seleccionado!");
                int codigoPaquete = int.Parse(cbxPaquetes.Text.Split("-")[0].Trim());
                var paquete = empresa.BuscarPaquetePorCodigo(codigoPaquete);
                Mostrar(grillaCanales, paquete.ObtenerCanales());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
