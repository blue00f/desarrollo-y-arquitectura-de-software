using Ejercicio1.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio1.Formularios
{
    public partial class frmObras : frmBase
    {
        SqlConnection conexion;
        SqlCommand comando;
        List<Obra> obras;
        public frmObras()
        {
            InitializeComponent();
        }
        private void MostrarDatos(string pComando)
        {
            conexion.Open();
            CargarDatos(pComando);
            grillaObras.DataSource = null;
            grillaObras.DataSource = obras;
            conexion.Close();
        }
        private void CargarDatos(string pComando)
        {
            comando.Parameters.Clear();
            comando.CommandText = pComando;
            comando.CommandType = CommandType.StoredProcedure;
            obras.Clear();
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    object[] datos = new object[reader.FieldCount];
                    reader.GetValues(datos);
                    obras.Add(new Obra(datos));
                }
            }
        }
        private void frmObras_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla(grillaObras);
            obras = new List<Obra>();
            conexion = new SqlConnection("Data Source=127.0.0.1,1433;Initial Catalog=bd_biblioteca;User ID=administrador;Password=ETN7dolores;Trust Server Certificate=True");
            comando = new SqlCommand();
            comando.Connection = conexion;
            MostrarDatos("sp_consultar_obras");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string titulo = Interaction.InputBox("Ingrese el título", "Obra");
                if (titulo.Length == 0) throw new Exception("Titulo vacio!");
                string autor = Interaction.InputBox("Ingrese el autor", "Obra");
                if (autor.Length == 0) throw new Exception("Autor vacio!");
                string fechaLanzamientoInput = Interaction.InputBox("Ingrese la fecha de lanzamiento (DD-MM-AAAA)", "Obra");
                DateTime? fechaLanzamiento = null;
                if (fechaLanzamientoInput.Length != 0)
                {
                    if (DateTime.TryParse(fechaLanzamientoInput, out DateTime tempFecha)) fechaLanzamiento = tempFecha;
                    else throw new Exception("Fecha inválida");
                }

                comando.CommandText = "sp_alta_obra";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@titulo", SqlDbType.NVarChar).Value = titulo;
                comando.Parameters.Add("@autor", SqlDbType.NVarChar).Value = autor;
                comando.Parameters.Add("@fecha_lanzamiento", SqlDbType.Date).Value = fechaLanzamiento.HasValue ? fechaLanzamiento : DBNull.Value;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();
                MostrarDatos("sp_consultar_obras");
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
                if (grillaObras.Rows.Count == 0) throw new Exception("No hay obras!");
                var obra = grillaObras.SelectedRows[0].DataBoundItem as Obra;

                comando.CommandText = "sp_baja_obra";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@id_obra", SqlDbType.Int).Value = obra.Id;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();
                MostrarDatos("sp_consultar_obras");
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
                if (grillaObras.Rows.Count == 0) throw new Exception("No hay obras!");
                var obra = grillaObras.SelectedRows[0].DataBoundItem as Obra;

                string titulo = Interaction.InputBox("Ingrese el título", "Obra", obra.Titulo);
                if (titulo.Length == 0) throw new Exception("Titulo vacio!");
                string autor = Interaction.InputBox("Ingrese el autor", "Obra", obra.Autor);
                if (autor.Length == 0) throw new Exception("Autor vacio!");
                string fechaLanzamientoInput = Interaction.InputBox("Ingrese la fecha de lanzamiento (DD-MM-AAAA)", "Obra", obra.FechaLanzamiento.HasValue ? obra.FechaLanzamiento.Value.ToShortDateString() : "");
                DateTime? fechaLanzamiento = null;
                if (fechaLanzamientoInput.Length != 0)
                {
                    if (DateTime.TryParse(fechaLanzamientoInput, out DateTime tempFecha)) fechaLanzamiento = tempFecha;
                    else throw new Exception("Fecha inválida");
                }

                comando.CommandText = "sp_modificar_obra";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@id_obra", SqlDbType.Int).Value = obra.Id;
                comando.Parameters.Add("@titulo", SqlDbType.NVarChar).Value = titulo;
                comando.Parameters.Add("@autor", SqlDbType.NVarChar).Value = autor;
                comando.Parameters.Add("@fecha_lanzamiento", SqlDbType.Date).Value = fechaLanzamiento.HasValue ? fechaLanzamiento : DBNull.Value;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();
                MostrarDatos("sp_consultar_obras");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e) => this.Close();
    }
}
