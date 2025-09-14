using System.Data;
using Microsoft.VisualBasic;
using System.Data.SqlClient;

namespace ADO_Desconectado
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlDataAdapter ad;
        SqlCommandBuilder cb;
        DataSet ds;
        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection("Data Source=10.37.129.2,1433;Initial Catalog=DASW_2025_2B_TM;User ID=sa;Password='MiClave@2024'");
            ad = new SqlDataAdapter("Select * from Alumno", con);
            cb = new SqlCommandBuilder(ad);
            ad.InsertCommand = cb.GetInsertCommand();
            ad.DeleteCommand = cb.GetDeleteCommand();
            ad.UpdateCommand = cb.GetUpdateCommand();
            ds = new DataSet("DAS_2024_2A_TM");

        }
        private void Mostrar(DataGridView pDGV, DataTable pDT)
        {
            pDGV.DataSource = null;
            pDGV.DataSource = pDT;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ad.Fill(ds);
            ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns[0] };
            Mostrar(dataGridView1, ds.Tables[0]);
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }
        private bool LegajoExiste(object pLegajo)
        {
            return ds.Tables[0].Rows.Find(pLegajo) == null ? false : true;
        }
        private DataRow RecuperarFilaSeleccionadaEnDataGridView()
        {
            ExisteFilaEnDataGridView();
            return (dataGridView1.SelectedRows[0].DataBoundItem as DataRowView).Row;
        }
        private void ExisteFilaEnDataGridView()
        {
            if (dataGridView1.Rows.Count == 0) throw new Exception("No hay nada para borrar !!!");
        }
        private static string CargaFecha(string titulo = "", string rta = "")
        {
            string fecha = Interaction.InputBox("Fecha de ingreso: ", titulo, rta);
            if (!Information.IsDate(fecha)) throw new Exception("Fecha inválida !!!");
            if (Convert.ToDateTime(fecha).Date < Convert.ToDateTime("2/1/1997").Date || Convert.ToDateTime(fecha).Date > DateTime.Now.Date) throw new Exception("Fecha Inválida !!!");
            return fecha;
        }
        private static void CargaNombre_Apellido(out string pNombre, out string pApellido, string titulo1 = "", string rta1 = "", string titulo2 = "", string rta2 = "")
        {
            pNombre = Interaction.InputBox("Nombre: ", titulo1, rta1);
            pApellido = Interaction.InputBox("Apellido: ", titulo2, rta2);
        }
        private void ActualizaBD()
        {
            ad.Update(ds);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string legajo = Interaction.InputBox("Legajo: ");
                if (!Information.IsNumeric(legajo)) throw new Exception("El legajo debe ser numérico !!!");
                if (LegajoExiste(legajo)) throw new Exception("El legajo ya existe !!!");
                if (Convert.ToInt16(legajo) < 1) throw new Exception("El legajo debe ser positivo y mayor a 0 !!!");
                string nombre, apellido;
                CargaNombre_Apellido(out nombre, out apellido);
                string fecha = CargaFecha();
                var activo = MessageBox.Show("¿Activo? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? true : false;

                ds.Tables[0].Rows.Add(new object[] { legajo, nombre, apellido, fecha, activo });
                ActualizaBD();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                RecuperarFilaSeleccionadaEnDataGridView().Delete();
                ActualizaBD();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                ExisteFilaEnDataGridView();
                DataRow dr = RecuperarFilaSeleccionadaEnDataGridView();
                string nombre, apellido;
                CargaNombre_Apellido(out nombre, out apellido, "Modificando Nombre !!!", dr.Field<string>(1), "Modificando Apellido !!!", dr.Field<string>(2));
                string fecha = CargaFecha("Modificando Fecha !!!", dr.Field<DateTime>(3).ToShortDateString());
                var activo = MessageBox.Show("¿Activo? ", "Modificando Activo...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, dr.Field<bool>(4) ? MessageBoxDefaultButton.Button1 : MessageBoxDefaultButton.Button2) == DialogResult.Yes ? true : false;

                dr.ItemArray = new object[] { dr.Field<int>(0), nombre, apellido, fecha, activo };
                ActualizaBD();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
