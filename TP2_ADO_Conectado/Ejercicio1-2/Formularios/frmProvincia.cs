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
    public partial class frmProvincia : Form
    {
        SqlConnection cx;
        SqlCommand cm;
        List<Provincia> provincias;
        public frmProvincia()
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
            grillaProvincias.DataSource = null;
            grillaProvincias.DataSource = provincias;
        }
        private void CargarDatos(string pConsultaSql)
        {
            cm.CommandText = pConsultaSql;
            provincias.Clear();

            using (SqlDataReader dr = cm.ExecuteReader())
            {
                while (dr.Read())
                {
                    object[] datos = new object[dr.FieldCount];
                    dr.GetValues(datos);
                    provincias.Add(new Provincia(datos));
                }
            }
        }
        private void frmProvincia_Load(object sender, EventArgs e)
        {
            grillaProvincias.MultiSelect = false;
            grillaProvincias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grillaProvincias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            provincias = new List<Provincia>();
            cx = new SqlConnection("Data Source=127.0.0.1,1433;Initial Catalog=bd_socios;User ID=administrador;Password='ETN7dolores';Trust Server Certificate=True");
            cx.StateChange += Funcion_MostrarEstadoConexion;
            cm = new SqlCommand("select * from provincia", cx);
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cx.State == ConnectionState.Closed)
                {
                    cx.Open();
                    MostrarDatos("select * from provincia");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            cx.Close();
            grillaProvincias.DataSource = null;
            provincias.Clear();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = Interaction.InputBox("Ingrese el nombre de la provincia", "Agregando provincia");
                if (nombre.Length == 0) throw new Exception("La provincia está vacia!");

                cm.Parameters.Clear();
                cm.Parameters.AddWithValue("@nombre", nombre); cm.Parameters[0].DbType = DbType.String;
                cm.CommandText = $"insert into provincia(nombre) values(@nombre)";
                cm.ExecuteNonQuery();
                MostrarDatos("select * from provincia");
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
                if (grillaProvincias.Rows.Count == 0) throw new Exception("No hay registros de provincias");
                cm.CommandText = $"delete from provincia where id_provincia = {grillaProvincias.SelectedRows[0].Cells[0].Value}";
                cm.ExecuteNonQuery();
                MostrarDatos("select * from provincia");
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
                if (grillaProvincias.Rows.Count == 0) throw new Exception("No hay registros de provincias");
                string nombre = Interaction.InputBox("Ingrese el nombre de la provincia", "Modificando provincia", grillaProvincias.SelectedRows[0].Cells[1].Value.ToString());
                if (nombre.Length == 0) throw new Exception("La provincia está vacia!");
                cm.Parameters.Clear();
                cm.Parameters.AddWithValue("@nombre", nombre); cm.Parameters[0].DbType = DbType.String;
                cm.CommandText = $"update provincia set nombre = '{nombre}' where id_provincia = {grillaProvincias.SelectedRows[0].Cells[0].Value}";
                cm.ExecuteNonQuery();
                MostrarDatos("select * from provincia");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e) => this.Close();
    }
}
