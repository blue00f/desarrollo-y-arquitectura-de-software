using Ejercicio3.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Data;

namespace Ejercicio3.Formularios
{
    public partial class frmJugadores : frmBase
    {
        SqlConnection conexion;
        SqlCommand comando;
        List<Jugador> jugadores;
        public frmJugadores()
        {
            InitializeComponent();
        }
        private void frmJugadores_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla(grillaJugadores);
            jugadores = new List<Jugador>();
            conexion = new SqlConnection("Data Source=127.0.0.1,1433;Initial Catalog=bd_preguntas;User ID=administrador;Password=ETN7dolores;Trust Server Certificate=True");
            comando = new SqlCommand();
            MostrarDatos("sp_consultar_jugadores");
        }
        private void MostrarDatos(string pComando)
        {
            conexion.Open();
            comando.Connection = conexion;
            CargarDatos(pComando);
            grillaJugadores.DataSource = null;
            grillaJugadores.DataSource = jugadores;
            conexion.Close();
        }
        private void CargarDatos(string pComando)
        {
            comando.Parameters.Clear();
            comando.CommandText = pComando;
            comando.CommandType = CommandType.StoredProcedure;
            jugadores.Clear();
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    object[] datos = new object[reader.FieldCount];
                    reader.GetValues(datos);
                    jugadores.Add(new Jugador(datos));
                }
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = Interaction.InputBox("Ingrese el nombre", "Jugador");
                if (nombre.Length == 0) throw new Exception("Nombre vacio!");

                comando.CommandText = "sp_alta_jugador";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();
                MostrarDatos("sp_consultar_jugadores");
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
                if (grillaJugadores.Rows.Count == 0) throw new Exception("No hay jugadores!");
                var jugador = grillaJugadores.SelectedRows[0].DataBoundItem as Jugador;

                comando.CommandText = "sp_baja_jugador";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@id_jugador", SqlDbType.NVarChar).Value = jugador.Id;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();
                MostrarDatos("sp_consultar_jugadores");
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
                if (grillaJugadores.Rows.Count == 0) throw new Exception("No hay jugadores!");
                var jugador = grillaJugadores.SelectedRows[0].DataBoundItem as Jugador;

                string nombre = Interaction.InputBox("Ingrese el nombre", "Jugador", jugador.Nombre);
                if (nombre.Length == 0) throw new Exception("Nombre vacio!");

                comando.CommandText = "sp_modificar_jugador";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@id_jugador", SqlDbType.NVarChar).Value = jugador.Id;
                comando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();
                MostrarDatos("sp_consultar_jugadores");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSalir_Click(object sender, EventArgs e) => this.Close();
    }
}
