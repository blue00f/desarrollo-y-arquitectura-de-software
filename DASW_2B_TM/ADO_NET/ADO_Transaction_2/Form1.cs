using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System;
using System.Data;

namespace ADO_Transaction
{
    public partial class Form1 : Form
    {
        SqlConnection cx;
        SqlCommand cm;
        List<Alumno> la;
        SqlTransaction tr;
        public Form1()
        {
            InitializeComponent();
        }
        private void CrearTransaction()
        {
            tr = cx.BeginTransaction();
            cm.Transaction = tr;
        }
        private void CerrarTransaction() => tr = null;
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string legajo = Interaction.InputBox("Legajo: ");
                if (!Information.IsNumeric(legajo) || legajo is null) throw new Exception("El legajo debe ser numérico !!!");
                //Verificamos que el legajo que ingresamos no exista en la base de datos.
                cm.Parameters[0].Value = Convert.ToInt32(legajo);
                cm.CommandText = $"Select * from Alumno Where legajo = @legajo";
                Conectar();
                using (SqlDataReader dr = cm.ExecuteReader())
                {
                    if (dr.Read()) throw new Exception("El legajo ya existe !!!");
                }
                Desconectar();
                string nombre = Interaction.InputBox("Nombre: ");
                string apellido = Interaction.InputBox("Apellido: ");
                string fechaIng = Interaction.InputBox("Fecha de Ingreso: ");
                if (!Information.IsDate(fechaIng)) throw new Exception("La fecha es inválida !!!");
                var activo = MessageBox.Show("¿Activo? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? true : false;
                //creación y configuración de los parámétros a usar en el insert  
                cm.Parameters[1].Value = nombre;
                cm.Parameters[2].Value = apellido;
                cm.Parameters[3].Value = fechaIng;
                cm.Parameters[4].Value = activo;
                cm.CommandText = $"Insert Into Alumno (Legajo, Nombre, Apellido, Ingreso, Activo) values (@legajo,@nombre,@apellido,@ingreso,@activo)";
                Conectar();
                CrearTransaction();
                cm.ExecuteNonQuery();
                //Si se comenta la siguiente línea data un error por intentare
                //Dar de alta dos registros con la misma clave.
                cm.Parameters[0].Value = Convert.ToInt16(cm.Parameters[0].Value) + 1;
                cm.ExecuteNonQuery();
                tr.Commit();
                MostrarDatos("Select * from Alumno");
                Desconectar();
                CerrarTransaction();
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message);           
                if (tr!=null) tr.Rollback();
                Desconectar();
            }
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
            cx.StateChange += estadoCX;
            cm = new SqlCommand();
            cm.Connection = cx;
            cm.Parameters.Add("@legajo", SqlDbType.Int); cm.Parameters[0].Value = 0;
            cm.Parameters.Add("@nombre", SqlDbType.NVarChar);cm.Parameters[1].Value = "";
            cm.Parameters.Add("@apellido", SqlDbType.NVarChar); cm.Parameters[2].Value = "";
            cm.Parameters.Add("@ingreso", SqlDbType.Date);cm.Parameters[3].Value =DateTime.Now;
            cm.Parameters.Add("@activo", SqlDbType.Bit);cm.Parameters[4].Value = 0; 
            MostrarDatos("Select * from Alumno");
        }
        private void MostrarDatos(string pCommandText)
        {
            Conectar();
            CargarDatos(pCommandText);
            dataGridView1.DataSource = null; dataGridView1.DataSource = la;
            Desconectar();
        }
        private void Desconectar()
        {
            cx.Close();
        }

        private void Conectar()
        {
            if (cx.State == ConnectionState.Closed) cx.Open();
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
        }
    }
}
