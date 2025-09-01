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

namespace Ejercicio1
{
    public partial class frmPais : Form
    {
        SqlConnection conexion;
        SqlCommand comando;
        List<Pais> paises;
        public frmPais()
        {
            InitializeComponent();
        }
        private void Funcion_MostrarEstadoConexion(object sender, StateChangeEventArgs e)
        {
            if (e.CurrentState == ConnectionState.Open) MessageBox.Show("Base de datos conectada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Base de datos desconectada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void MostrarDatos(string pConsultaSql)
        {
            CargarDatos(pConsultaSql);
            grillaPaises.DataSource = null;
            grillaPaises.DataSource = paises;
        }
        private void CargarDatos(string pConsultaSql)
        {
            comando.CommandText = pConsultaSql;
            paises.Clear();

            using (SqlDataReader dr = comando.ExecuteReader())
            {
                while (dr.Read())
                {
                    object[] datos = new object[dr.FieldCount];
                    dr.GetValues(datos);
                    paises.Add(new Pais(datos));
                }
            }
        }
        private void frmPais_Load(object sender, EventArgs e)
        {
            grillaPaises.MultiSelect = false;
            grillaPaises.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grillaPaises.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            paises = new List<Pais>();
            conexion = new SqlConnection("Data Source=127.0.0.1,1433;Initial Catalog=bd_socios;User ID=administrador;Password='ETN7dolores';Trust Server Certificate=True");
            conexion.StateChange += Funcion_MostrarEstadoConexion;
            comando = new SqlCommand("select * from pais", conexion);
        }
        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                    MostrarDatos("select * from pais");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            conexion.Close();
            grillaPaises.DataSource = null;
            paises.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = Interaction.InputBox("Ingrese el nombre del país", "Agregando país");
                if (nombre.Length == 0) throw new Exception("El país está vacio!");

                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@nombre", nombre); comando.Parameters[0].DbType = DbType.String;
                comando.CommandText = $"insert into pais(nombre) values(@nombre)";
                comando.ExecuteNonQuery();
                MostrarDatos("select * from pais");
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
                if (grillaPaises.Rows.Count == 0) throw new Exception("No hay registros de países");
                comando.CommandText = $"delete from pais where id_pais = {grillaPaises.SelectedRows[0].Cells[0].Value}";
                comando.ExecuteNonQuery();
                MostrarDatos("select * from pais");
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
                if (grillaPaises.Rows.Count == 0) throw new Exception("No hay registros de países");
                string nombre = Interaction.InputBox("Ingrese el nombre del país", "Modificando país", grillaPaises.SelectedRows[0].Cells[1].Value.ToString());
                if (nombre.Length == 0) throw new Exception("El país está vacio!");
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@nombre", nombre); comando.Parameters[0].DbType = DbType.String;
                comando.CommandText = $"update pais set nombre = '{nombre}' where id_pais = {grillaPaises.SelectedRows[0].Cells[0].Value}";
                comando.ExecuteNonQuery();
                MostrarDatos("select * from pais");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e) => this.Close();
    }
}
