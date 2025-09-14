using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Data;
using System.Drawing;

namespace ADO_Desconectado_2
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlDataAdapter ad, ad1, ad2;
        SqlCommandBuilder cb;
        DataView dv, dv1;
        DataSet ds;
        DataTable dtAlumno, dtContacto, dtTipoContacto;
        DataRelation r1, r2;
        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection("Data Source=127.0.0.1,1433;Initial Catalog=DASW_2025_2B_TM;User ID=administrador;Password='ETN7dolores';Trust Server Certificate=True");
            ad = new SqlDataAdapter("Select * from Alumno", con);
            cb = new SqlCommandBuilder(ad);
            ad.InsertCommand = cb.GetInsertCommand();
            ad.DeleteCommand = cb.GetDeleteCommand();
            ad.UpdateCommand = cb.GetUpdateCommand();

            ad1 = new SqlDataAdapter("Select * from Contacto", con);
            ad2 = new SqlDataAdapter("Select * from TipoContacto", con);
            ds = new DataSet("DASW_2025_2B_TM");
            dtAlumno = new DataTable();
            dtContacto = new DataTable();
            dtTipoContacto = new DataTable();
        }
        private void Mostrar(DataGridView pDGV, object pDT)
        {
            pDGV.DataSource = null;
            pDGV.DataSource = pDT;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ad.Fill(dtAlumno);
            ad1.Fill(dtContacto);
            ad2.Fill(dtTipoContacto);

            dtAlumno.PrimaryKey = new DataColumn[] { dtAlumno.Columns[0] };
            dtContacto.PrimaryKey = new DataColumn[] { dtContacto.Columns[0] };
            dtTipoContacto.PrimaryKey = new DataColumn[] { dtTipoContacto.Columns[0] };

            ds.Tables.AddRange(new DataTable[] { dtAlumno, dtContacto, dtTipoContacto });
            r1 = new DataRelation("Alumno_Contacto", ds.Tables[0].Columns[0], ds.Tables[1].Columns[2]);
            r2 = new DataRelation("Contacto_TipoContacto", ds.Tables[2].Columns[0], ds.Tables[1].Columns[3]);
            ds.Relations.AddRange(new DataRelation[] { r1, r2 });

            foreach (var control in Controls)
            {
                if (control is DataGridView grilla)
                {
                    grilla.MultiSelect = false;
                    grilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }

            dv = new DataView(ds.Tables[0], "", "", DataViewRowState.Deleted);
            dv1 = new DataView(ds.Tables[0], $"Nombre Like '{textBox1}%'", "", DataViewRowState.CurrentRows);

            Mostrar(dataGridView1, ds.Tables[0]);
            Mostrar(dataGridView2, dv);
            Mostrar(dataGridView3, dv1);
            radioButton2.Click += ActualizaDV; radioButton3.Click += ActualizaDV;
        }
        private bool LegajoExiste(object pLegajo)
        {
            return ds.Tables[0].Rows.Find(pLegajo) == null ? false : true;
        }

        private static string CargaFecha(string titulo = "", string rta = "")
        {
            string fecha = Interaction.InputBox("Fecha de ingreso: ", titulo, rta);
            if (!Information.IsDate(fecha)) throw new Exception("Fecha inválida !!!");
            if (Convert.ToDateTime(fecha).Date < Convert.ToDateTime("2/1/1997").Date || Convert.ToDateTime(fecha).Date > DateTime.Now.Date) throw new Exception("Fecha Inválida !!!");
            return fecha;
        }

        private static void CargaNombre_Apellido(out string nombre, out string apellido, string titulo1 = "", string rta1 = "", string titulo2 = "", string rta2 = "")
        {
            nombre = Interaction.InputBox("Nombre: ", titulo1, rta1);
            apellido = Interaction.InputBox("Apellido: ", titulo2, rta2);
        }

        private void ActualizaBD()
        {
            ad.Update(dtAlumno);
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
                //ActualizaBD();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                RecuperarFilaSeleccionadaEnDataGridView().Delete();
                //ActualizaBD();
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
                var activo = MessageBox.Show("¿Activo? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, dr.Field<bool>(4) ? MessageBoxDefaultButton.Button1 : MessageBoxDefaultButton.Button2) == DialogResult.Yes ? true : false;
                dr.ItemArray = new object[] { dr.Field<int>(0), nombre, apellido, fecha, activo };
                //ActualizaBD();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ActualizaBD();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ds.Tables[0].RejectChanges();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dv1.RowFilter = $"Nombre Like '{textBox1.Text}%'";
            dv1.Sort = "Nombre desc";
            //Mostrar(dataGridView3, dv1);
        }

        private void ActualizaDV(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Name == "radioButton1") dv.RowStateFilter = DataViewRowState.Deleted;
            else if ((sender as RadioButton).Name == "radioButton2") dv.RowStateFilter = DataViewRowState.Added;
            else dv.RowStateFilter = DataViewRowState.ModifiedOriginal;
        }
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    //Obtengo un DataTable
                    //var dtAux = (dataGridView1.SelectedRows[0].DataBoundItem as DataRowView).Row.GetChildRows(r1).CopyToDataTable();
                    //if (dtAux.Rows.Count > 0) dataGridView4.DataSource = dtAux;
                    //Obtengo un Lista con los contactos
                    var lq = (from c in (dataGridView1.SelectedRows[0].DataBoundItem as DataRowView).Row.GetChildRows(r1)
                              select new { Contacto = c.Field<string>(1), DataRowOrigen = c }).ToList<object>();
                    if (lq.Count > 0)
                    {
                        dataGridView4.DataSource = lq;
                        dataGridView4.Columns[1].Visible = false;
                        dataGridView4.Columns[0].Width = 350;
                        dataGridView4_RowEnter(null, null);
                    }
                }
            }
            catch (Exception)
            {
                dataGridView4.DataSource = null;
            }
        }

        private void dataGridView4_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView4.Rows.Count > 0)
                {
                    var dr = (dataGridView4.SelectedRows[0].Cells[1].Value as DataRow).GetParentRow(r2);
                    textBox2.Text = dr.Field<string>(1);
                }
                else textBox2.Clear();
            }
            catch (Exception)
            {
                textBox2.Clear();
            }
        }
    }
}
