using Ejercicio3.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio3.Formularios
{
    public partial class frmPreguntas : frmBase
    {
        SqlConnection conexion;
        SqlCommand comando;
        List<Pregunta> preguntas;
        public frmPreguntas()
        {
            InitializeComponent();
        }

        private void frmPreguntas_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla(grillaPreguntas);
            preguntas = new List<Pregunta>();
            conexion = new SqlConnection("Data Source=127.0.0.1,1433;Initial Catalog=bd_preguntas;User ID=administrador;Password=ETN7dolores;Trust Server Certificate=True");
            comando = new SqlCommand();
            MostrarDatos("sp_consultar_preguntas");

            comando.Parameters.Clear();
            comando.CommandText = "sp_consultar_categorias";
            comando.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    object[] datos = new object[reader.FieldCount];
                    reader.GetValues(datos); ;
                    cbxCategorias.Items.Add($"{datos[1]}");
                }
            }
            conexion.Close();
        }
        private void MostrarDatos(string pComando)
        {
            conexion.Open();
            comando.Connection = conexion;
            CargarDatos(pComando);
            grillaPreguntas.DataSource = null;
            grillaPreguntas.DataSource = preguntas;
            conexion.Close();
        }
        private void CargarDatos(string pComando)
        {
            comando.Parameters.Clear();
            comando.CommandText = pComando;
            comando.CommandType = CommandType.StoredProcedure;
            preguntas.Clear();
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    object[] datos = new object[reader.FieldCount];
                    reader.GetValues(datos);
                    preguntas.Add(new Pregunta(datos));
                }
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxCategorias.SelectedIndex == -1) throw new Exception("Debe haber una categoría seleccionada!");
                comando.CommandText = "sp_recuperar_id_por_nombre_categoria";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                string nombre = cbxCategorias.SelectedItem.ToString();
                comando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;
                conexion.Open();
                comando.Connection = conexion;
                int categoria = Convert.ToInt16(comando.ExecuteScalar());
                conexion.Close();

                string texto = Interaction.InputBox("Ingrese la pregunta", "Pregunta");
                if (texto.Length == 0) throw new Exception("Pregunta vacía");
                string inputNivel = Interaction.InputBox("Ingrese el nivel de la pregunta", "Pregunta");
                if (!int.TryParse(inputNivel, out int nivel)) throw new Exception("El nivel debe ser numérico");
                string inputValor = Interaction.InputBox("Ingrese el valor de la pregunta", "Pregunta");
                if (!int.TryParse(inputValor, out int valor)) throw new Exception("El valor debe ser numérico");

                comando.CommandText = "sp_alta_pregunta";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@texto", SqlDbType.NVarChar).Value = texto;
                comando.Parameters.Add("@nivel", SqlDbType.Int).Value = nivel;
                comando.Parameters.Add("@valor", SqlDbType.Int).Value = valor;
                comando.Parameters.Add("@categoria", SqlDbType.Int).Value = categoria;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();
                MostrarDatos("sp_consultar_preguntas");
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
                if (grillaPreguntas.Rows.Count == 0) throw new Exception("No hay preguntas!");
                var pregunta = grillaPreguntas.SelectedRows[0].DataBoundItem as Pregunta;

                comando.CommandText = "sp_baja_pregunta";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@id_pregunta", SqlDbType.Int).Value = pregunta.Id;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();
                MostrarDatos("sp_consultar_preguntas");
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
                if (grillaPreguntas.Rows.Count == 0) throw new Exception("No hay preguntas!");
                if (cbxCategorias.SelectedIndex == -1) throw new Exception("Debe haber una categoría seleccionada!");

                var pregunta = grillaPreguntas.SelectedRows[0].DataBoundItem as Pregunta;
                comando.CommandText = "sp_recuperar_id_por_nombre_categoria";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                string nombre = cbxCategorias.SelectedItem.ToString();
                comando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;
                conexion.Open();
                comando.Connection = conexion;
                int categoria = Convert.ToInt16(comando.ExecuteScalar());
                conexion.Close();

                string texto = Interaction.InputBox("Ingrese la pregunta", "Pregunta", pregunta.Texto);
                if (texto.Length == 0) throw new Exception("Pregunta vacía");
                string inputNivel = Interaction.InputBox("Ingrese el nivel de la pregunta", "Pregunta", pregunta.Nivel.ToString());
                if (!int.TryParse(inputNivel, out int nivel)) throw new Exception("El nivel debe ser numérico");
                string inputValor = Interaction.InputBox("Ingrese el valor de la pregunta", "Pregunta", pregunta.Valor.ToString());
                if (!int.TryParse(inputValor, out int valor)) throw new Exception("El valor debe ser numérico");

                comando.CommandText = "sp_modificar_pregunta";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@id_pregunta", SqlDbType.Int).Value = pregunta.Id;
                comando.Parameters.Add("@texto", SqlDbType.NVarChar).Value = texto;
                comando.Parameters.Add("@nivel", SqlDbType.Int).Value = nivel;
                comando.Parameters.Add("@valor", SqlDbType.Int).Value = valor;
                comando.Parameters.Add("@categoria", SqlDbType.Int).Value = categoria;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();
                MostrarDatos("sp_consultar_preguntas");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSalir_Click(object sender, EventArgs e) => this.Close();
    }
}
