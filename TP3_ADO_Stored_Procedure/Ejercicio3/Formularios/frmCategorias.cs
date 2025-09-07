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
    public partial class frmCategorias : frmBase
    {
        SqlConnection conexion;
        SqlCommand comando;
        List<Categoria> categorias;
        public frmCategorias()
        {
            InitializeComponent();
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla(grillaCategorias);
            categorias = new List<Categoria>();
            conexion = new SqlConnection("Data Source=127.0.0.1,1433;Initial Catalog=bd_preguntas;User ID=administrador;Password=ETN7dolores;Trust Server Certificate=True");
            comando = new SqlCommand();
            MostrarDatos("sp_consultar_categorias");
        }
        private void MostrarDatos(string pComando)
        {
            conexion.Open();
            comando.Connection = conexion;
            CargarDatos(pComando);
            grillaCategorias.DataSource = null;
            grillaCategorias.DataSource = categorias;
            conexion.Close();
        }
        private void CargarDatos(string pComando)
        {
            comando.Parameters.Clear();
            comando.CommandText = pComando;
            comando.CommandType = CommandType.StoredProcedure;
            categorias.Clear();
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    object[] datos = new object[reader.FieldCount];
                    reader.GetValues(datos);
                    categorias.Add(new Categoria(datos));
                }
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = Interaction.InputBox("Ingrese el nombre", "Categoría");
                if (nombre.Length == 0) throw new Exception("Nombre vacio!");

                comando.CommandText = "sp_alta_categoria";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();
                MostrarDatos("sp_consultar_categorias");
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
                if (grillaCategorias.Rows.Count == 0) throw new Exception("No hay categorías!");
                var categoria = grillaCategorias.SelectedRows[0].DataBoundItem as Categoria;

                comando.CommandText = "sp_baja_categoria";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@id_categoria", SqlDbType.NVarChar).Value = categoria.Id;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();
                MostrarDatos("sp_consultar_categorias");
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
                if (grillaCategorias.Rows.Count == 0) throw new Exception("No hay categorías!");
                var categoria = grillaCategorias.SelectedRows[0].DataBoundItem as Categoria;

                string nombre = Interaction.InputBox("Ingrese el nombre", "Categoría", categoria.Nombre);
                if (nombre.Length == 0) throw new Exception("Nombre vacio!");

                comando.CommandText = "sp_modificar_categoria";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@id_categoria", SqlDbType.NVarChar).Value = categoria.Id;
                comando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();
                MostrarDatos("sp_consultar_categorias");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e) => this.Close();
    }
}
