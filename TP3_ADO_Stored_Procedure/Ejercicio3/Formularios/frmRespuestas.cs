using Ejercicio3.Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio3.Formularios
{
    public partial class frmRespuestas : frmBase
    {
        SqlConnection conexion;
        SqlCommand comando;
        List<Opcion> opcionesPreguntaActual;
        List<Respuesta> respuestas;
        int idPreguntaActual = -1;
        int nivel = 1;

        public frmRespuestas()
        {
            InitializeComponent();
        }

        private void frmRespuestas_Load(object sender, EventArgs e)
        {
            conexion = new SqlConnection("Data Source=127.0.0.1,1433;Initial Catalog=bd_preguntas;User ID=administrador;Password=ETN7dolores;Trust Server Certificate=True");
            comando = new SqlCommand();
            opcionesPreguntaActual = new List<Opcion>();
            respuestas = new List<Respuesta>();
            ConfigurarGrilla(grillaRespuestas);

            comando.Parameters.Clear();
            comando.CommandText = "sp_consultar_jugadores";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Connection = conexion;
            conexion.Open();
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    object[] datos = new object[reader.FieldCount];
                    reader.GetValues(datos);
                    cbxJugadores.Items.Add($"{datos[1]}");
                }
            }
            conexion.Close();
        }
        private void CargarPreguntaYOpciones(int nivel)
        {
            comando.CommandText = "sp_consultar_pregunta_y_opciones";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Clear();
            comando.Parameters.Add("@nivel", SqlDbType.Int).Value = nivel;

            conexion.Open();
            comando.Connection = conexion;

            using (SqlDataReader reader = comando.ExecuteReader())
            {
                if (reader.Read())
                {
                    object[] datos = new object[reader.FieldCount];
                    reader.GetValues(datos);
                    idPreguntaActual = Convert.ToInt32(datos[0]);
                    lblPregunta.Text = Convert.ToString(datos[1]);
                    lblNivel.Text = $"Nivel: {Convert.ToInt32(datos[2])}";
                }

                if (reader.NextResult())
                {
                    opcionesPreguntaActual.Clear();
                    while (reader.Read())
                    {
                        object[] datos = new object[reader.FieldCount];
                        reader.GetValues(datos);
                        opcionesPreguntaActual.Add(new Opcion(datos));
                    }

                    flpOpciones.Controls.Clear();
                    foreach (var op in opcionesPreguntaActual)
                    {
                        RadioButton rb = new RadioButton();
                        rb.Text = op.Texto;
                        rb.Tag = op.Id;
                        rb.AutoSize = true;
                        flpOpciones.Controls.Add(rb);
                    }
                }
            }
            conexion.Close();
        }
        private int ObtenerIdJugadorPorNombre()
        {
            comando.CommandText = "sp_recuperar_id_por_nombre_jugador";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Clear();
            comando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = cbxJugadores.SelectedItem.ToString();
            conexion.Open();
            comando.Connection = conexion;
            int idJugador = Convert.ToInt16(comando.ExecuteScalar());
            conexion.Close();
            return idJugador;
        }
        private void btnCargarPregunta_Click(object sender, EventArgs e)
        {
            CargarPreguntaYOpciones(nivel);
        }
        private void btnResponder_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxJugadores.SelectedIndex == -1) throw new Exception("Seleccione un jugador!");

                var seleccionado = flpOpciones.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked);
                if (seleccionado == null) throw new Exception("Debe seleccionar una opción!");
                var opcionSeleccionada = opcionesPreguntaActual.FirstOrDefault(o => o.Id == (int)seleccionado.Tag);
                int idJugador = ObtenerIdJugadorPorNombre();

                comando.CommandText = "sp_alta_respuesta";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@jugador", SqlDbType.Int).Value = idJugador;
                comando.Parameters.Add("@pregunta", SqlDbType.Int).Value = opcionSeleccionada.Pregunta;
                comando.Parameters.Add("@opcion", SqlDbType.Int).Value = opcionSeleccionada.Id;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();

                if (opcionSeleccionada == null) throw new Exception("Error interno: la opción no existe.");
                if (opcionSeleccionada.EsCorrecta)
                {
                    MessageBox.Show("¡Correcto! Pasas al siguiente nivel.", "CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nivel++;
                    CargarPreguntaYOpciones(nivel);
                    MostrarDatos();
                }
                else
                {
                    MessageBox.Show("Incorrecto. Intenta nuevamente.", "INCORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MostrarDatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxJugadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxJugadores.SelectedIndex == -1) throw new Exception("El jugador no está seleccionado");
                MostrarDatos();

                int puntos = 0;
                foreach (DataGridViewRow fila in grillaRespuestas.Rows)
                {
                    if (fila.Cells["Puntos"].Value != null)
                    {
                        puntos += Convert.ToInt16(fila.Cells["Puntos"].Value);
                    }
                }
                lblPuntos.Text = puntos.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarDatos()
        {
            int idJugador = ObtenerIdJugadorPorNombre();
            respuestas.Clear();
            comando.CommandText = "sp_consultar_respuestas";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Clear();
            comando.Parameters.Add("@jugador", SqlDbType.Int).Value = idJugador;

            conexion.Open();
            comando.Connection = conexion;
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    object[] datos = new object[reader.FieldCount];
                    reader.GetValues(datos);
                    respuestas.Add(new Respuesta(datos));
                }
            }
            conexion.Close();
            grillaRespuestas.DataSource = null;
            grillaRespuestas.DataSource = respuestas;
        }
    }
}
