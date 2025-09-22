using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;

namespace Practica_Parcial_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataSet ds;
        DataTable dtAutos;
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommandBuilder cb;

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
            ds = new DataSet("autos");
            // con = new SqlConnection("Data Source=.;Initial Catalog=bd_autos;Integrated Security=True;Trust Server Certificate=True);
            con = new SqlConnection("Data Source=.;Initial Catalog=bd_autos;User ID=administrador;Password=ETN7dolores;Trust Server Certificate=true");
            da = new SqlDataAdapter("select * from autos", con);
            cb = new SqlCommandBuilder(da);
            da.InsertCommand = cb.GetInsertCommand();
            da.UpdateCommand = cb.GetUpdateCommand();
            da.DeleteCommand = cb.GetDeleteCommand();

            dtAutos = new DataTable();

            da.Fill(dtAutos);
            dtAutos.PrimaryKey = new DataColumn[]
            {
                dtAutos.Columns[0]
            };

            ds.Tables.Add(dtAutos);
            Mostrar(grillaAutos, ds.Tables[0]);
            Mostrar(grillaAutos, ConsultaAutosParaMostrar());
            Mostrar(grillaAutosDadosDeBaja, ConsultaAutosDadosDeBaja());
        }

        private List<object> ConsultaAutosParaMostrar()
        {
            var todosLosCoches = ds.Tables[0].AsEnumerable();
            var consulta = from a in todosLosCoches
                           select new
                           {
                               Patente = a.Field<string>(0),
                               Año = a.Field<int>(3),
                               ValorResidual = Math.Max(0, a.Field<decimal>(5) - (a.Field<decimal>(5) * 0.1m) * (DateTime.Now.Year - a.Field<int>(3))),
                               EnUso = a.Field<bool>(4),
                               Valor = a.Field<decimal>(5),
                               FechaIngreso = a.Field<DateTime>(1),
                               FechaBaja = a.Field<DateTime>(2)
                           };
            return consulta.ToList<object>();
        }
        private List<object> ConsultaAutosDadosDeBaja()
        {
            var todosLosCoches = ds.Tables[0].AsEnumerable();
            var consulta = from a in todosLosCoches
                           where a.Field<bool>(4) == true
                           orderby (a.Field<DateTime>(2) - a.Field<DateTime>(1)).TotalDays ascending
                           select new
                           {
                               Patente = a.Field<string>(0),
                               Dias = (a.Field<DateTime>(2) - a.Field<DateTime>(1)).TotalDays
                           };
            return consulta.ToList<object>();
        }
        private void Mostrar(DataGridView pGrilla, object pDatos)
        {
            pGrilla.DataSource = pDatos;
        }
        private void Funcion_PatenteIncorrecta(object? sender, EventArgs e)
        {
            MessageBox.Show("Patente inválida!", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private bool PatenteExiste(string pPatente)
        {
            bool rdo = false;
            if (ds.Tables[0].Rows.Find(pPatente) != null) rdo = true;
            return rdo;
        }

        private DataRow RecuperarFila()
        {
            string patente = Convert.ToString(grillaAutos.SelectedRows[0].Cells[0].Value);
            var auto = dtAutos.Rows.Find(patente) as DataRow;
            return auto;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaBaja = DateTime.Now;
                string patente = Interaction.InputBox("Patente:", "Auto");
                if (patente.Length == 0) throw new Exception("Patente vacía!");
                if (Auto.ValidarPatente(patente))
                {
                    var tmpAuto = new Auto(patente, DateTime.Now, DateTime.Now, 0, true, 0);
                    tmpAuto.PatenteIncorrecta += Funcion_PatenteIncorrecta;
                    tmpAuto.ValidarPatenteYNotificar();
                    throw new Exception("Patente no cumple con el formato!");
                }
                if (PatenteExiste(patente)) throw new Exception("Patente repetida!");
                DateTime fechaIngreso = Convert.ToDateTime(Interaction.InputBox("Fecha ingreso:", "Auto", DateTime.Now.ToShortDateString()));

                bool enUso = MessageBox.Show("Está en uso?", "Auto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? true : false;
                if (enUso)
                {
                    fechaBaja = Convert.ToDateTime(Interaction.InputBox("Fecha baja:", "Auto", DateTime.Now.ToShortDateString()));
                    if (fechaBaja < fechaIngreso) throw new Exception("Inconsistencia en las fechas de ingreso y baja!");
                }

                string anioInput = Interaction.InputBox("Año:", "Auto");
                if (anioInput.Length != 4) throw new Exception("Año no válido!");
                if (!int.TryParse(anioInput, out int anio)) throw new Exception("Año no es numérico!");

                string valorInput = Interaction.InputBox("Valor:", "Auto");
                if (valorInput.Length == 0) throw new Exception("Valor vacío!");
                if (!decimal.TryParse(valorInput, out decimal valor)) throw new Exception("Valor no es numérico!");

                Auto auto = new Auto(patente, fechaIngreso, fechaBaja, anio, enUso, valor);
                ds.Tables[0].Rows.Add(new object[]
                {
                    auto.Patente,
                    auto.FechaIngreso,
                    auto.FechaBaja,
                    auto.Anio,
                    auto.EnUso,
                    auto.Valor
                });
                da.Update(dtAutos);
                Mostrar(grillaAutos, ConsultaAutosParaMostrar());
                Mostrar(grillaAutosDadosDeBaja, ConsultaAutosDadosDeBaja());
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
                if (grillaAutos.Rows.Count == 0) throw new Exception("No hay autos para borrar!");
                var auto = RecuperarFila();
                auto.Delete();
                da.Update(dtAutos);
                Mostrar(grillaAutos, ConsultaAutosParaMostrar());
                Mostrar(grillaAutosDadosDeBaja, ConsultaAutosDadosDeBaja());
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
                if (grillaAutos.Rows.Count == 0) throw new Exception("No hay autos para modificar!");
                var auto = RecuperarFila();
                DateTime fechaBaja = auto.Field<DateTime>(2);
                string patente = Interaction.InputBox("Patente:", "Auto", auto.Field<string>(0));

                bool enUso = MessageBox.Show("Está en uso?", "Auto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, auto.Field<bool>(4) ? MessageBoxDefaultButton.Button1 : MessageBoxDefaultButton.Button2) == DialogResult.Yes ? true : false;
                DateTime fechaIngreso = Convert.ToDateTime(Interaction.InputBox("Fecha ingreso:", "Auto", auto.Field<DateTime>(1).ToShortDateString()));
                if (enUso)
                {
                    fechaBaja = Convert.ToDateTime(Interaction.InputBox("Fecha baja:", "Auto", auto.Field<DateTime>(2).ToShortDateString()));
                    if (fechaBaja < fechaIngreso) throw new Exception("Inconsistencia en las fechas de ingreso y baja!");
                }

                string anioInput = Interaction.InputBox("Año:", "Auto", auto.Field<int>(3).ToString());
                if (anioInput.Length != 4) throw new Exception("Año no válido!");
                if (!int.TryParse(anioInput, out int anio)) throw new Exception("Año no es numérico!");

                string valorInput = Interaction.InputBox("Valor:", "Auto", auto.Field<decimal>(5).ToString());
                if (valorInput.Length == 0) throw new Exception("Valor vacío!");
                if (!decimal.TryParse(valorInput, out decimal valor)) throw new Exception("Valor no es numérico!");

                auto.ItemArray = new object[]
                {
                    patente,
                    fechaIngreso,
                    fechaBaja,
                    anio,
                    enUso,
                    valor
                };
                da.Update(dtAutos);
                Mostrar(grillaAutos, ConsultaAutosParaMostrar());
                Mostrar(grillaAutosDadosDeBaja, ConsultaAutosDadosDeBaja());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtConsultaIncrementalPatente_TextChanged(object sender, EventArgs e)
        {
            DataView dv = ds.Tables[0].AsDataView();
            dv.RowFilter = $"patente like '{txtConsultaIncrementalPatente.Text}%'";
            Mostrar(grillaAutosIncremental, dv);
        }

        private void btnGuardarEnXml_Click(object sender, EventArgs e)
        {
            try
            {
                ds.WriteXml("autos.xml", XmlWriteMode.WriteSchema);
                MessageBox.Show("Guardado exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
