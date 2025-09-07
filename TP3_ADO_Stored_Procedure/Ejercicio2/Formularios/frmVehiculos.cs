using Ejercicio2.Entidades;
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

namespace Ejercicio2.Formularios
{
    public partial class frmVehiculos : frmBase
    {
        SqlConnection conexion;
        SqlCommand comando;
        List<Vehiculo> vehiculos;
        public frmVehiculos()
        {
            InitializeComponent();
        }
        private void MostrarDatos(string pComando)
        {
            conexion.Open();
            CargarDatos(pComando);
            grillaVehiculos.DataSource = null;
            grillaVehiculos.DataSource = vehiculos;
            conexion.Close();
        }
        private void CargarDatos(string pComando)
        {
            comando.Connection = conexion;
            comando.CommandText = pComando;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Clear();
            vehiculos.Clear();
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    object[] datos = new object[reader.FieldCount];
                    reader.GetValues(datos);
                    vehiculos.Add(new Vehiculo(datos));
                }
            }
        }
        private int ExtraerIdDelComboBox(ComboBox pComboBox) => Convert.ToInt16(pComboBox.SelectedItem.ToString().Split('-')[0].Trim());

        private void frmVehiculos_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla(grillaVehiculos);
            vehiculos = new List<Vehiculo>();
            conexion = new SqlConnection("Data Source=127.0.0.1,1433;Initial Catalog=bd_transito;User ID=administrador;Password=ETN7dolores;Trust Server Certificate=True");
            comando = new SqlCommand();
            MostrarDatos("sp_consultar_vehiculos");

            comando.Parameters.Clear();
            comando.CommandText = "sp_consultar_propietarios";
            comando.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    object[] datos = new object[reader.FieldCount];
                    reader.GetValues(datos); ;
                    cbxPropietarios.Items.Add($"{datos[0]}-{datos[1]} {datos[2]}");
                }
            }
            conexion.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxPropietarios.SelectedIndex == -1) throw new Exception("Debe tener seleccionado un propietario");
                int propietario = ExtraerIdDelComboBox(cbxPropietarios);
                string patente = Interaction.InputBox("Ingrese la patente (AB123CD)", "Vehiculos");
                if (patente.Length != 7) throw new Exception("Patente inválido");
                string marca = Interaction.InputBox("Ingrese la marca", "Vehiculos");
                if (marca.Length == 0) throw new Exception("Marca vacia!");
                string modelo = Interaction.InputBox("Ingrese el modelo", "Vehiculos");
                if (modelo.Length == 0) throw new Exception("Modelo vacio");
                string inputAnio = Interaction.InputBox("Ingrese el año", "Vehiculos");
                if (inputAnio.Length != 4) throw new Exception("Año incorrecto!");
                if (!int.TryParse(inputAnio, out int anio)) throw new Exception("El año debe ser numérico!");

                comando.CommandText = "sp_alta_vehiculo";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@propietario", SqlDbType.Int).Value = propietario;
                comando.Parameters.Add("@patente", SqlDbType.Char, 7).Value = patente;
                comando.Parameters.Add("@marca", SqlDbType.NVarChar).Value = marca;
                comando.Parameters.Add("@modelo", SqlDbType.NVarChar).Value = modelo;
                comando.Parameters.Add("@anio", SqlDbType.Int).Value = anio;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();
                MostrarDatos("sp_consultar_vehiculos");
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
                if (grillaVehiculos.Rows.Count == 0) throw new Exception("No hay vehiculos!");
                var vehiculo = grillaVehiculos.SelectedRows[0].DataBoundItem as Vehiculo;

                comando.CommandText = "sp_baja_vehiculo";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@id_vehiculo", SqlDbType.Int).Value = vehiculo.Id;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();

                MostrarDatos("sp_consultar_vehiculos");
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
                if (grillaVehiculos.Rows.Count == 0) throw new Exception("No hay vehiculos!");
                var vehiculo = grillaVehiculos.SelectedRows[0].DataBoundItem as Vehiculo;
                string patente = Interaction.InputBox("Ingrese la patente (AB123CD)", "Vehiculos", vehiculo.Patente);
                if (patente.Length != 7) throw new Exception("Patente inválido");
                string marca = Interaction.InputBox("Ingrese la marca", "Vehiculos", vehiculo.Marca);
                if (marca.Length == 0) throw new Exception("Marca vacia!");
                string modelo = Interaction.InputBox("Ingrese el modelo", "Vehiculos", vehiculo.Modelo);
                if (modelo.Length == 0) throw new Exception("Modelo vacio");
                string inputAnio = Interaction.InputBox("Ingrese el año", "Vehiculos", vehiculo.Anio.ToString());
                if (inputAnio.Length != 4) throw new Exception("Año incorrecto!");
                if (!int.TryParse(inputAnio, out int anio)) throw new Exception("El año debe ser numérico!");

                comando.CommandText = "sp_modificar_vehiculo";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@id_vehiculo", SqlDbType.Int).Value = vehiculo.Id;
                comando.Parameters.Add("@patente", SqlDbType.Char, 7).Value = patente;
                comando.Parameters.Add("@marca", SqlDbType.NVarChar).Value = marca;
                comando.Parameters.Add("@modelo", SqlDbType.NVarChar).Value = modelo;
                comando.Parameters.Add("@anio", SqlDbType.Int).Value = anio;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();

                MostrarDatos("sp_consultar_vehiculos");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e) => this.Close();
    }
}
