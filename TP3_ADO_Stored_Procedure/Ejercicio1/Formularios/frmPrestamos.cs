using Ejercicio1.Entidades;
using Microsoft.Data.SqlClient;
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

namespace Ejercicio1.Formularios
{
    public partial class frmPrestamos : frmBase
    {
        SqlConnection conexion;
        SqlCommand comando;
        List<Prestamo> prestamos;
        public frmPrestamos()
        {
            InitializeComponent();
        }
        private void MostrarDatos(string pComando)
        {
            conexion.Open();
            CargarDatos(pComando);
            grillaPrestamos.DataSource = null;
            grillaPrestamos.DataSource = prestamos;
            conexion.Close();
        }
        private void CargarDatos(string pComando)
        {
            comando.Parameters.Clear();
            comando.CommandText = pComando;
            comando.CommandType = CommandType.StoredProcedure;
            prestamos.Clear();
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    object[] datos = new object[reader.FieldCount];
                    reader.GetValues(datos);
                    prestamos.Add(new Prestamo(datos));
                }
            }
        }
        private void frmPrestamos_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla(grillaPrestamos);
            prestamos = new List<Prestamo>();
            conexion = new SqlConnection("Data Source=127.0.0.1,1433;Initial Catalog=bd_biblioteca;User ID=administrador;Password=ETN7dolores;Trust Server Certificate=True");
            comando = new SqlCommand();
            comando.Connection = conexion;
            MostrarDatos("sp_consultar_prestamos");

            comando.Parameters.Clear();
            comando.CommandText = "sp_consultar_alumnos";
            comando.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    object[] datos = new object[reader.FieldCount];
                    reader.GetValues(datos); ;
                    cbxAlumnos.Items.Add($"{datos[0]}-{datos[1]} {datos[2]}");
                }
            }
            conexion.Close();

            comando.Parameters.Clear();
            comando.CommandText = "sp_consultar_ejemplar_obra";
            comando.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    object[] datos = new object[reader.FieldCount];
                    reader.GetValues(datos); ;
                    cbxEjemplares.Items.Add($"{datos[0]}-{datos[1]} de {datos[2]} - ${datos[3]}");
                }
            }
            conexion.Close();
        }
        private int ExtraerIdDelComboBox(ComboBox pComboBox) => Convert.ToInt16(pComboBox.SelectedItem.ToString().Split('-')[0].Trim());

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxAlumnos.SelectedIndex == -1) throw new Exception("Debe tener seleccionado un alumno!");
                if (cbxEjemplares.SelectedIndex == -1) throw new Exception("Debe tener seleccionado una obra!");
                int alumno = ExtraerIdDelComboBox(cbxAlumnos);
                int ejemplar = ExtraerIdDelComboBox(cbxEjemplares);
                DateTime fechaPrestamo = Convert.ToDateTime(Interaction.InputBox("Ingrese la fecha", "Préstamos", DateTime.Now.ToShortDateString()));

                comando.CommandText = "sp_alta_prestamo"; comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@alumno", SqlDbType.Int).Value = alumno;
                comando.Parameters.Add("@ejemplar", SqlDbType.Int).Value = ejemplar;
                comando.Parameters.Add("@fecha_prestamo", SqlDbType.Date).Value = fechaPrestamo;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();
                MostrarDatos("sp_consultar_prestamos");
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
                if (grillaPrestamos.Rows.Count == 0) throw new Exception("No hay préstamos!");
                var prestamo = grillaPrestamos.SelectedRows[0].DataBoundItem as Prestamo;

                comando.CommandText = "sp_baja_prestamo"; comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@id_prestamo", SqlDbType.Int).Value = prestamo.Id;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();
                MostrarDatos("sp_consultar_prestamos");
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
                if (grillaPrestamos.Rows.Count == 0) throw new Exception("No hay préstamos!");
                if (cbxAlumnos.SelectedIndex == -1) throw new Exception("Debe tener seleccionado un alumno!");
                if (cbxEjemplares.SelectedIndex == -1) throw new Exception("Debe tener seleccionado una obra!");
                var prestamo = grillaPrestamos.SelectedRows[0].DataBoundItem as Prestamo;
                int alumno = ExtraerIdDelComboBox(cbxAlumnos);
                int ejemplar = ExtraerIdDelComboBox(cbxEjemplares);
                DateTime fechaPrestamo = Convert.ToDateTime(Interaction.InputBox("Ingrese la fecha", "Préstamos", prestamo.FechaPrestamo.ToShortDateString()));

                comando.CommandText = "sp_modificar_prestamo"; comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@id_prestamo", SqlDbType.Int).Value = prestamo.Id;
                comando.Parameters.Add("@alumno", SqlDbType.Int).Value = alumno;
                comando.Parameters.Add("@ejemplar", SqlDbType.Int).Value = ejemplar;
                comando.Parameters.Add("@fecha_prestamo", SqlDbType.Date).Value = fechaPrestamo;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();
                MostrarDatos("sp_consultar_prestamos");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e) => this.Close();
    }
}
