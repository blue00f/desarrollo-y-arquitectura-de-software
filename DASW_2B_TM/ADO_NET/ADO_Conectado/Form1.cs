using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Runtime.InteropServices.ObjectiveC;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ADO_Conectado
{
    public partial class Form1 : Form
    {
     
        SqlConnection cx;
        SqlCommand cm;
        List<Alumno> la;
        public Form1()
        {
            InitializeComponent();
        }
        private void estadoCX(object sender, StateChangeEventArgs e)
        {
            if (e.CurrentState == ConnectionState.Open) { BackColor = Color.Green; }
            else { BackColor = Color.Red; }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            la = new List<Alumno>();
            cx = new SqlConnection("Data Source=10.37.129.2,1433;Initial Catalog=DASW_2025_2B_TM;User ID=sa;Password='MiClave@2024';Trust Server Certificate=True");
            //cx = new SqlConnection();
            //cx.ConnectionString = "Data Source=10.37.129.2,1433;Initial Catalog=DASW_2025_2A_TT;User ID=sa;Password='MiClave@2024';Trust Server Certificate=True";
            cx.StateChange += estadoCX;
            cm = new SqlCommand("Select * from Alumno", cx);
            //cm = new SqlCommand();
            //cm.Connection = cx;
            //cm.CommandType = CommandType.Text;
            //cm.CommandText = "Select * from Alumno";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (cx.State == ConnectionState.Closed) { cx.Open(); MostrarDatos("Select * from Alumno"); }
        }
        private void MostrarDatos(string pCommandText)
        {
            CargarDatos(pCommandText);
            dataGridView1.DataSource = null; dataGridView1.DataSource = la;
        }
        private void CargarDatos(string pCommandText)
        {
            cm.CommandText = pCommandText;
            la.Clear();

            using (SqlDataReader dr = cm.ExecuteReader()) 
            {
                while (dr.Read())
                {
                    object[] datos = new object[dr.FieldCount];
                    dr.GetValues(datos);
                    la.Add(new Alumno(datos));
                }
            }
            // Si no usamos using debemos cerrar el SqlDataReader
            //dr.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            cx.Close();
            dataGridView1.DataSource = null;
            la.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string legajo = Interaction.InputBox("Legajo: ");
            //Todo: Verificar que hayan ingresado un número
            //Todo: Que no sea null
            //Todo: Verificar que el legajo no existe
            string nombre = Interaction.InputBox("Nombre: ");
            string apellido = Interaction.InputBox("Apellido: ");
            string fechaIng = Interaction.InputBox("Fecha de Ingreso: ");
            //Todo: Verificar que es un fecha válida
            var activo = MessageBox.Show("¿Activo? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? true : false;
            //creaci'on y configuraci'on de los par'am,etros a usar en el insert
            cm.Parameters.Add("@legajo",SqlDbType.Int);
            cm.Parameters[0].Value = Convert.ToInt32(legajo);
            cm.Parameters.Add("@nombre", SqlDbType.NVarChar);
            cm.Parameters[1].Value = nombre;
            cm.Parameters.Add("@apellido", SqlDbType.NVarChar);
            cm.Parameters[2].Value = apellido;
            cm.Parameters.Add("@ingreso", SqlDbType.Date);
            cm.Parameters[3].Value = fechaIng;   
            cm.Parameters.Add("@activo", SqlDbType.Bit);
            cm.Parameters[4].Value = activo;
            cm.CommandText = $"Insert Into Alumno (Legajo, Nombre, Apellido, Ingreso, Activo) values (@legajo,@nombre,@apellido,@ingreso,@activo)";
            cm.ExecuteNonQuery();
            MostrarDatos("Select * from Alumno");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                cm.CommandText = $"delete from Alumno where Legajo = {dataGridView1.SelectedRows[0].Cells[0].Value}";
                //Todo: confirmar que se desea borrar
                cm.ExecuteNonQuery();
                MostrarDatos("Select * from Alumno");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string nombre = Interaction.InputBox("Nombre: ", "Modificando Nombre...", dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            string apellido = Interaction.InputBox("Apellido: ", "Modificando Apellido...", dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            string fechaIng = Interaction.InputBox("Fecha de Ingreso: ", "Modificando Fecha de Ingreso...", Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[3].Value).ToShortDateString());
            //Todo: Verificar que es un fecha válida
            var activo = MessageBox.Show("¿Activo? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[4].Value) ? MessageBoxDefaultButton.Button1 : MessageBoxDefaultButton.Button2) == DialogResult.Yes ? true : false;
            cm.Parameters.AddWithValue("@ingreso", fechaIng);
            cm.Parameters[0].DbType = DbType.Date;
            cm.CommandText = $"Update Alumno set Nombre='{nombre}', Apellido='{apellido}', Ingreso = @ingreso ,Activo = '{activo}' where Legajo={dataGridView1.SelectedRows[0].Cells[0].Value}";
            cm.ExecuteNonQuery();
            MostrarDatos("Select * from Alumno");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MostrarDatos($"Select * from Alumno where Nombre like '{textBox1.Text}%'");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Todo verificar que en las cajas de texto 2 y 3 haya números
            MostrarDatos($"Select * from Alumno where legajo between {textBox2.Text} and {textBox3.Text}");

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string legajo = Interaction.InputBox("Legajo: ");
            //Todo: Verificar que hayan ingresado un número
            //Todo: Verificar que el legajo no existe
            string nombre = Interaction.InputBox("Nombre: ");
            string apellido = Interaction.InputBox("Apellido: ");
            string fechaIng = Interaction.InputBox("Fecha de Ingreso: ");
            //Todo: Verificar que es un fecha válida
            var activo = MessageBox.Show("¿Activo? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? true : false;
            var cm2 = new SqlCommand();
            cm2.Connection = cx;
            cm2.CommandType = CommandType.StoredProcedure;
            cm2.CommandText = "sp_Alumno_Insertar";
            cm2.Parameters.AddWithValue("@Legajo", legajo); cm2.Parameters[0].DbType = DbType.Int32;
            cm2.Parameters.AddWithValue("@Nombre", nombre); cm2.Parameters[1].DbType = DbType.String;
            cm2.Parameters.AddWithValue("@Apellido", apellido); cm2.Parameters[2].DbType = DbType.String;
            cm2.Parameters.AddWithValue("@Ingreso", fechaIng); cm2.Parameters[3].DbType = DbType.Date;
            cm2.Parameters.AddWithValue("@Activo", activo); cm2.Parameters[4].DbType = DbType.Boolean;

            cm2.ExecuteNonQuery();
            MostrarDatos("Select * from Alumno");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                var cm2 = new SqlCommand();
                cm2.Connection = cx;
                cm2.CommandType = CommandType.StoredProcedure;
                cm2.CommandText = "sp_Alumno_Eliminar";
                cm2.Parameters.AddWithValue("@Legajo", dataGridView1.SelectedRows[0].Cells[0].Value);
                //Todo: confirmar que se desea borrar
                cm2.ExecuteNonQuery();
                MostrarDatos("Select * from Alumno");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string nombre = Interaction.InputBox("Nombre: ", "Modificando Nombre...", dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            string apellido = Interaction.InputBox("Apellido: ", "Modificando Apellido...", dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            string fechaIng = Interaction.InputBox("Fecha de Ingreso: ", "Modificando Fecha de Ingreso...", Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[3].Value).ToShortDateString());
            //Todo: Verificar que es un fecha válida
            var activo = MessageBox.Show("¿Activo? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[4].Value) ? MessageBoxDefaultButton.Button1 : MessageBoxDefaultButton.Button2) == DialogResult.Yes ? true : false;
            var cm2 = new SqlCommand();
            cm2.Connection = cx;
            cm2.CommandType = CommandType.StoredProcedure;
            cm2.CommandText = "sp_Alumno_Actualizar";
            cm2.Parameters.AddWithValue("@Legajo", dataGridView1.SelectedRows[0].Cells[0].Value);
            cm2.Parameters.AddWithValue("@Nombre", nombre);
            cm2.Parameters.AddWithValue("@Apellido", apellido);
            cm2.Parameters.AddWithValue("@Ingreso", fechaIng); cm2.Parameters[3].DbType = DbType.Date;
            cm2.Parameters.AddWithValue("@Activo", activo);
            cm2.ExecuteNonQuery();
            MostrarDatos("Select * from Alumno");
        }
    }
}