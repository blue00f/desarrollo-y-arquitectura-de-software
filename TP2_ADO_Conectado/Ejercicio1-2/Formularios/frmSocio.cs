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
    public partial class frmSocio : Form
    {
        SqlConnection cx;
        SqlCommand cm;
        List<Socio> socios;
        List<Pais> paises;
        List<Provincia> provincias;
        public frmSocio()
        {
            InitializeComponent();
        }
        private void Funcion_MostrarEstadoConexion(object sender, StateChangeEventArgs e)
        {
            if (e.CurrentState == ConnectionState.Open) MessageBox.Show("Base de datos conectada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Base de datos desconectada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void MostrarDatos<T>(string pConsultaSql, DataGridView pGrilla, List<T> pLista, Func<object[], T> pConstructor)
        {
            CargarDatos(pConsultaSql, pLista, pConstructor);
            pGrilla.DataSource = null;
            pGrilla.DataSource = pLista;
        }
        private void CargarDatos<T>(string pConsultasSql, List<T> pLista, Func<object[], T> pConstructor)
        {
            cm.CommandText = pConsultasSql;
            pLista.Clear();

            using (SqlDataReader dr = cm.ExecuteReader())
            {
                while (dr.Read())
                {
                    object[] datos = new object[dr.FieldCount];
                    dr.GetValues(datos);
                    pLista.Add(pConstructor(datos));
                }
            }
        }
        private void frmSocio_Load(object sender, EventArgs e)
        {
            foreach (var control in Controls)
            {
                if (control is DataGridView grilla)
                {
                    grilla.MultiSelect = false;
                    grilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            socios = new List<Socio>();
            paises = new List<Pais>();
            provincias = new List<Provincia>();
            cx = new SqlConnection("Data Source=127.0.0.1,1433;Initial Catalog=bd_socios;User ID=administrador;Password='ETN7dolores';Trust Server Certificate=True");
            cx.StateChange += Funcion_MostrarEstadoConexion;
            cm = new SqlCommand("select * from socio", cx);
        }
        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cx.State == ConnectionState.Closed)
                {
                    cx.Open();
                    MostrarDatos("select * from socio", grillaSocios, socios, datos => new Socio(datos));
                    MostrarDatos("select * from pais", grillaPaises, paises, datos => new Pais(datos));
                    MostrarDatos("select * from provincia", grillaProvincias, provincias, datos => new Provincia(datos));
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
            grillaSocios.DataSource = null; socios.Clear();
            grillaPaises.DataSource = null; paises.Clear();
            grillaProvincias.DataSource = null; provincias.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaPaises.Rows.Count == 0) throw new Exception("No hay registros de países para asignar!");
                if (grillaProvincias.Rows.Count == 0) throw new Exception("No hay registros de provincias para asignar!");

                string nombre = Interaction.InputBox("Ingrese el nombre", "Agregando socio");
                if (nombre.Length == 0) throw new Exception("El nombre está vacio!");
                string apellido = Interaction.InputBox("Ingrese el apellido", "Agregando socio");
                if (nombre.Length == 0) throw new Exception("El apellido está vacio!");
                string email = Interaction.InputBox("Ingrese el email", "Agregando socio");
                if (nombre.Length == 0) throw new Exception("El email está vacio!");

                var pais = grillaPaises.SelectedRows[0].DataBoundItem as Pais;
                var provincia = grillaProvincias.SelectedRows[0].DataBoundItem as Provincia;

                cm.Parameters.Clear();
                cm.Parameters.AddWithValue("@nombre", nombre); cm.Parameters[0].DbType = DbType.String;
                cm.Parameters.AddWithValue("@apellido", apellido); cm.Parameters[1].DbType = DbType.String;
                cm.Parameters.AddWithValue("@email", email); cm.Parameters[2].DbType = DbType.String;
                cm.Parameters.AddWithValue("@id_pais", pais.Id); cm.Parameters[3].DbType = DbType.Int16;
                cm.Parameters.AddWithValue("@id_provincia", provincia.Id); cm.Parameters[4].DbType = DbType.Int16;

                cm.CommandText = $"insert into socio(nombre,apellido,email,id_pais,id_provincia) values(@nombre,@apellido,@email,@id_pais,@id_provincia)";
                cm.ExecuteNonQuery();
                MostrarDatos("select * from socio", grillaSocios, socios, datos => new Socio(datos));
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
                if (grillaSocios.Rows.Count == 0) throw new Exception("No hay registros de socios");
                cm.CommandText = $"delete from socio where id_socio = {grillaSocios.SelectedRows[0].Cells[0].Value}";
                cm.ExecuteNonQuery();
                MostrarDatos("select * from socio", grillaSocios, socios, datos => new Socio(datos));
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
                if (grillaPaises.Rows.Count == 0) throw new Exception("No hay registros de países para asignar!");
                if (grillaProvincias.Rows.Count == 0) throw new Exception("No hay registros de provincias para asignar!");
                var rdo = MessageBox.Show("Debe tener seleccionado un registro de la grilla de países y de provincias. ¿Quiere continuar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rdo == DialogResult.Yes)
                {
                    var socio = grillaSocios.SelectedRows[0].DataBoundItem as Socio;
                    var pais = grillaPaises.SelectedRows[0].DataBoundItem as Pais;
                    var provincia = grillaProvincias.SelectedRows[0].DataBoundItem as Provincia;

                    string nombre = Interaction.InputBox("Ingrese el nombre", "Modificando socio", socio.Nombre);
                    if (nombre.Length == 0) throw new Exception("El nombre está vacio!");
                    string apellido = Interaction.InputBox("Ingrese el apellido", "Modificando socio", socio.Apellido);
                    if (nombre.Length == 0) throw new Exception("El apellido está vacio!");
                    string email = Interaction.InputBox("Ingrese el email", "Modificando socio", socio.Email);
                    if (nombre.Length == 0) throw new Exception("El email está vacio!");

                    cm.Parameters.Clear();
                    cm.Parameters.AddWithValue("@nombre", nombre); cm.Parameters[0].DbType = DbType.String;
                    cm.CommandText = $"update socio set nombre='{nombre}', apellido='{apellido}', email='{email}', id_pais={pais.Id}, id_provincia={provincia.Id} where id_socio = {grillaSocios.SelectedRows[0].Cells[0].Value}";
                    cm.ExecuteNonQuery();
                    MostrarDatos("select * from socio", grillaSocios, socios, datos => new Socio(datos));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e) => this.Close();
    }
}
