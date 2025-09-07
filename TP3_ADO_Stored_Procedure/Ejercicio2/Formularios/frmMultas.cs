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
    public partial class frmMultas : frmBase
    {
        SqlConnection conexion;
        SqlCommand comando;
        List<Multa> multas;
        public frmMultas()
        {
            InitializeComponent();
        }
        private void MostrarDatos(string pComando)
        {
            conexion.Open();
            comando.Connection = conexion;
            CargarDatos(pComando);
            grillaMultas.DataSource = null;
            grillaMultas.DataSource = multas;
            conexion.Close();
        }

        private void CargarDatos(string pComando)
        {
            comando.Parameters.Clear();
            comando.CommandText = pComando;
            comando.CommandType = CommandType.StoredProcedure;
            multas.Clear();
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    object[] datos = new object[reader.FieldCount];
                    reader.GetValues(datos);
                    multas.Add(new Multa(datos));
                }
            }
        }
        private int ExtraerIdDelComboBox(ComboBox pComboBox) => Convert.ToInt16(pComboBox.SelectedItem.ToString().Split('-')[0].Trim());

        private void frmMultas_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla(grillaMultas);
            multas = new List<Multa>();
            conexion = new SqlConnection("Data Source=127.0.0.1,1433;Initial Catalog=bd_transito;User ID=administrador;Password=ETN7dolores;Trust Server Certificate=True");
            comando = new SqlCommand();
            MostrarDatos("sp_consultar_multas");

            comando.Parameters.Clear();
            comando.CommandText = "sp_consultar_vehiculo_propietario";
            comando.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    object[] datos = new object[reader.FieldCount];
                    reader.GetValues(datos); ;
                    cbxVehiculos.Items.Add($"{datos[0]}-{datos[1]} {datos[2]} de {datos[3]} {datos[4]}");
                }
            }
            conexion.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxVehiculos.SelectedIndex == -1) throw new Exception("Debe elegir un vehiculo!");
                var vehiculo = ExtraerIdDelComboBox(cbxVehiculos);
                DateTime fechaHora = Convert.ToDateTime(Interaction.InputBox("Ingrese la fecha y hora", "Multas", DateTime.Now.ToString()));
                string inputMonto = Interaction.InputBox("Ingrese el monto", "Multas");
                if (!decimal.TryParse(inputMonto, out decimal monto)) throw new Exception("El monto debe ser numérico!");
                if (monto < 0) throw new Exception("El monto no puede ser negativo!");
                string situacion = Interaction.InputBox("Ingrese la situación", "Multas");
                if (situacion.Length == 0) throw new Exception("La situación está vacia!");

                comando.CommandText = "sp_alta_multa";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@vehiculo", SqlDbType.Int).Value = vehiculo;
                comando.Parameters.Add("@fecha_hora", SqlDbType.DateTime).Value = fechaHora;
                comando.Parameters.Add("@monto", SqlDbType.Decimal).Value = monto;
                comando.Parameters.Add("@situacion", SqlDbType.NVarChar).Value = situacion;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();
                MostrarDatos("sp_consultar_multas");
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
                if (grillaMultas.Rows.Count == 0) throw new Exception("No hay multas!");
                var multa = grillaMultas.SelectedRows[0].DataBoundItem as Multa;

                comando.CommandText = "sp_baja_multa";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@id_multa", SqlDbType.Int).Value = multa.Id;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();
                MostrarDatos("sp_consultar_multas");
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
                if (grillaMultas.Rows.Count == 0) throw new Exception("No hay multas!");
                var multa = grillaMultas.SelectedRows[0].DataBoundItem as Multa;

                string inputMonto = Interaction.InputBox("Ingrese el monto", "Multas", multa.Monto.ToString());
                if (!decimal.TryParse(inputMonto, out decimal monto)) throw new Exception("El monto debe ser numérico!");
                if (monto < 0) throw new Exception("El monto no puede ser negativo!");
                string situacion = Interaction.InputBox("Ingrese la situación", "Multas",multa.Situacion);
                if (situacion.Length == 0) throw new Exception("La situación está vacia!");

                comando.CommandText = "sp_modificar_multa";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@id_multa", SqlDbType.Int).Value = multa.Id;
                comando.Parameters.Add("@monto", SqlDbType.Decimal).Value = monto;
                comando.Parameters.Add("@situacion", SqlDbType.NVarChar).Value = situacion;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();
                MostrarDatos("sp_consultar_multas");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e) => this.Close();
    }
}
