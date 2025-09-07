using System.Data;

namespace Ejercicio2
{
    public partial class Form1 : Form
    {
        DataSet ds;
        DataTable dtPreguntas;
        DataTable dtOpciones;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var control in Controls)
            {
                if (control is DataGridView pGrilla)
                {
                    pGrilla.MultiSelect = false;
                    pGrilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    pGrilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }

            ds = new DataSet("preguntas");

            if (File.Exists("preguntados.xml"))
            {
                ds.ReadXml("preguntados.xml");
                dtPreguntas = ds.Tables[0];
                dtOpciones = ds.Tables[1];
            }
            else
            {
                dtPreguntas = new DataTable("pregunta");
                dtPreguntas.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn("categoria", typeof(string)),
                    new DataColumn("texto", typeof(string)),
                    new DataColumn("opcion", typeof(string)),
                    new DataColumn("correcta", typeof(bool))
                });

                dtOpciones = new DataTable("opcion");
                dtOpciones.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn("descripcion", typeof(string)),
                    new DataColumn("correcta", typeof(bool))
                });
                ds.Tables.Add(dtPreguntas);
                ds.Tables.Add(dtOpciones);
            }
            grillaPreguntas.DataSource = null;
            grillaPreguntas.DataSource = dtPreguntas.DefaultView;
            grillaOpciones.DataSource = null;
            grillaOpciones.DataSource = dtOpciones.DefaultView;
        }

        private void grillaPreguntas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (grillaPreguntas.CurrentRow != null)
            {
                var fila = (grillaPreguntas.SelectedRows[0].DataBoundItem as DataRowView).Row;
                DataRow[] opcionesRelacionadas;
                if (ds.Relations.Count > 0) opcionesRelacionadas = fila.GetChildRows(ds.Relations[0].RelationName);
                else opcionesRelacionadas = new DataRow[0];

                DataTable dtTemp = opcionesRelacionadas.Length > 0 ? opcionesRelacionadas.CopyToDataTable() : dtOpciones.Clone();
                grillaOpciones.DataSource = null;
                grillaOpciones.DataSource = dtTemp.DefaultView;
            }
        }
    }
}
