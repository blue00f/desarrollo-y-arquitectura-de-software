using Microsoft.VisualBasic;
using System.Data;
using System.Windows.Forms;

namespace ADO_XML_Nuevo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Declarmos una variable de tipo DataSet y otra DataTable
        DataSet ds;
        DataTable dt;
        RadioButton r1;
        RadioButton r2;
        RadioButton r3;
        string campo = "DNI";
        private void Form1_Load(object sender, EventArgs e)
        {
            //Configuramos la Grilla
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            //Creamos el DataSet
            ds = new DataSet("Gestion");
            // Si el archivo Datos.xml existe lo abro
            if (File.Exists("Datos.xml"))
            {
                ds.ReadXml("Datos.xml");
                dt = ds.Tables[0];
            }
            else // Si no existe el archivo creo un DataTable y lo configuro
            {
                //Creo un DataTable llamado Persona
                dt = new DataTable("Persona");
                //Le agregamos al dt Persona tres DataColumn (DNI,Nombre,Apellido)
                dt.Columns.AddRange(new DataColumn[] {new DataColumn("DNI",typeof(string)),
                                                      new DataColumn("Nombre",typeof(string)),
                                                      new DataColumn("Apellido",typeof(string))});
                //Con esta instrucción también puedo obtener un objeto de tipo Type pero pasando el tipo como un string (Qualify Name o Full Name del tipo)
                //Type tipo = Type.GetType("System.String");
                //Otra forma es:
                //string s = "";
                //var t = s.GetType();

                dt.PrimaryKey = new DataColumn[] { dt.Columns["DNI"] };
                ds.Tables.Add(dt);
            }
            //DataView dv1 = new DataView(dt,"","",DataViewRowState.Deleted);
            dataGridView1.DataSource = dt.DefaultView;

            foreach (DataGridViewColumn x in dataGridView1.Columns) { x.Width = 180; }
            r1 = new RadioButton(); r1.Location = new Point(440, 25); r1.Name = "r1"; r1.Checked = true; r1.Tag = "DNI";
            r2 = new RadioButton(); r2.Location = new Point(630, 25); r2.Name = "r2"; r2.Tag = "Nombre";
            r3 = new RadioButton(); r3.Location = new Point(800, 25); r3.Name = "r3"; r3.Tag = "Apellido";

            r1.Click += SeleccionaCampo; r2.Click += SeleccionaCampo; r3.Click += SeleccionaCampo;
            Controls.AddRange(new Control[] { r1, r2, r3 });
        }
        private void SeleccionaCampo(object sender, EventArgs e)
        {
            campo = (sender as RadioButton).Tag.ToString();
            textBox4_TextChanged(null, null);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Creamos un DataRow para el DataTable Persona
                DataRow dr = dt.NewRow();

                //Cargamos los datos que nos suministra el usuario al los Items del DataRow
                dr.ItemArray = new object[] { Interaction.InputBox("DNI: "),
                                              Interaction.InputBox("Nombre: "),
                                              Interaction.InputBox("Apellido: ") };
                //Agregamos el DataRow a la colección de Rows del DataTable
                dt.Rows.Add(dr);
                //LLamamos a la función Guardar que es la encargada de grabar todos los datos del DataSet en el documento Datos.xml
                Guardar();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void Guardar()
        {
            ds.WriteXml("Datos.xml", XmlWriteMode.WriteSchema);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dt.Rows.Count > 0) { dt.Rows.Remove((dataGridView1.SelectedRows[0].DataBoundItem as DataRowView).Row); }
                Guardar();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //Tomamos el DataRow que vamos a modificar
                DataRow dr = (dataGridView1.SelectedRows[0].DataBoundItem as DataRowView).Row;
                //string _nombre = Interaction.InputBox("Nombre: ", "", dr.ItemArray[1].ToString());
                //string _apellido = Interaction.InputBox("Apellido: ", "", dr.ItemArray[2].ToString());
                //dr.ItemArray = new object[] { dr.ItemArray[0].ToString(), _nombre, _apellido };
                dr.SetField<string>("Nombre", Interaction.InputBox("Nombre: ", "", dr.ItemArray[1].ToString()));
                dr.SetField<string>("Apellido", Interaction.InputBox("Apllido: ", "", dr.ItemArray[2].ToString()));
                Guardar();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Text = $"X: {e.X} -- Y: {e.Y}";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string query = "";
            if (textBox4.Text != "") query = $"{campo} = '{textBox4.Text}'";
            dt.DefaultView.RowFilter = query;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = $"{campo} Like '{textBox1.Text}%'";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "") dt.DefaultView.RowFilter = $"{campo} >='{textBox2.Text}' and {campo} <='{textBox3.Text}'";

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox2_TextChanged(null, null);
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            var criterio = "asc";
            if (radioButton2.Checked) criterio = "desc";
            dt.DefaultView.Sort = $"{campo} {criterio}";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1_CheckedChanged(null,null);
        }
    }
}
