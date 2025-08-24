using Ejercicio1.Entidades;
using Microsoft.VisualBasic;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        Banco banco;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            banco = new Banco();
            foreach (var control in Controls)
            {
                if (control is DataGridView grilla)
                {
                    grilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    grilla.MultiSelect = false;
                    grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
        }
        private void Mostrar(DataGridView pGrilla, object pDatos)
        {
            pGrilla.DataSource = null;
            pGrilla.DataSource = pDatos;
        }

        private void btnAltaCliente_Click(object sender, EventArgs e)
        {
            try
            {
                string dni = Interaction.InputBox("Ingrese el DNI", "Alta cliente");
                if (banco.ValidarCliente(dni)) throw new Exception("El DNI está repetido!");
                if (dni.Length != 8) throw new Exception("El DNI debe tener 8 caracteres!");
                string nombre = Interaction.InputBox("Ingrese el nombre", "Alta cliente");
                if (nombre.Length == 0) throw new Exception("El nombre está vacio!");
                string apellido = Interaction.InputBox("Ingrese el apellido", "Alta cliente");
                if (apellido.Length == 0) throw new Exception("El apellido está vacio!");
                string telefono = Interaction.InputBox("Ingrese el número de teléfono", "Alta cliente");
                if (telefono.Length == 0) throw new Exception("El teléfono está vacio!");
                if (telefono.Length != 8) throw new Exception("El teléfono debe tener 8 caracteres!");

                string correo = Interaction.InputBox("Ingrese el correo", "Alta cliente");
                if (correo.Length == 0) throw new Exception("El correo está vacio!");
                DateTime fechaNacimiento = DateTime.Parse(Interaction.InputBox("Ingrese la fecha de nacimiento", "Alta cliente", DateTime.Now.ToShortDateString()));

                var cliente = new Cliente(dni, nombre, apellido, telefono, correo, fechaNacimiento);
                banco.AltaCliente(cliente);
                Mostrar(grillaClientes, banco.ObtenerClientes());
                FiltrarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBajaCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaClientes.Rows.Count == 0) throw new Exception("No hay registros de cliente!");
                var cliente = grillaClientes.SelectedRows[0].DataBoundItem as Cliente;
                banco.BajaCliente(cliente);
                Mostrar(grillaClientes, banco.ObtenerClientes());
                FiltrarClientes();
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
                if (grillaClientes.Rows.Count == 0) throw new Exception("No hay registros de cliente!");
                var cliente = grillaClientes.SelectedRows[0].DataBoundItem as Cliente;

                string nombre = Interaction.InputBox("Ingrese el nombre", "Modificación cliente", cliente.Nombre);
                if (nombre.Length == 0) throw new Exception("El nombre está vacio!");
                string apellido = Interaction.InputBox("Ingrese el apellido", "Modificación cliente", cliente.Apellido);
                if (apellido.Length == 0) throw new Exception("El apellido está vacio!");
                string telefono = Interaction.InputBox("Ingrese el número de teléfono", "Modificación cliente", cliente.Telefono);
                if (telefono.Length == 0) throw new Exception("El teléfono está vacio!");
                string correo = Interaction.InputBox("Ingrese el correo", "Modificación cliente", cliente.Correo);
                if (correo.Length == 0) throw new Exception("El correo está vacio!");
                DateTime fechaNacimiento = DateTime.Parse(Interaction.InputBox("Ingrese la fecha de nacimiento", "Modificación cliente", cliente.FechaNacimiento.Date.ToShortDateString()));

                var nuevoCliente = new Cliente(cliente.Dni, nombre, apellido, telefono, correo, fechaNacimiento);
                banco.ModificarCliente(nuevoCliente);
                Mostrar(grillaClientes, banco.ObtenerClientes());
                FiltrarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAltaCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaClientes.Rows.Count == 0) throw new Exception("No hay registros de clientes!");
                var cliente = grillaClientes.SelectedRows[0].DataBoundItem as Cliente;
                int codigo = int.Parse(Interaction.InputBox("Ingrese el código", "Alta cuenta"));
                if (banco.ValidarCuenta(codigo)) throw new Exception("El código está repetido!");

                if (radCajaAhorro.Checked)
                {
                    var cuenta = new CAhorro(codigo);
                    banco.AltaCuenta(cuenta, cliente);
                }
                else
                {
                    string inputDescubierto = Interaction.InputBox("Ingrese el descubierto", "Alta cuenta");
                    if (!decimal.TryParse(inputDescubierto, out decimal descubierto)) throw new Exception("El descubierto debe ser numérico!");
                    if (descubierto < 0) throw new Exception("El descubierto debe ser positivo!");
                    var cuenta = new CCorriente(codigo, descubierto);
                    banco.AltaCuenta(cuenta, cliente);
                }
                Mostrar(grillaCuentas, banco.ObtenerCuentasDeUnCliente(cliente));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidarCuentaClienteEnGrillas(out Cuenta cuenta, out Cliente? cliente)
        {
            if (grillaCuentas.Rows.Count == 0) throw new Exception("No hay registros de cuentas!");
            if (grillaClientes.Rows.Count == 0) throw new Exception("No hay registros de clientes!");
            cuenta = banco.RecuperarCuentaPorCodigo(Convert.ToInt32(grillaCuentas.SelectedRows[0].Cells[0].Value));
            cliente = grillaClientes.SelectedRows[0].DataBoundItem as Cliente;
        }

        private void btnBajaCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                Cuenta cuenta; Cliente? cliente;
                ValidarCuentaClienteEnGrillas(out cuenta, out cliente);
                banco.BajaCuenta(cuenta);
                Mostrar(grillaCuentas, banco.ObtenerCuentasDeUnCliente(cliente));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaCuentas.Rows.Count == 0) throw new Exception("No hay registros de cuentas!");
                if (grillaClientes.Rows.Count == 0) throw new Exception("No hay registros de clientes!");
                var cuenta = banco.RecuperarCuentaPorCodigo(Convert.ToInt32(grillaCuentas.SelectedRows[0].Cells[0].Value));
                var cliente = grillaClientesFiltrados.SelectedRows[0].DataBoundItem as Cliente;
                banco.ModificarCuenta(cuenta, cliente);
                Mostrar(grillaCuentas, banco.ObtenerCuentasDeUnCliente(cliente));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            try
            {
                Cuenta cuenta; Cliente? cliente;
                ValidarCuentaClienteEnGrillas(out cuenta, out cliente);
                string inputMonto = Interaction.InputBox("Ingrese el monto:", "Depósito");
                if (!decimal.TryParse(inputMonto, out decimal monto)) throw new Exception("El monto debe ser numérico!");
                cuenta.Depositar(monto);

                var ope = new Operacion(btnDepositar.Text.ToString(), monto, cuenta);
                banco.AltaOperacion(ope);
                Mostrar(grillaOperaciones, banco.ObtenerOperaciones());
                Mostrar(grillaCuentas, banco.ObtenerCuentasDeUnCliente(cliente));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExtraer_Click(object sender, EventArgs e)
        {
            try
            {
                Cuenta cuenta; Cliente? cliente;
                ValidarCuentaClienteEnGrillas(out cuenta, out cliente);
                string inputMonto = Interaction.InputBox("Ingrese el monto:", "Extracción");
                if (!decimal.TryParse(inputMonto, out decimal monto)) throw new Exception("El monto debe ser numérico!");
                cuenta.Extraer(monto);

                var ope = new Operacion(btnDepositar.Text.ToString(), monto, cuenta);
                banco.AltaOperacion(ope);
                Mostrar(grillaOperaciones, banco.ObtenerOperaciones());
                Mostrar(grillaCuentas, banco.ObtenerCuentasDeUnCliente(cliente));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grillaClientes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (grillaClientes.Rows.Count > 0)
                {
                    var cliente = grillaClientes.SelectedRows[0].DataBoundItem as Cliente;
                    Mostrar(grillaCuentas, banco.ObtenerCuentasDeUnCliente(cliente));
                }
            }
            catch (Exception) { }
        }

        private void txtDni_TextChanged(object sender, EventArgs e) => FiltrarClientes();
        private void txtNombre_TextChanged(object sender, EventArgs e) => FiltrarClientes();
        private void FiltrarClientes()
        {
            if (grillaClientes.Rows.Count > 0)
            {
                var aux = banco.ObtenerClientesPorFiltro(txtDni.Text, txtNombre.Text);
                Mostrar(grillaClientesFiltrados, aux);
            }
        }
    }
}
