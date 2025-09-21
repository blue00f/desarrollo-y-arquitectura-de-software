using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client.RP;
using System.Data;
using System.Windows.Forms;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataAdapter adapter1, adapter2, adapter3, adapter4;
        SqlCommandBuilder builder;
        DataSet ds;
        DataTable dtAlumno, dtMateria, dtAlumnoMateriaCursando, dtAlumnoMateriaCursada;
        DataRelation r1, r2, r3, r4;

        DataView view1, view2, view3;
        public Form1()
        {
            InitializeComponent();
        }

        private void Mostrar(DataGridView pGrilla, object pDatos)
        {
            pGrilla.DataSource = null;
            pGrilla.DataSource = pDatos;
        }

        private void Form1_Load(object sender, EventArgs e)
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
            //Conexion a la base de datos en la PC de la UAI
            //conexion = new SqlConnection("Data Source=.;Initial Catalog=bd_escuela;Integrated Security=True;Trust Server Certificate=True");
            conexion = new SqlConnection("Data Source=127.0.0.1,1433;Initial Catalog=bd_escuela;User ID=administrador;Password=ETN7dolores;Trust Server Certificate=True");
            comando = new SqlCommand();

            adapter1 = new SqlDataAdapter("select * from alumnos", conexion);
            adapter2 = new SqlDataAdapter("select * from materias", conexion);
            adapter3 = new SqlDataAdapter("select * from alumno_materia_cursando", conexion);
            adapter4 = new SqlDataAdapter("select * from alumno_materia_cursada", conexion);

            ds = new DataSet("bd_escuela");
            dtAlumno = new DataTable();
            dtMateria = new DataTable();
            dtAlumnoMateriaCursando = new DataTable();
            dtAlumnoMateriaCursada = new DataTable();

            adapter1.Fill(dtAlumno);
            adapter2.Fill(dtMateria);
            adapter3.Fill(dtAlumnoMateriaCursando);
            adapter4.Fill(dtAlumnoMateriaCursada);

            dtAlumno.PrimaryKey = new DataColumn[] { dtAlumno.Columns[0] };
            dtMateria.PrimaryKey = new DataColumn[] { dtMateria.Columns[0] };
            dtAlumnoMateriaCursando.PrimaryKey = new DataColumn[] { dtAlumnoMateriaCursando.Columns[0], dtAlumnoMateriaCursando.Columns[1] };
            dtAlumnoMateriaCursada.PrimaryKey = new DataColumn[] { dtAlumnoMateriaCursada.Columns[0], dtAlumnoMateriaCursada.Columns[1] };
            ds.Tables.AddRange(new DataTable[] { dtAlumno, dtMateria, dtAlumnoMateriaCursando, dtAlumnoMateriaCursada });

            r1 = new DataRelation("alumno_materia_cursando", ds.Tables[0].Columns[0], ds.Tables[2].Columns[0]);
            r2 = new DataRelation("materia_alumno_cursando", ds.Tables[1].Columns[0], ds.Tables[2].Columns[1]);
            r3 = new DataRelation("alumno_materia_cursada", ds.Tables[0].Columns[0], ds.Tables[3].Columns[0]);
            r4 = new DataRelation("materia_alumno_cursada", ds.Tables[1].Columns[0], ds.Tables[3].Columns[1]);
            ds.Relations.AddRange(new DataRelation[] { r1, r2, r3, r4 });

            Mostrar(grillaAlumnos, ds.Tables[0]);
        }
        private void grillaAlumnos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grillaAlumnos.Rows.Count > 0)
                {
                    var fila = grillaAlumnos.SelectedRows[0].DataBoundItem as DataRowView;
                    var consulta1 = from c in fila.Row.GetChildRows(r1)
                                    select new
                                    {
                                        ID = c.Field<int>(1),
                                        Nombre = c.GetParentRow(r2).Field<string>(1)
                                    };

                    var consulta2 = from c in fila.Row.GetChildRows(r3)
                                    where c.Field<decimal>(2) >= 4
                                    select new
                                    {
                                        ID = c.Field<int>(1),
                                        Nombre = c.GetParentRow(r4).Field<string>(1),
                                        Nota = c.Field<decimal>(2)
                                    };

                    var todas = ds.Tables[1].AsEnumerable();
                    var aprobadas = from c in fila.Row.GetChildRows(r3)
                                    where c.Field<decimal>(2) >= 4
                                    select c.Field<int>(1);

                    var consulta3 = from m in todas
                                    where !aprobadas.Contains(m.Field<int>(0))
                                    select new
                                    {
                                        ID = m.Field<int>(0),
                                        Nombre = m.Field<string>(1)
                                    };

                    var notas = from c in fila.Row.GetChildRows(r3)
                                select c.Field<decimal>(2);

                    if (notas.Any()) txtPromedioAplazo.Text = notas.Average().ToString("0.00");
                    else txtPromedioAplazo.Text = "N/A";

                    var notasSinAplazo = notas.Where(n => n >= 4);
                    if (notasSinAplazo.Any()) txtPromedioSinAplazo.Text = notasSinAplazo.Average().ToString("0.00");
                    else txtPromedioSinAplazo.Text = "N/A";

                    grillaMateriasCursando.DataSource = consulta1.ToList<object>();
                    grillaMateriasAprobadas.DataSource = consulta2.ToList<object>();
                    grillaMateriasPendientes.DataSource = consulta3.ToList<object>();
                }
            }
            catch (Exception) { }
        }

        private void btnGuardarEnXml_Click(object sender, EventArgs e)
        {
            try
            {
                ds.WriteXml("datosEscuela.xml", XmlWriteMode.WriteSchema);
                MessageBox.Show("Archivo XML guardado con éxito!", "Archivo guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
