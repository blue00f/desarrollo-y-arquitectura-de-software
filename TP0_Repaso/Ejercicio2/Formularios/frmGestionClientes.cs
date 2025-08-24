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
    public partial class frmGestionClientes : Form
    {
        private Empresa empresa;
        public frmGestionClientes(Empresa pEmpresa)
        {
            InitializeComponent();
            empresa = pEmpresa;
        }

        private void frmGestionClientes_Load(object sender, EventArgs e)
        {
            if (empresa.ObtenerClientes().Count > 0)
            {
                Mostrar(grillaClientes, empresa.ObtenerClientes());
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

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = Interaction.InputBox("Ingrese el código", "Alta cliente");
                if (empresa.ValidarCodigoCliente(codigo)) throw new Exception("Código repetido!");
                string nombre = Interaction.InputBox("Ingrese el nombre", "Alta cliente");
                if (nombre.Length == 0) throw new Exception("El nombre está vacio!");
                string apellido = Interaction.InputBox("Ingrese el apellido", "Alta cliente");
                if (apellido.Length == 0) throw new Exception("El apellido está vacio!");
                string dni = Interaction.InputBox("Ingrese el DNI", "Alta cliente");
                if (dni.Length != 8) throw new Exception("El DNI debe tener 8 caracteres!");
                DateTime fechaNacimiento = DateTime.Parse(Interaction.InputBox("Ingrese la fecha de nacimiento", "Alta cliente", DateTime.Now.ToShortDateString()));

                Cliente cliente = new Cliente(codigo, nombre, apellido, dni, fechaNacimiento);
                empresa.AgregarCliente(cliente);
                Mostrar(grillaClientes, empresa.ObtenerClientes());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaClientes.Rows.Count == 0) throw new Exception("No hay registros de clientes!");
                var cliente = grillaClientes.SelectedRows[0].DataBoundItem as Cliente;
                empresa.BorrarCliente(cliente);
                Mostrar(grillaClientes, empresa.ObtenerClientes());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaClientes.Rows.Count == 0) throw new Exception("No hay registros de clientes!");
                var cliente = grillaClientes.SelectedRows[0].DataBoundItem as Cliente;

                string nombre = Interaction.InputBox("Ingrese el nombre", "Modificar cliente", cliente.Nombre);
                if (nombre.Length == 0) throw new Exception("El nombre está vacio!");
                string apellido = Interaction.InputBox("Ingrese el apellido", "Modificar cliente", cliente.Apellido);
                if (apellido.Length == 0) throw new Exception("El apellido está vacio!");
                string dni = Interaction.InputBox("Ingrese el DNI", "Modificar cliente", cliente.Dni);
                if (dni.Length == 0) throw new Exception("El DNI está vacio!");
                DateTime fechaNacimiento = DateTime.Parse(Interaction.InputBox("Ingrese la fecha de nacimiento", "Modificar cliente", cliente.FechaNacimiento.ToShortDateString()));

                var clienteModificado = new Cliente(cliente.Codigo, nombre, apellido, dni, fechaNacimiento);
                empresa.ModificarCliente(clienteModificado);
                Mostrar(grillaClientes, empresa.ObtenerClientes());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
