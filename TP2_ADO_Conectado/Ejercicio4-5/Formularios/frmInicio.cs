using Ejercicio4_5.Entidades;
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

namespace Ejercicio4_5.Formularios
{
    public partial class frmInicio : Form
    {
        private Usuario Usuario;
        SqlConnection cx;
        SqlCommand cm;
        List<Producto> productos;
        List<Categoria> categorias;
        List<Log> logs;
        public frmInicio(Usuario pUsuario)
        {
            InitializeComponent();
            Usuario = pUsuario;
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

        private void RegistrarLog(string pOperacion, Usuario pUsuario)
        {
            try
            {
                cm.Parameters.Clear();
                cm.Parameters.AddWithValue("@fecha", DateTime.Now); cm.Parameters[0].DbType = DbType.DateTime;
                cm.Parameters.AddWithValue("@operacion", pOperacion); cm.Parameters[1].DbType = DbType.String;
                cm.Parameters.AddWithValue("@id_usuario", pUsuario.Id); cm.Parameters[2].DbType = DbType.Int16;

                cm.CommandText = "insert into logs(fecha, operacion, id_usuario) values(@fecha, @operacion, @id_usuario)";
                cm.ExecuteNonQuery();
                MostrarDatos("select * from logs", grillaLogs, logs, datos => new Log(datos));

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error registrando log: " + ex.Message);
            }
        }
        private void frmInicio_Load(object sender, EventArgs e)
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
            
            productos = new List<Producto>();
            categorias = new List<Categoria>();
            logs = new List<Log>();

            cx = new SqlConnection("Data Source=127.0.0.1,1433;Initial Catalog=bd_empresa;User ID=administrador;Password=ETN7dolores;Trust Server Certificate=True");
            cm = new SqlCommand(); cm.Connection = cx;
            cx.Open();
            MostrarDatos("select * from producto", grillaProductos, productos, datos => new Producto(datos));
            MostrarDatos("select * from categoria", grillaCategorias, categorias, datos => new Categoria(datos));

            RegistrarLog("Inicio de sesión", this.Usuario);
            MostrarDatos("select * from logs", grillaLogs, logs, datos => new Log(datos));
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaCategorias.Rows.Count == 0) throw new Exception("No hay registros de productos para asignar!");
                string nombre = Interaction.InputBox("Ingrese el nombre", "Agregando producto");
                if (nombre.Length == 0) throw new Exception("El nombre está vacio!");
                string inputPrecio = Interaction.InputBox("Ingrese el precio", "Agregando producto");
                if (!decimal.TryParse(inputPrecio, out decimal precio)) throw new Exception("El precio debe ser numérico!");
                var categoria = grillaCategorias.SelectedRows[0].DataBoundItem as Categoria;

                cm.Parameters.Clear();
                cm.Parameters.AddWithValue("@nombre", nombre); cm.Parameters[0].DbType = DbType.String;
                cm.Parameters.AddWithValue("@precio", precio); cm.Parameters[1].DbType = DbType.Decimal;
                cm.Parameters.AddWithValue("@id_categoria", categoria.Id); cm.Parameters[2].DbType = DbType.Int16;

                cm.CommandText = $"insert into producto(nombre,precio,id_categoria) values(@nombre,@precio,@id_categoria)";
                cm.ExecuteNonQuery();
                MostrarDatos("select * from producto", grillaProductos, productos, datos => new Producto(datos));
                RegistrarLog("Agregar producto", this.Usuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaProductos.Rows.Count == 0) throw new Exception("No hay registros de productos");
                cm.CommandText = $"delete from producto where id_producto = {grillaProductos.SelectedRows[0].Cells[0].Value}";
                cm.ExecuteNonQuery();
                MostrarDatos("select * from producto", grillaProductos, productos, datos => new Producto(datos));
                RegistrarLog("Borrar producto", this.Usuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaProductos.Rows.Count == 0) throw new Exception("No hay registros de productos!");
                var rdo = MessageBox.Show("Debe tener seleccionado un registro de la grilla de categorías. ¿Quiere continuar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rdo == DialogResult.Yes)
                {
                    var producto = grillaProductos.SelectedRows[0].DataBoundItem as Producto;
                    var categoria = grillaCategorias.SelectedRows[0].DataBoundItem as Categoria;
                    string nombre = Interaction.InputBox("Ingrese el nombre", "Modificando producto", producto.Nombre);
                    if (nombre.Length == 0) throw new Exception("El nombre está vacio!");
                    string inputPrecio = Interaction.InputBox("Ingrese el precio", "Modificando producto", Convert.ToString(producto.Precio));
                    if (!decimal.TryParse(inputPrecio, out decimal precio)) throw new Exception("El precio debe ser numérico!");

                    cm.Parameters.Clear();
                    cm.Parameters.AddWithValue("@nombre", nombre); cm.Parameters[0].DbType = DbType.String;
                    cm.Parameters.AddWithValue("@precio", precio); cm.Parameters[1].DbType = DbType.Decimal;
                    cm.Parameters.AddWithValue("@id_categoria", categoria.Id); cm.Parameters[2].DbType = DbType.Int16;
                    cm.CommandText = $"update producto set nombre='{nombre}', precio=@precio, id_categoria=@id_categoria where id_producto = {grillaProductos.SelectedRows[0].Cells[0].Value}";
                    cm.ExecuteNonQuery();
                    MostrarDatos("select * from producto", grillaProductos, productos, datos => new Producto(datos));
                    RegistrarLog("Modificar producto", this.Usuario);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = Interaction.InputBox("Ingrese el nombre", "Agregando categoría");
                if (nombre.Length == 0) throw new Exception("El nombre está vacio!");

                cm.Parameters.Clear();
                cm.Parameters.AddWithValue("@nombre", nombre); cm.Parameters[0].DbType = DbType.String;
                cm.CommandText = $"insert into categoria(nombre) values(@nombre)";
                cm.ExecuteNonQuery();
                MostrarDatos("select * from categoria", grillaCategorias, categorias, datos => new Categoria(datos));
                RegistrarLog("Agregar categoría", this.Usuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaCategorias.Rows.Count == 0) throw new Exception("No hay registros de categorías");
                cm.CommandText = $"delete from categoria where id_categoria = {grillaCategorias.SelectedRows[0].Cells[0].Value}";
                cm.ExecuteNonQuery();
                MostrarDatos("select * from categoria", grillaCategorias, categorias, datos => new Categoria(datos));
                RegistrarLog("Borrar categoría", this.Usuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaCategorias.Rows.Count == 0) throw new Exception("No hay registros de categoría!");
                var categoria = grillaCategorias.SelectedRows[0].DataBoundItem as Categoria;
                string nombre = Interaction.InputBox("Ingrese el nombre", "Modificando categoría", categoria.Nombre);
                if (nombre.Length == 0) throw new Exception("El nombre está vacio!");

                cm.Parameters.Clear();
                cm.Parameters.AddWithValue("@nombre", nombre); cm.Parameters[0].DbType = DbType.String;
                cm.CommandText = $"update categoria set nombre='{nombre}' where id_categoria = {grillaCategorias.SelectedRows[0].Cells[0].Value}";
                cm.ExecuteNonQuery();
                MostrarDatos("select * from categoria", grillaCategorias, categorias, datos => new Categoria(datos));
                RegistrarLog("Modificar categoría", this.Usuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            frmLogin login = Application.OpenForms.OfType<frmLogin>().FirstOrDefault();
            RegistrarLog("Cierre de sesión", this.Usuario);
            if (login != null) login.Show();
            this.Close();
        }
    }
}
