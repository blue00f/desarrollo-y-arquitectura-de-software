using BE;
using BLL;
using Microsoft.VisualBasic;

namespace UI
{
    public partial class Form1 : Form
    {
        BLL_Empleado bllEmpleado;
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
            bllEmpleado = new BLL_Empleado();
            Mostrar(grillaEmpleados, bllEmpleado.ConsultaPersonalizada());
        }
        private void Mostrar(DataGridView pGrilla, object pDatos)
        {
            pGrilla.DataSource = null;
            pGrilla.DataSource = pDatos;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string legajo = ucLegajo1.RetornarText();
                if (legajo.Length == 0) throw new Exception("Legajo vacío!");
                if (ucLegajo1.CargarTextBox(legajo)) throw new Exception("Legajo incorrecto!");
                if (bllEmpleado.ValidarCodigoRepetido(new BE_Empleado(legajo))) throw new Exception("El legajo está repetido!");
                string nombre = Interaction.InputBox("Ingrese el nombre", "Agregando empleado");
                if (nombre.Length == 0) throw new Exception("Nombre vacío!");
                string apellido = Interaction.InputBox("Ingrese el apellido", "Agregando empleado");
                if (apellido.Length == 0) throw new Exception("Apellido vacío!");
                DateTime fechaIngreso = Convert.ToDateTime(Interaction.InputBox("Ingrese la fecha de ingreso", "Agregando empleado", DateTime.Now.ToShortDateString()));

                BE_Empleado empleado = new BE_Empleado(legajo, nombre, apellido, fechaIngreso);
                bllEmpleado.Agregar(empleado);
                Mostrar(grillaEmpleados, bllEmpleado.ConsultaPersonalizada());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaEmpleados.Rows.Count == 0) throw new Exception("No hay filas de empleados!");
                BE_Empleado empleado = bllEmpleado.RecuperarEmpleadoPorCodigo(grillaEmpleados.SelectedRows[0].Cells[0].Value.ToString());
                bllEmpleado.Borrar(empleado);
                Mostrar(grillaEmpleados, bllEmpleado.ConsultaPersonalizada());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaEmpleados.Rows.Count == 0) throw new Exception("No hay filas de empleados!");
                BE_Empleado empleadoViejo = bllEmpleado.RecuperarEmpleadoPorCodigo(grillaEmpleados.SelectedRows[0].Cells[0].Value.ToString());

                string nombre = Interaction.InputBox("Ingrese el nombre", "Modificando empleado", empleadoViejo.Nombre);
                if (nombre.Length == 0) throw new Exception("Nombre vacío!");
                string apellido = Interaction.InputBox("Ingrese el apellido", "Modificando empleado", empleadoViejo.Apellido);
                if (apellido.Length == 0) throw new Exception("Apellido vacío!");
                DateTime fechaIngreso = Convert.ToDateTime(Interaction.InputBox("Ingrese la fecha de ingreso", "Modificando empleado", empleadoViejo.FechaIngreso.ToShortDateString()));

                BE_Empleado empleado = new BE_Empleado(empleadoViejo.Legajo, nombre, apellido, fechaIngreso);
                bllEmpleado.Modificar(empleado);
                Mostrar(grillaEmpleados, bllEmpleado.ConsultaPersonalizada());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtApellidoBusquedaIncremental_TextChanged(object sender, EventArgs e)
        {
            Mostrar(grillaEmpleados, bllEmpleado.ConsultaIncrementalPorApellido(txtApellidoBusquedaIncremental.Text));
        }

        private void btnVerTodos_Click(object sender, EventArgs e)
        {
            Mostrar(grillaEmpleados, bllEmpleado.ConsultaPersonalizada());
        }
    }
}
