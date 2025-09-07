using Ejercicio2.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio2.Formularios
{
    public partial class frmPropietarios : frmBase
    {
        SqlConnection conexion;
        SqlCommand comando;
        List<Propietario> propietarios;
        public frmPropietarios()
        {
            InitializeComponent();
        }

        private void frmPropietarios_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla(grillaPropietarios);
            propietarios = new List<Propietario>();
            conexion = new SqlConnection("Data Source=127.0.0.1,1433;Initial Catalog=bd_transito;User ID=administrador;Password=ETN7dolores;Trust Server Certificate=True");
            comando = new SqlCommand();
            MostrarDatos("sp_consultar_propietarios");
        }

        private void MostrarDatos(string pComando)
        {
            conexion.Open();
            comando.Connection = conexion;
            CargarDatos(pComando);
            grillaPropietarios.DataSource = null;
            grillaPropietarios.DataSource = propietarios;
            conexion.Close();
        }

        private void CargarDatos(string pComando)
        {
            comando.Parameters.Clear();
            comando.CommandText = pComando;
            comando.CommandType = CommandType.StoredProcedure;
            propietarios.Clear();
            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    object[] datos = new object[reader.FieldCount];
                    reader.GetValues(datos);
                    propietarios.Add(new Propietario(datos));
                }
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = Interaction.InputBox("Ingrese el nombre", "Propietarios");
                if (nombre.Length == 0) throw new Exception("Nombre vacio!");
                string apellido = Interaction.InputBox("Ingrese el apellido", "Propietarios");
                if (apellido.Length == 0) throw new Exception("Apellido vacio!");
                string dni = Interaction.InputBox("Ingrese el DNI", "Propietarios");
                if (dni.Length != 8) throw new Exception("DNI incorrecto!");

                comando.CommandText = "sp_consultar_dni";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@dni", SqlDbType.Char, 8).Value = dni;
                conexion.Open();
                comando.Connection = conexion;
                if (Convert.ToInt16(comando.ExecuteScalar()) == 1) throw new Exception("Dni repetido!");
                conexion.Close();


                string domicilio = Interaction.InputBox("Ingrese el domicilio", "Propietarios");
                if (domicilio.Length == 0) throw new Exception("Domicilio vacio!");

                comando.CommandText = "sp_alta_propietario";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;
                comando.Parameters.Add("@apellido", SqlDbType.NVarChar).Value = apellido;
                comando.Parameters.Add("@dni", SqlDbType.Char, 8).Value = dni;
                comando.Parameters.Add("@domicilio", SqlDbType.NVarChar).Value = domicilio;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();
                MostrarDatos("sp_consultar_propietarios");
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
                if (grillaPropietarios.Rows.Count == 0) throw new Exception("No hay propietarios");
                var propietario = grillaPropietarios.SelectedRows[0].DataBoundItem as Propietario;
                comando.CommandText = "sp_baja_propietario";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@id_propietario", SqlDbType.Int).Value = propietario.Id;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();
                MostrarDatos("sp_consultar_propietarios");
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
                if (grillaPropietarios.Rows.Count == 0) throw new Exception("No hay propietarios");
                var propietario = grillaPropietarios.SelectedRows[0].DataBoundItem as Propietario;

                string nombre = Interaction.InputBox("Ingrese el nombre", "Propietarios", propietario.Nombre);
                if (nombre.Length == 0) throw new Exception("Nombre vacio!");
                string apellido = Interaction.InputBox("Ingrese el apellido", "Propietarios", propietario.Apellido);
                if (apellido.Length == 0) throw new Exception("Apellido vacio!");
                string domicilio = Interaction.InputBox("Ingrese el domicilio", "Propietarios", propietario.Domicilio);
                if (domicilio.Length == 0) throw new Exception("Domicilio vacio!");

                comando.CommandText = "sp_modificar_propietario";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Clear();
                comando.Parameters.Add("@id_propietario", SqlDbType.Int).Value = propietario.Id;
                comando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;
                comando.Parameters.Add("@apellido", SqlDbType.NVarChar).Value = apellido;
                comando.Parameters.Add("@domicilio", SqlDbType.NVarChar).Value = domicilio;

                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                conexion.Close();
                MostrarDatos("sp_consultar_propietarios");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e) => this.Close();
    }
}
