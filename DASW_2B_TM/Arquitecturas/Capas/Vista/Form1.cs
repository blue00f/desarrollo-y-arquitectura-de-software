using BLL;
using Entidades;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Vista
{
    public partial class Form1 : Form
    {
        BLL_Prestamo bllPre;
        BLL_PrestamoVista bllPreVista;
        public Form1()
        {
            InitializeComponent();
            bllPreVista = new BLL_PrestamoVista();
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
            bllPre = new BLL_Prestamo();
            RefrescaGrillaPrestamos(grillaPrestamos, bllPreVista.ConsultaTodosPrestamos());
            grillaPrestamos_RowEnter(null, null);

            if (radIncremental.Checked == false) txtConsultaPorCodigo.Visible = false;
        }
        public void RefrescaGrillaPrestamos(DataGridView pGrilla, object pDatos)
        {
            pGrilla.DataSource = null; pGrilla.DataSource = pDatos;
        }

        #region "Funciones de Validación"
        public bool ExistePrestamo(BE_Prestamo _pPrestamo, List<BE_Prestamo> _pListaPrestamos)
        {
            return _pListaPrestamos.Exists(x => x.Codigo == _pPrestamo.Codigo);
        }
        public bool EsNumerico(string pString)
        {
            return Information.IsNumeric(pString);
        }
        public bool EsFecha(string pString)
        {
            return Information.IsDate(pString);
        }
        Regex r = new Regex(@"\d{2}[.]\d{3}[.]\d{3}");
        public bool ValidaDNI(BE_Persona pPersona)
        {
            return r.IsMatch(pPersona.DNI);
        }
        #endregion

        private void btnAltaPrestamo_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo;
                string montoOtorgado;
                string fechaOtorgamiento;
                string fechaVencimiento;
                string interes;
                string interesPunitorio;
                string dni;

                codigo = Interaction.InputBox("Código: ");
                BE_Prestamo pre = new BE_Prestamo(codigo);
                if (ExistePrestamo(pre, bllPre.ConsultaTodosPrestamos())) { throw new Exception("El código que intenta ingresar existe !!!"); };
                montoOtorgado = Interaction.InputBox("Monto: ");

                if (!EsNumerico(montoOtorgado)) { throw new Exception("El monto ingresado no es numérico !!!"); }
                fechaOtorgamiento = Interaction.InputBox("Fecha de Otorgamiento: ", "Préstamo");

                if (!EsFecha(fechaOtorgamiento)) { throw new Exception("La fecha ingresada no es válida !!!"); }
                fechaVencimiento = Interaction.InputBox("Fecha de Vencimiento: ", "Préstamo");

                if (!EsFecha(fechaVencimiento)) { throw new Exception("La fecha ingresada no es válida !!!"); }
                interes = Interaction.InputBox("Interés: ", "Préstamo");

                if (!EsNumerico(interes)) { throw new Exception("El monto ingresado no es numérico !!!"); }
                interesPunitorio = Interaction.InputBox("Interés Punitorio: ", "Préstamo");

                if (!EsNumerico(interesPunitorio)) { throw new Exception("El monto ingresado no es numérico !!!"); }

                pre.MontoOtorgado = decimal.Parse(montoOtorgado);
                pre.FechaOtorgado = Convert.ToDateTime(fechaOtorgamiento);
                pre.FechaVencimiento = Convert.ToDateTime(fechaVencimiento);
                pre.Interes = decimal.Parse(interes);
                pre.InteresPunitorio = decimal.Parse(interesPunitorio);
                dni = Interaction.InputBox("DNI (99.999.999): ", "Formato de ingreso 99.999.999", "Persona");
                BE_Persona per = new BE_Persona(dni);
                if (!ValidaDNI(per)) { throw new Exception("El DNI ingresado es inválido !!!"); }
                per.Nombre = Interaction.InputBox("Nombre: ", "Persona");
                per.Apellido = Interaction.InputBox("Apellido: ", "Persona");
                pre.Persona = per;

                // Solicito servicio a BLL
                bllPre.Alta(pre);
                RefrescaGrillaPrestamos(grillaPrestamos, bllPreVista.ConsultaTodosPrestamos());
                grillaPrestamos_RowEnter(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBajaPrestamo_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaPrestamos.Rows.Count == 0) throw new Exception("No hay préstamos para borrar !!!");
                var codigo = grillaPrestamos.SelectedRows[0].Cells[0].Value.ToString();
                var prestamo = bllPre.ConsultaTodosPrestamos().Find(p => p.Codigo == codigo);
                bllPre.Baja(prestamo);
                RefrescaGrillaPrestamos(grillaPrestamos, bllPreVista.ConsultaTodosPrestamos());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnModificarPrestamo_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaPrestamos.Rows.Count == 0) throw new Exception("No hay préstamos para modificar !!!");
                var codigo = grillaPrestamos.SelectedRows[0].Cells[0].Value.ToString();
                var prestamo = bllPre.ConsultaTodosPrestamos().Find(p => p.Codigo == codigo);

                prestamo.MontoOtorgado = decimal.Parse(Interaction.InputBox("Nuevo monto: ", "Préstamo"));
                prestamo.FechaOtorgado = Convert.ToDateTime(Interaction.InputBox("Fecha otorgada: ", "Préstamo"));
                prestamo.Interes = decimal.Parse(Interaction.InputBox("Nuevo interes: ", "Préstamo"));
                prestamo.InteresPunitorio = decimal.Parse(Interaction.InputBox("Nuevo interes punitorio: ", "Préstamo"));
                prestamo.FechaVencimiento = Convert.ToDateTime(Interaction.InputBox("Fecha vencimiento: ", "Préstamo"));

                bllPre.Modificacion(prestamo);
                RefrescaGrillaPrestamos(grillaPrestamos, bllPreVista.ConsultaTodosPrestamos());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnConsultarCodigo_Click(object sender, EventArgs e)
        {
            if (radDesdeHasta.Checked)
            {
                string desde = Interaction.InputBox("Buscar desde: ", "Consulta Desde/Hasta");
                string hasta = Interaction.InputBox("Buscar hasta: ", "Consulta Desde/Hasta");
                RefrescaGrillaPrestamos(grillaConsultas, bllPreVista.ConsultaDesdeHasta(new BE_Prestamo(desde), new BE_Prestamo(hasta)));
            }
            if (radBusquedaNormal.Checked)
            {
                string codigo = Interaction.InputBox("Ingrese el código a buscar: ", "Conulsta normal de código");
                RefrescaGrillaPrestamos(grillaConsultas, bllPreVista.Consulta(new BE_Prestamo(codigo)));
            }
        }
        private void radIncremental_CheckedChanged(object sender, EventArgs e)
        {
            if (radIncremental.Checked) { txtConsultaPorCodigo.Visible = true; label2.Visible = false; }
            else { txtConsultaPorCodigo.Visible = false; txtConsultaPorCodigo.Text = string.Empty; }
        }
        private void txtConsultaPorCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtConsultaPorCodigo.Text == string.Empty) { grillaConsultas.DataSource = null; }
            else
            {
                string s = txtConsultaPorCodigo.Text;
                RefrescaGrillaPrestamos(grillaConsultas, bllPreVista.ConsultaIncremental(new BE_Prestamo(s)));
            }
        }
        private void grillaPrestamos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grillaPrestamos.Rows.Count == 0) throw new Exception("No hay préstamos seleccionados !!!");
                var codigo = grillaPrestamos.SelectedRows[0].Cells[0].Value.ToString();
                txtInfoPersona.Text = (bllPre.ConsultaTodosPrestamos().Find(p => p.Codigo == codigo)).Persona.ToString();
            }
            catch (Exception)
            {
                txtInfoPersona.Clear();
            }
        }
    }
}
