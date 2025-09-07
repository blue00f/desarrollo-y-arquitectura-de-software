using Microsoft.VisualBasic;
using System.Data;

namespace Ejercicio3
{
    public partial class Form1 : Form
    {
        DataSet ds;
        DataTable dt;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            grillaJuegos.MultiSelect = false;
            grillaJuegos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grillaJuegos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            ds = new DataSet("juegos");
            if (File.Exists("juegos.xml"))
            {
                ds.ReadXml("juegos.xml");
                dt = ds.Tables[0];
            }
            else
            {
                dt = new DataTable("juego");

                dt.Columns.AddRange(
                [
                    new DataColumn("id", typeof(int)),
                    new DataColumn("nombre", typeof(string)),
                    new DataColumn("lanzamiento", typeof(DateTime)),
                    new DataColumn("esOnline", typeof(bool)),
                    new DataColumn("empresa", typeof(string)),
                    new DataColumn("horasJugadas", typeof(int)),
                ]);
                dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
                ds.Tables.Add(dt);
            }
            grillaJuegos.DataSource = dt.DefaultView;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow row = dt.NewRow();
                row.ItemArray = new object[]
                {
                    Interaction.InputBox("Ingrese el ID", "Juego"),
                    Interaction.InputBox("Ingrese el nombre", "Juego"),
                    Convert.ToDateTime(Interaction.InputBox("Ingrese la fecha de lanzamiento (DD-MM-AAAA)", "Juego")),
                    Convert.ToBoolean(MessageBox.Show("¿Es online?", "Juego", MessageBoxButtons.YesNo)),
                    Interaction.InputBox("Ingrese la empresa desarrolladora", "Juego"),
                    Convert.ToInt16(Interaction.InputBox("Ingrese las horas jugadas", "Juego")),
                };
                dt.Rows.Add(row);
                ds.WriteXml("juegos.xml", XmlWriteMode.WriteSchema);
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
                if (dt.Rows.Count == 0) throw new Exception("No hay juegos para borrar");
                dt.Rows.Remove((grillaJuegos.SelectedRows[0].DataBoundItem as DataRowView).Row);
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
                DataRow row = (grillaJuegos.SelectedRows[0].DataBoundItem as DataRowView).Row;
                row.SetField<string>("nombre", Interaction.InputBox("Ingrese el nombre", "Juego", row.ItemArray[1].ToString()));
                row.SetField<DateTime>("lanzamiento", Convert.ToDateTime(Interaction.InputBox("Ingrese la fecha de lanzamiento (DD-MM-AAAA)", "Juego", row.ItemArray[2].ToString())));
                row.SetField<bool>("esOnline", Convert.ToBoolean(MessageBox.Show("¿Es online?", "Juego", MessageBoxButtons.YesNo)));
                row.SetField<string>("empresa", Interaction.InputBox("Ingrese la empresa desarrolladora", "Juego", row.ItemArray[4].ToString()));
                row.SetField<int>("horasJugadas", Convert.ToInt16(Interaction.InputBox("Ingrese las horas jugadas", "Juego", row.ItemArray[5].ToString())));
                ds.WriteXml("juegos.xml", XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e) => Application.Exit();
    }
}
