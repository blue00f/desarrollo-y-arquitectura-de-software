using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.IO;


namespace ADO_Desconectado
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataSet ds;
        DataTable dt;

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            ds = new DataSet("Gestion");

            if (File.Exists("Datos.xml"))
            {
                ds.ReadXml("Datos.xml");
                dt = ds.Tables[0];
            }
            else
            {
                //Creo un DataTable llamado Persona
                dt = new DataTable("Persona");
                //Le agregamos al dt Persona tres DataColumn (DNI,Nombre,Apellido)
                dt.Columns.AddRange(new DataColumn[] {new DataColumn("DNI",typeof(string)),
                                                      new DataColumn("Nombre",typeof(string)),
                                                      new DataColumn("Apellido",typeof(string))});
                dt.PrimaryKey = new DataColumn[] { dt.Columns["DNI"] };
                ds.Tables.Add(dt);
            }
            //DataView dv1 = new DataView(dt,"","",DataViewRowState.Deleted);
            dataGridView1.DataSource = dt.DefaultView;
            foreach (DataGridViewColumn x in dataGridView1.Columns) { x.Width = 180; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Creamos un DataRow para el DataTable Persona
                DataRow dr = dt.NewRow();
                //Cargamos los datos que nos suministra el usuario al los Items del DataRow
                dr.ItemArray = new object[] { Interaction.InputBox("DNI: "), Interaction.InputBox("Nombre: "), Interaction.InputBox("Apellido: ") };
                //Agregamos el DataRow a la colección de Rows del DataTable
                dt.Rows.Add(dr);
                //LLamamos a la función Guardar que es la encargada de grabar todos los datos del DataSet en el documento Datos.xml
                Guardar();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dt.Rows.Count > 0) { dt.Rows.Remove((dataGridView1.SelectedRows[0].DataBoundItem as DataRowView).Row); }
                Guardar();
            
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //Tomamos el DataRow que vamos a modificar
                DataRow dr = (dataGridView1.SelectedRows[0].DataBoundItem as DataRowView).Row;
                string _nombre =  Interaction.InputBox("Nombre: ","", dr.ItemArray[1].ToString());
                string _apellido = Interaction.InputBox("Apellido: ", "", dr.ItemArray[2].ToString());
                dr.ItemArray = new object[] { dr.ItemArray[0].ToString(),_nombre,_apellido };
                Guardar();
               
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Guardar()
        {
            ds.WriteXml("Datos.xml", XmlWriteMode.WriteSchema);
        }
    }
}
