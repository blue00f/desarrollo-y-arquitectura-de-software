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

namespace Ejercicio3
{
    public partial class frmVistaAdmin : Form
    {
        SqlConnection cx;
        SqlCommand cm;
        List<Usuario> usuarios;
        public frmVistaAdmin()
        {
            InitializeComponent();
        }

        private void MostrarDatos(string pConsultaSql)
        {
            CargarDatos(pConsultaSql);
            grillaUsuarios.DataSource = null;
            grillaUsuarios.DataSource = usuarios;
        }
        private void CargarDatos(string pConsultaSql)
        {
            cm.CommandText = pConsultaSql;
            usuarios.Clear();

            using (SqlDataReader dr = cm.ExecuteReader())
            {
                while (dr.Read())
                {
                    object[] datos = new object[dr.FieldCount];
                    dr.GetValues(datos);
                    usuarios.Add(new Usuario(datos));
                }
            }
        }

        private void frmVistaAdmin_Load(object sender, EventArgs e)
        {
            grillaUsuarios.MultiSelect = false;
            grillaUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grillaUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            usuarios = new List<Usuario>();
            cx = new SqlConnection("Data Source=127.0.0.1,1433;Initial Catalog=bd_usuarios;User ID=administrador;Password=ETN7dolores;Trust Server Certificate=True");
            cm = new SqlCommand("select * from usuarios", cx);
            cx.Open();
            MostrarDatos("select * from usuarios");
        }

        private void btnDesbloquearUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaUsuarios.Rows.Count == 0) throw new Exception("No hay registros de usuarios");
                var usuario = grillaUsuarios.SelectedRows[0].DataBoundItem as Usuario;
                cm.Parameters.Clear();
                cm.Parameters.AddWithValue("@bloqueado", !usuario.Bloqueado); cm.Parameters[0].DbType = DbType.Boolean;
                cm.Parameters.AddWithValue("@id_usuario", usuario.Id); cm.Parameters[1].DbType = DbType.Int16;

                cm.CommandText = $"update usuarios set bloqueado = @bloqueado where id_usuario = @id_usuario";
                cm.ExecuteNonQuery();
                MostrarDatos("select * from usuarios");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            frmLogin login = Application.OpenForms.OfType<frmLogin>().FirstOrDefault();
            if (login != null) login.Show();
            this.Close();
        }
    }
}
