using Ejercicio3.Entidades;
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

namespace Ejercicio3.Formularios
{
    public partial class frmOpciones : frmBase
    {
        SqlConnection conexion;
        SqlCommand comando;
        List<Opcion> opciones;
        public frmOpciones()
        {
            InitializeComponent();
        }
        private void frmOpciones_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla(grillaOpciones);
            opciones = new List<Opcion>();
            conexion = new SqlConnection("Data Source=127.0.0.1,1433;Initial Catalog=bd_preguntas;User ID=administrador;Password=ETN7dolores;Trust Server Certificate=True");
            comando = new SqlCommand();

            comando.Parameters.Clear();
            comando.CommandText = "sp_consultar_preguntas";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Connection = conexion;
            conexion.Open();
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    object[] datos = new object[reader.FieldCount];
                    reader.GetValues(datos); ;
                    cbxPreguntas.Items.Add($"{datos[1]}");
                }
            }
            conexion.Close();
        }
        private int ObtenerIdPreguntaPorNombre()
        {
            comando.CommandText = "sp_recuperar_id_por_nombre_pregunta";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Clear();
            string textoPregunta = cbxPreguntas.SelectedItem.ToString();
            comando.Parameters.Add("@texto", SqlDbType.NVarChar).Value = textoPregunta;
            conexion.Open();
            comando.Connection = conexion;
            int pregunta = Convert.ToInt16(comando.ExecuteScalar());
            conexion.Close();
            return pregunta;
        }
        private void cbxPreguntas_SelectedIndexChanged(object sender, EventArgs e) => MostrarDatos("sp_consultar_opciones");
        private void MostrarDatos(string pComando)
        {
            int pregunta = ObtenerIdPreguntaPorNombre();
            conexion.Close();

            conexion.Open();
            comando.Connection = conexion;
            CargarDatos(pComando, pregunta);
            grillaOpciones.DataSource = null;
            grillaOpciones.DataSource = opciones;
            conexion.Close();
        }
        private void CargarDatos(string pComando, int pPreguntaId)
        {
            comando.Parameters.Clear();
            comando.CommandText = pComando;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@pregunta", SqlDbType.Int).Value = pPreguntaId;

            opciones.Clear();
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    object[] datos = new object[reader.FieldCount];
                    reader.GetValues(datos);
                    opciones.Add(new Opcion(datos));
                }
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxPreguntas.SelectedIndex == -1) throw new Exception("Debe haber una pregunta seleccionada!");
                int pregunta = ObtenerIdPreguntaPorNombre();

                string texto = Interaction.InputBox("Ingrese la opción", "Opción");
                if (texto.Length == 0) throw new Exception("Opción vacía");
                DialogResult rta = MessageBox.Show("¿Es correcta la opción?", "Opción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                bool esCorrecta = (rta == DialogResult.Yes);

                comando.CommandText = "sp_alta_opcion";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@texto", SqlDbType.NVarChar).Value = texto;
                comando.Parameters.Add("@es_correcta", SqlDbType.Bit).Value = esCorrecta;
                comando.Parameters.Add("@pregunta", SqlDbType.Int).Value = pregunta;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();
                MostrarDatos("sp_consultar_opciones");
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
                if (grillaOpciones.Rows.Count == 0) throw new Exception("No hay opciones");
                var opcion = grillaOpciones.SelectedRows[0].DataBoundItem as Opcion;
                comando.CommandText = "sp_baja_opcion";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@id_opcion", SqlDbType.Int).Value = opcion.Id;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();
                MostrarDatos("sp_consultar_opciones");
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
                if (grillaOpciones.Rows.Count == 0) throw new Exception("No hay opciones");
                var opcion = grillaOpciones.SelectedRows[0].DataBoundItem as Opcion;

                string texto = Interaction.InputBox("Ingrese la opción", "Opción", opcion.Texto);
                if (texto.Length == 0) throw new Exception("Opción vacía");
                DialogResult rta = MessageBox.Show("¿Es correcta la opción?", "Opción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                bool esCorrecta = (rta == DialogResult.Yes);

                comando.CommandText = "sp_modificar_opcion";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@id_opcion", SqlDbType.Int).Value = opcion.Id;
                comando.Parameters.Add("@texto", SqlDbType.NVarChar).Value = texto;
                comando.Parameters.Add("@es_correcta", SqlDbType.Bit).Value = esCorrecta;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();
                MostrarDatos("sp_consultar_opciones");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSalir_Click(object sender, EventArgs e) => this.Close();
    }
}
