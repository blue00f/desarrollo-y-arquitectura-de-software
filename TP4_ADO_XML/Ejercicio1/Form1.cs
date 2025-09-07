using System.Data;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        DataSet ds;
        DataTable dtReservas;
        DataTable dtItems;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var control in Controls)
            {
                if(control is DataGridView pGrilla)
                {
                    pGrilla.MultiSelect = false;
                    pGrilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    pGrilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }

            ds = new DataSet("reservas");
            if (File.Exists("reservas.xml"))
            {
                ds.ReadXml("reservas.xml");
                dtReservas = ds.Tables["reserva"];
                dtItems = ds.Tables["item"];
            }
            else
            {
                dtReservas = new DataTable("reserva");
                dtItems.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn("numero", typeof(int)),
                    new DataColumn("sucursal", typeof(string)),
                    new DataColumn("fecha", typeof(DateTime)),
                    new DataColumn("cliente", typeof(string))
                });

                dtItems = new DataTable("item");
                dtItems.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn("descripcion", typeof(string)),
                    new DataColumn("precioUnitario", typeof(decimal)),
                    new DataColumn("cantidad", typeof(int)),
                    new DataColumn("descuento", typeof(decimal))
                });

                ds.Tables.Add(dtReservas);
                ds.Tables.Add(dtItems);
            }
            grillaReservas.DataSource = null;
            grillaReservas.DataSource = dtReservas.DefaultView;
            grillaItems.DataSource = null;
            grillaItems.DataSource = dtItems.DefaultView;
        }

        private void grillaReservas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (grillaReservas.CurrentRow != null)
            {
                int numeroReserva = Convert.ToInt32(grillaReservas.SelectedRows[0].Cells[1].Value);
                DataView dvItems = new DataView(dtItems);
                dvItems.RowFilter = $"reserva_numero = {numeroReserva}";
                grillaItems.DataSource = dvItems;
            }
        }
    }
}
