using BE;
using BLL;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace UI
{
    public partial class Form1 : Form
    {
        BLL_Cuenta _bllCuenta;
        BLL_Titular _bllTitular;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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
            _bllCuenta = new BLL_Cuenta();
            _bllTitular = new BLL_Titular();
            Mostrar(grillaCuentas, _bllCuenta.ConsultarCuentas());
            Mostrar(grillaTitulares, _bllTitular.Consultar());
            Mostrar(grillaSaldoPersonalizado, _bllCuenta.ConsultaTotalOrdenado());
        }
        private void Mostrar(DataGridView pGrilla, object pDatos)
        {
            pGrilla.DataSource = null;
            pGrilla.DataSource = pDatos;
        }

        private void btnAgregarCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (radCajaAhorro.Checked)
                {
                    string codigo = Interaction.InputBox("Ingrese el código", "Cuenta");
                    if (codigo.Length == 0) throw new Exception("El código está vacio!");
                    BE_CajaAhorro caAux = new BE_CajaAhorro();
                    caAux.Codigo = codigo;
                    if (_bllCuenta.ValidarCodigoRepetido(caAux)) throw new Exception("Código repetido!");
                    string saldoInput = Interaction.InputBox("Ingrese el saldo", "Cuenta");
                    if (!decimal.TryParse(saldoInput, out decimal saldo)) throw new Exception("El saldo debe ser numérico!");

                    BE_CajaAhorro ca = new BE_CajaAhorro(codigo, saldo);
                    _bllCuenta.Agregar(ca);
                    Mostrar(grillaCuentas, _bllCuenta.ConsultarCuentas());
                    Mostrar(grillaSaldoPersonalizado, _bllCuenta.ConsultaTotalOrdenado());
                }
                else
                {
                    string codigo = Interaction.InputBox("Ingrese el código", "Cuenta");
                    if (codigo.Length == 0) throw new Exception("El código está vacio!");
                    BE_Corriente ccAux = new BE_Corriente();
                    ccAux.Codigo = codigo;
                    if (_bllCuenta.ValidarCodigoRepetido(ccAux)) throw new Exception("Código repetido!");
                    string saldoInput = Interaction.InputBox("Ingrese el saldo", "Cuenta");
                    if (!decimal.TryParse(saldoInput, out decimal saldo)) throw new Exception("El saldo debe ser numérico!");
                    string descubiertoInput = Interaction.InputBox("Ingrese el descubierto", "Cuenta");
                    if (!decimal.TryParse(descubiertoInput, out decimal descubierto)) throw new Exception("El descubierto debe ser numérico");

                    BE_Corriente cc = new BE_Corriente(codigo, saldo, descubierto);
                    _bllCuenta.Agregar(cc);
                    Mostrar(grillaCuentas, _bllCuenta.ConsultarCuentas());
                    Mostrar(grillaSaldoPersonalizado, _bllCuenta.ConsultaTotalOrdenado());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrarCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaCuentas.Rows.Count == 0) throw new Exception("No hay cuentas para borrar!");
                BE_Cuenta cuenta = _bllCuenta.RecuperarCuentaPorId(grillaCuentas.SelectedRows[0].Cells[0].Value.ToString());
                _bllCuenta.Borrar(cuenta);
                Mostrar(grillaCuentas, _bllCuenta.ConsultarCuentas());
                Mostrar(grillaSaldoPersonalizado, _bllCuenta.ConsultaTotalOrdenado());
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
                if (grillaCuentas.Rows.Count == 0) throw new Exception("No hay cuentas para modificar!");
                BE_Cuenta cuentaVieja = _bllCuenta.RecuperarCuentaPorId(grillaCuentas.SelectedRows[0].Cells[0].Value.ToString());

                if (cuentaVieja is BE_CajaAhorro ca)
                {
                    string saldoInput = Interaction.InputBox("Ingrese el nuevo saldo", "Cuenta", ca.Saldo.ToString());
                    if (!decimal.TryParse(saldoInput, out decimal saldo)) throw new Exception("El saldo debe ser numérico");
                    BE_CajaAhorro cuenta = new BE_CajaAhorro(ca.Codigo, saldo);
                    _bllCuenta.Modificar(cuenta);
                    Mostrar(grillaCuentas, _bllCuenta.ConsultarCuentas());
                    Mostrar(grillaSaldoPersonalizado, _bllCuenta.ConsultaTotalOrdenado());
                }
                else if (cuentaVieja is BE_Corriente cc)
                {
                    string saldoInput = Interaction.InputBox("Ingrese el nuevo saldo", "Cuenta", cc.Saldo.ToString());
                    if (!decimal.TryParse(saldoInput, out decimal saldo)) throw new Exception("El saldo debe ser numérico");
                    string descubiertoInput = Interaction.InputBox("Ingrese el nuevo descubierto", "Cuenta", cc.Descubierto.ToString());
                    if (!decimal.TryParse(descubiertoInput, out decimal descubierto)) throw new Exception("El descubierto debe ser numérico");
                    BE_Corriente cuenta = new BE_Corriente(cc.Codigo, saldo, descubierto);
                    _bllCuenta.Modificar(cuenta);
                    Mostrar(grillaCuentas, _bllCuenta.ConsultarCuentas());
                    Mostrar(grillaSaldoPersonalizado, _bllCuenta.ConsultaTotalOrdenado());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarTitular_Click(object sender, EventArgs e)
        {
            try
            {
                string dni = Interaction.InputBox("Ingrese el DNI", "Titular");
                string nombre = Interaction.InputBox("Ingrese el nombre", "Titular");
                if (nombre.Length == 0) throw new Exception("El nombre está vacio!");
                string apellido = Interaction.InputBox("Ingrese el apellido", "Titular");
                if (apellido.Length == 0) throw new Exception("El apellido está vacio!");

                BE_Titular titular = new BE_Titular(dni, nombre, apellido);
                _bllTitular.Agregar(titular);
                Mostrar(grillaTitulares, _bllTitular.Consultar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrarTitular_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaTitulares.Rows.Count == 0) throw new Exception("No hay titulares para borrar!");
                var titular = grillaTitulares.SelectedRows[0].DataBoundItem as BE_Titular;
                _bllTitular.Borrar(titular);
                Mostrar(grillaTitulares, _bllTitular.Consultar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarTitular_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaTitulares.Rows.Count == 0) throw new Exception("No hay titulares para borrar!");
                var titularViejo = grillaTitulares.SelectedRows[0].DataBoundItem as BE_Titular;

                string nombre = Interaction.InputBox("Ingrese el nuevo nombre", "Titular", titularViejo.Nombre);
                if (nombre.Length == 0) throw new Exception("El nombre está vacio!");
                string apellido = Interaction.InputBox("Ingrese el nuevo apellido", "Titular", titularViejo.Apellido);
                if (apellido.Length == 0) throw new Exception("El apellido está vacio!");

                BE_Titular titular = new BE_Titular(titularViejo.Dni, nombre, apellido);
                _bllTitular.Modificar(titular);
                Mostrar(grillaTitulares, _bllTitular.Consultar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaCuentas.Rows.Count == 0) throw new Exception("No hay cuentas para asignar!");
                if (grillaTitulares.Rows.Count == 0) throw new Exception("No hay titulares para asignar!");
                var cuenta = _bllCuenta.RecuperarCuentaPorId(grillaCuentas.SelectedRows[0].Cells[0].Value.ToString());
                var titular = grillaTitulares.SelectedRows[0].DataBoundItem as BE_Titular;
                _bllCuenta.AsignarTitular(cuenta, titular);

                Mostrar(grillaCuentasDelTitular, _bllTitular.ConsultarCuentasAnonimo(titular));
                Mostrar(grillaTitularesDeCuenta, _bllCuenta.ConsultarTitulares(cuenta));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void grillaCuentas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grillaCuentas.Rows.Count > 0)
                {
                    var cuenta = _bllCuenta.RecuperarCuentaPorId(grillaCuentas.SelectedRows[0].Cells[0].Value.ToString());
                    Mostrar(grillaTitularesDeCuenta, _bllCuenta.ConsultarTitulares(cuenta));
                }
            }
            catch (Exception) { }
        }

        private void grillaTitulares_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grillaTitulares.Rows.Count > 0)
                {
                    var titular = grillaTitulares.SelectedRows[0].DataBoundItem as BE_Titular;
                    Mostrar(grillaCuentasDelTitular, _bllTitular.ConsultarCuentasAnonimo(titular));
                }
            }
            catch (Exception) { }
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaCuentas.Rows.Count == 0) throw new Exception("No hay cuentas en la grilla!");
                var cuenta = _bllCuenta.RecuperarCuentaPorId(grillaCuentas.SelectedRows[0].Cells[0].Value.ToString());
                string montoInput = Interaction.InputBox("Ingrese el monto a depositar", "Depósito");
                if (!decimal.TryParse(montoInput, out decimal monto)) throw new Exception("El monto debe ser numérico");
                _bllCuenta.Depositar(cuenta, monto);
                Mostrar(grillaCuentas, _bllCuenta.ConsultarCuentas());

                var titular = grillaTitulares.SelectedRows[0].DataBoundItem as BE_Titular;
                Mostrar(grillaCuentasDelTitular, _bllTitular.ConsultarCuentasAnonimo(titular));
                Mostrar(grillaSaldoPersonalizado, _bllCuenta.ConsultaTotalOrdenado());
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
                if (grillaCuentas.Rows.Count == 0) throw new Exception("No hay cuentas en la grilla!");
                var cuenta = _bllCuenta.RecuperarCuentaPorId(grillaCuentas.SelectedRows[0].Cells[0].Value.ToString());

                string montoInput = ucMonto1.RetornarText();
                if (ucMonto1.ValidarTextBox()) throw new Exception("El monto debe ser numérico!");
                decimal monto = Convert.ToDecimal(montoInput);

                _bllCuenta.Extraer(cuenta, monto);
                Mostrar(grillaCuentas, _bllCuenta.ConsultarCuentas());

                var titular = grillaTitulares.SelectedRows[0].DataBoundItem as BE_Titular;
                Mostrar(grillaCuentasDelTitular, _bllTitular.ConsultarCuentasAnonimo(titular));
                Mostrar(grillaSaldoPersonalizado, _bllCuenta.ConsultaTotalOrdenado());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTransferir_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaCuentas.Rows.Count == 0) throw new Exception("No hay una cuenta origen seleccionada!");
                if (grillaCuentasDelTitular.Rows.Count == 0) throw new Exception("No hay una cuenta destino seleccionada!");

                var cuentaOrigen = _bllCuenta.RecuperarCuentaPorId(grillaCuentas.SelectedRows[0].Cells[0].Value.ToString());
                var cuentaDestino = _bllCuenta.RecuperarCuentaPorId(grillaCuentasDelTitular.SelectedRows[0].Cells[0].Value.ToString());
                string montoInput = ucMonto1.RetornarText();
                if (ucMonto1.ValidarTextBox()) throw new Exception("El monto debe ser numérico!");
                decimal monto = Convert.ToDecimal(montoInput);

                _bllCuenta.Transferir(cuentaOrigen, cuentaDestino, monto);
                Mostrar(grillaCuentas, _bllCuenta.ConsultarCuentas());

                var titular = grillaTitulares.SelectedRows[0].DataBoundItem as BE_Titular;
                Mostrar(grillaCuentasDelTitular, _bllTitular.ConsultarCuentasAnonimo(titular));
                Mostrar(grillaSaldoPersonalizado, _bllCuenta.ConsultaTotalOrdenado());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDesdeHastaSaldo_Click(object sender, EventArgs e)
        {
            string desdeInput = Interaction.InputBox("Ingrese el valor desde", "Búsqueda (desde-hasta) por saldo");
            if (!decimal.TryParse(desdeInput, out decimal desde)) throw new Exception("El valor DESDE debe ser numérico!");
            string hastaInput = Interaction.InputBox("Ingrese el valor hasta", "Búsqueda (desde-hasta) por saldo");
            if (!decimal.TryParse(hastaInput, out decimal hasta)) throw new Exception("El valor DESDE debe ser numérico!");
            Mostrar(grillaSaldoDesdeHasta, _bllCuenta.ConsultaDesdeHastaPorSaldo(desde, hasta));
        }

        private void txtBusquedaIncrementalPorCodigo_TextChanged(object sender, EventArgs e)
        {
            Mostrar(grillaCodigoIncremental, _bllCuenta.ConsultaIncrementalPorCodigo(txtBusquedaIncrementalPorCodigo.Text));
        }

        private void btnGuardarXml_Click(object sender, EventArgs e)
        {
            _bllCuenta.GuardarXml();
            MessageBox.Show("Archivo guardado correctamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnAbrirXml_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", @"C:\Users\Blue\source\repos\DAS\DASW_2B_TM\Varios\Practica_Final\UI\bin\Debug\net8.0-windows\bd_banco.xml");
        }
    }
}
