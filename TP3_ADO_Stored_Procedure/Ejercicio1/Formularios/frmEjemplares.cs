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
    public partial class frmEjemplares : frmBase
    {
        SqlConnection conexion;
        SqlCommand comando;
        List<Ejemplar> ejemplares;
        public frmEjemplares()
        {
            InitializeComponent();
        }
        private void MostrarDatos(string pComando)
        {
            conexion.Open();
            CargarDatos(pComando);
            grillaEjemplares.DataSource = null;
            grillaEjemplares.DataSource = ejemplares;
            conexion.Close();
        }
        private void CargarDatos(string pComando)
        {
            comando.Parameters.Clear();
            comando.CommandText = pComando;
            comando.CommandType = CommandType.StoredProcedure;
            ejemplares.Clear();
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    object[] datos = new object[reader.FieldCount];
                    reader.GetValues(datos);
                    ejemplares.Add(new Ejemplar(datos));
                }
            }
        }
        private void frmEjemplares_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla(grillaEjemplares);
            ejemplares = new List<Ejemplar>();
            conexion = new SqlConnection("Data Source=127.0.0.1,1433;Initial Catalog=bd_biblioteca;User ID=administrador;Password=ETN7dolores;Trust Server Certificate=True");
            comando = new SqlCommand();
            comando.Connection = conexion;
            MostrarDatos("sp_consultar_ejemplares");

            comando.Parameters.Clear();
            comando.CommandText = "sp_consultar_obras";
            comando.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    object[] datos = new object[reader.FieldCount];
                    reader.GetValues(datos);;
                    cbxObras.Items.Add($"{datos[0]}-{datos[1]} de {datos[2]}");
                }
            }
            conexion.Close();
        }
        private int ExtraerIdDelComboBox(ComboBox pComboBox) => Convert.ToInt16(pComboBox.SelectedItem.ToString().Split('-')[0].Trim());
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxObras.SelectedIndex == -1) throw new Exception("No hay una obra seleccionada");
                int obra = ExtraerIdDelComboBox(cbxObras);
                string numInventarioInput = Interaction.InputBox("Ingrese el número de inventario", "Ejemplar");
                if (!int.TryParse(numInventarioInput, out int numInventario)) throw new Exception("El número de inventario debe ser numérico");
                string precioInput = Interaction.InputBox("Ingrese el precio", "Ejemplar");
                if (!decimal.TryParse(precioInput, out decimal precio)) throw new Exception("El precio debe ser numérico");
                if (precio < 0) throw new Exception("El precio es incorrecto!");

                comando.CommandText = "sp_alta_ejemplar"; comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@obra", SqlDbType.Int).Value = obra;
                comando.Parameters.Add("@num_inventario", SqlDbType.Int).Value = numInventario;
                comando.Parameters.Add("@precio", SqlDbType.Decimal).Value = precio;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();
                MostrarDatos("sp_consultar_ejemplares");
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
                if (grillaEjemplares.Rows.Count == 0) throw new Exception("No hay ejemplares");
                var ejemplar = grillaEjemplares.SelectedRows[0].DataBoundItem as Ejemplar;

                comando.CommandText = "sp_baja_ejemplar"; comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@id_ejemplar", SqlDbType.Int).Value = ejemplar.Id;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();
                MostrarDatos("sp_consultar_ejemplares");
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
                if (grillaEjemplares.Rows.Count == 0) throw new Exception("No hay ejemplares");
                if (cbxObras.SelectedIndex == -1) throw new Exception("No hay una obra seleccionada");

                var ejemplar = grillaEjemplares.SelectedRows[0].DataBoundItem as Ejemplar;
                int obra = Convert.ToInt16(cbxObras.SelectedItem.ToString().Split('-')[0].Trim());

                string numInventarioInput = Interaction.InputBox("Ingrese el número de inventario", "Ejemplar", ejemplar.NumeroInventario.ToString());
                if (!int.TryParse(numInventarioInput, out int numInventario)) throw new Exception("El número de inventario debe ser numérico");
                string precioInput = Interaction.InputBox("Ingrese el precio", "Ejemplar", ejemplar.Precio.ToString());
                if (!decimal.TryParse(precioInput, out decimal precio)) throw new Exception("El precio debe ser numérico");
                if (precio < 0) throw new Exception("El precio es incorrecto!");

                comando.CommandText = "sp_modificar_ejemplar"; comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@id_ejemplar", SqlDbType.Int).Value = ejemplar.Id;
                comando.Parameters.Add("@obra", SqlDbType.Int).Value = obra;
                comando.Parameters.Add("@num_inventario", SqlDbType.Int).Value = numInventario;
                comando.Parameters.Add("@precio", SqlDbType.Decimal).Value = precio;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();
                MostrarDatos("sp_consultar_ejemplares");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e) => this.Close();
    }
}
