using Ejercicio1.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Data;

namespace Ejercicio1.Formularios
{
    public partial class frmAlumnos : frmBase
    {
        SqlConnection conexion;
        SqlCommand comando;
        List<Alumno> alumnos;
        public frmAlumnos()
        {
            InitializeComponent();
        }
        private void MostrarDatos(string pComando)
        {
            conexion.Open();
            CargarDatos(pComando);
            grillaAlumnos.DataSource = null;
            grillaAlumnos.DataSource = alumnos;
            conexion.Close();
        }
        private void CargarDatos(string pComando)
        {
            comando.Parameters.Clear();
            comando.CommandText = pComando;
            comando.CommandType = CommandType.StoredProcedure;
            alumnos.Clear();
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    object[] datos = new object[reader.FieldCount];
                    reader.GetValues(datos);
                    alumnos.Add(new Alumno(datos));
                }
            }
        }
        private void frmAlumnos_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla(grillaAlumnos);
            alumnos = new List<Alumno>();
            conexion = new SqlConnection("Data Source=127.0.0.1,1433;Initial Catalog=bd_biblioteca;User ID=administrador;Password=ETN7dolores;Trust Server Certificate=True");
            comando = new SqlCommand();
            comando.Connection = conexion;
            MostrarDatos("sp_consultar_alumnos");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = Interaction.InputBox("Ingrese el nombre", "Alumno");
                if (nombre.Length == 0) throw new Exception("Nombre vacio!");
                string apellido = Interaction.InputBox("Ingrese el apellido", "Alumno");
                if (apellido.Length == 0) throw new Exception("Apellido vacio!");
                string dni = Interaction.InputBox("Ingrese el DNI", "Alumno");
                if (dni.Length != 8) throw new Exception("DNI inválido!");
                comando.CommandText = "sp_consultar_dni";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@dni", SqlDbType.Int).Value = dni;
                conexion.Open();
                comando.Connection = conexion;
                if (Convert.ToInt32(comando.ExecuteScalar()) == 1) throw new Exception("Dni repetido!");
                conexion.Close();
                string correo = Interaction.InputBox("Ingrese el correo", "Alumno");
                if (correo.Length == 0) throw new Exception("Correo vacio!");

                string fechaInput = Interaction.InputBox("Ingrese la fecha de nacimiento (DD-MM-AAAA)", "Alumno");
                DateTime? fechaNacimiento = null;

                if (fechaInput.Length != 0)
                {
                    if (DateTime.TryParse(fechaInput, out DateTime tempFecha)) fechaNacimiento = tempFecha;
                    else throw new Exception("Fecha inválida!");
                }

                comando.CommandText = "sp_alta_alumno";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;
                comando.Parameters.Add("@apellido", SqlDbType.NVarChar).Value = apellido;
                comando.Parameters.Add("@dni", SqlDbType.Char, 8).Value = dni;
                comando.Parameters.Add("@correo", SqlDbType.NVarChar).Value = correo;
                comando.Parameters.Add("@fecha_nacimiento", SqlDbType.Date).Value = fechaNacimiento.HasValue ? fechaNacimiento : DBNull.Value;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();
                MostrarDatos("sp_consultar_alumnos");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexion.Close();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaAlumnos.Rows.Count == 0) throw new Exception("No hay alumnos!");
                comando.CommandText = "sp_baja_alumno";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();

                var alumno = grillaAlumnos.SelectedRows[0].DataBoundItem as Alumno;
                comando.Parameters.Add("@id_alumno", SqlDbType.Int).Value = alumno.Id;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();
                MostrarDatos("sp_consultar_alumnos");
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
                if (grillaAlumnos.Rows.Count == 0) throw new Exception("No hay alumnos!");
                var alumno = grillaAlumnos.SelectedRows[0].DataBoundItem as Alumno;
                string nombre = Interaction.InputBox("Ingrese el nombre", "Alumno", alumno.Nombre);
                if (nombre.Length == 0) throw new Exception("Nombre vacio!");
                string apellido = Interaction.InputBox("Ingrese el apellido", "Alumno", alumno.Apellido);
                if (apellido.Length == 0) throw new Exception("Apellido vacio!");
                string correo = Interaction.InputBox("Ingrese el correo", "Alumno", alumno.Correo);
                if (correo.Length == 0) throw new Exception("Correo vacio!");

                string fechaInput = Interaction.InputBox("Ingrese la fecha de nacimiento (DD-MM-AAAA)", "Alumno", alumno.FechaNacimiento.HasValue ? alumno.FechaNacimiento.Value.ToShortDateString() : "");
                DateTime? fechaNacimiento = null;

                if (fechaInput.Length != 0)
                {
                    if (DateTime.TryParse(fechaInput, out DateTime tempFecha)) fechaNacimiento = tempFecha;
                    else throw new Exception("Fecha inválida!");
                }
                comando.CommandText = "sp_modificar_alumno";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Clear();
                comando.Parameters.Add("@id_alumno", SqlDbType.Int).Value = alumno.Id;
                comando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;
                comando.Parameters.Add("@apellido", SqlDbType.NVarChar).Value = apellido;
                comando.Parameters.Add("@correo", SqlDbType.NVarChar).Value = correo;
                comando.Parameters.Add("@fecha_nacimiento", SqlDbType.Date).Value = fechaNacimiento.HasValue ? fechaNacimiento : DBNull.Value;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();
                MostrarDatos("sp_consultar_alumnos");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e) => this.Close();
    }
}
