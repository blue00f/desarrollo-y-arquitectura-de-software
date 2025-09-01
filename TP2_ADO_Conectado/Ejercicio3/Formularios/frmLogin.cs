using Ejercicio3.Entidades;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Ejercicio3
{
    public partial class frmLogin : Form
    {
        SqlConnection cx;
        SqlCommand cm;
        public frmLogin()
        {
            InitializeComponent();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtClave.PasswordChar = '*';
            cx = new SqlConnection("Data Source=127.0.0.1,1433;Initial Catalog=bd_usuarios;User ID=administrador;Password=ETN7dolores;Trust Server Certificate=True");
            cm = new SqlCommand(); cm.Connection = cx;
            cx.Open();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text.Trim();
                string clave = txtClave.Text.Trim();

                if (nombre.Length == 0 || clave.Length == 0)
                    throw new Exception("Debe ingresar usuario y contraseña");

                cm.Parameters.Clear();
                cm.Parameters.AddWithValue("@nombre", nombre);
                cm.Parameters[0].DbType = DbType.String;
                cm.CommandText = "SELECT * FROM usuarios WHERE nombre = @nombre";

                Usuario usuario = null;
                using (var dr = cm.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        object[] datos = new object[dr.FieldCount];
                        dr.GetValues(datos);
                        usuario = new Usuario(datos);
                    }
                }

                if (usuario == null)
                {
                    MessageBox.Show("Usuario no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (usuario.Bloqueado)
                {
                    MessageBox.Show("Usuario bloqueado. Contacte al administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (usuario.Clave != clave)
                {
                    int nuevosIntentos = usuario.IntentosFallidos + 1;
                    bool bloquear = nuevosIntentos >= 3;

                    cm.Parameters.Clear();
                    cm.Parameters.AddWithValue("@intentos", nuevosIntentos); cm.Parameters[0].DbType = DbType.Int32;
                    cm.Parameters.AddWithValue("@bloqueado", bloquear); cm.Parameters[1].DbType = DbType.Boolean;
                    cm.Parameters.AddWithValue("@id_usuario", usuario.Id); cm.Parameters[2].DbType = DbType.Int32;
                    cm.CommandText = "UPDATE usuarios SET intentosFallidos = @intentos, bloqueado = @bloqueado WHERE id_usuario = @id_usuario";
                    cm.ExecuteNonQuery();

                    MessageBox.Show(bloquear
                        ? "Usuario bloqueado después de 3 intentos fallidos."
                        : $"Contraseña incorrecta. Intentos: {nuevosIntentos}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                cm.Parameters.Clear();
                cm.Parameters.AddWithValue("@id_usuario", usuario.Id); cm.Parameters[0].DbType = DbType.Int32;
                cm.CommandText = "UPDATE usuarios SET intentosFallidos = 0 WHERE id_usuario = @id_usuario";
                cm.ExecuteNonQuery();

                if (usuario.Rol == "Administrador")
                {
                    var frmAdmin = new frmVistaAdmin();
                    frmAdmin.Show();
                }
                else
                {
                    var frmUsuario = new frmVistaUsuario();
                    frmUsuario.Show();
                }
                txtNombre.Text = "";
                txtClave.Text = "";
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSalir_Click(object sender, EventArgs e) => Application.Exit();
    }
}
