using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System.CodeDom;
using System.Data;

namespace GestionEquipos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommandBuilder cb;
        DataSet ds;
        DataTable dtEquipos;

        private void Form1_Load(object sender, EventArgs e)
        {
            Equipo.PatenteIncorrecta += Funcion_PatenteIncorrecta;
            foreach (var control in Controls)
            {
                if (control is DataGridView grilla)
                {
                    grilla.MultiSelect = false;
                    grilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            con = new SqlConnection("Data Source=.;Initial Catalog=bd_equipos;Integrated Security=true;Trust Server Certificate=true");
            da = new SqlDataAdapter("select * from equipos", con);
            cb = new SqlCommandBuilder(da);
            da.InsertCommand = cb.GetInsertCommand();
            da.UpdateCommand = cb.GetUpdateCommand();
            da.DeleteCommand = cb.GetDeleteCommand();

            ds = new DataSet("equipos");
            dtEquipos = new DataTable();

            da.Fill(dtEquipos);
            dtEquipos.PrimaryKey = new DataColumn[]
            {
                dtEquipos.Columns[0]
            };
            ds.Tables.Add(dtEquipos);
            Mostrar(grillaEquipos, ConsultaEquipos());
            Mostrar(grillaEquiposDadosDeBaja, ConsultaEquiposDadosDeBaja());
            Mostrar(grillaConsultaIncrementalCodigo, ds.Tables[0].DefaultView);
        }
        private void Mostrar(DataGridView pGrilla, object pDatos)
        {
            pGrilla.DataSource = null;
            pGrilla.DataSource = pDatos;
        }
        private List<object> ConsultaEquipos()
        {
            var todosLosEquipos = ds.Tables[0].AsEnumerable();
            var consulta = from e in todosLosEquipos
                           select new
                           {
                               Codigo = e.Field<string>(0),
                               Año_Compra = e.Field<int>(3),
                               Valor_Residual = Math.Max(0, e.Field<decimal>(5) - (e.Field<decimal>(5) * 0.15m) * (DateTime.Now.Year - e.Field<int>(3))),
                               En_Uso = e.Field<bool>(4),
                               Valor_Compra = e.Field<decimal>(5),
                               Fecha_Ingreso = e.Field<DateTime>(1),
                               Fecha_Baja = e.Field<DateTime>(2),
                               Dias_En_Empresa = e.Field<bool>(4) ? (DateTime.Now.Date - e.Field<DateTime>(1)).TotalDays : (e.Field<DateTime>(2) - e.Field<DateTime>(1)).TotalDays
                           };
            return consulta.ToList<object>();
        }

        private List<object> ConsultaEquiposDadosDeBaja()
        {
            var todosLosEquipos = ds.Tables[0].AsEnumerable();
            var consulta = from e in todosLosEquipos
                           where e.Field<bool>(4) == false
                           orderby (e.Field<DateTime>(2) - e.Field<DateTime>(1)).TotalDays ascending
                           select new
                           {
                               Codigo = e.Field<string>(0),
                               En_Uso = e.Field<bool>(4),
                               Valor_Compra = e.Field<decimal>(5),
                               Dias_En_Empresa = e.Field<bool>(4) ? (e.Field<DateTime>(2) - e.Field<DateTime>(1)).TotalDays : (DateTime.Now.Date - e.Field<DateTime>(1)).TotalDays
                           };
            return consulta.ToList<object>();
        }
        private List<object> ConsultaEquiposPorValorResidual(decimal pDesde, decimal pHasta)
        {
            var todosLosEquipos = ds.Tables[0].AsEnumerable();
            var consulta = from e in todosLosEquipos
                           where Math.Max(0, e.Field<decimal>(5) - (e.Field<decimal>(5) * 0.15m) * (DateTime.Now.Year - e.Field<int>(3))) >= pDesde && Math.Max(0, e.Field<decimal>(5) - (e.Field<decimal>(5) * 0.15m) * (DateTime.Now.Year - e.Field<int>(3))) <= pHasta
                           orderby Math.Max(0, e.Field<decimal>(5) - (e.Field<decimal>(5) * 0.15m) * (DateTime.Now.Year - e.Field<int>(3))) descending
                           select new
                           {
                               Codigo = e.Field<string>(0),
                               Valor_Residual = Math.Max(0, e.Field<decimal>(5) - (e.Field<decimal>(5) * 0.15m) * (DateTime.Now.Year - e.Field<int>(3))),
                           };
            return consulta.ToList<object>();
        }

        private bool ValidarCodigoRepetido(string pCodigo)
        {
            var rdo = false;
            if (ds.Tables[0].Rows.Find(pCodigo) != null) rdo = true;
            return rdo;
        }
        private void Funcion_PatenteIncorrecta(object? sender, EventArgs e)
        {
            MessageBox.Show("La patente tiene la patente con un formato erróneo", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            throw new Exception("Se cancela la operación!");
        }
        private void GuardarEnBD() => da.Update(ds.Tables[0]);
        private DataRow? RecuperarFilaSeleccionada()
        {
            string codigo = grillaEquipos.SelectedRows[0].Cells[0].Value.ToString();
            DataRow equipo = ds.Tables[0].Rows.Find(codigo) as DataRow;
            return equipo;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaBaja = DateTime.Now;
                string codigo = Interaction.InputBox("Ingrese el código:", "Equipo");
                if (codigo.Length == 0) throw new Exception("El código está vacio!");
                Equipo.ValidarCodigo(codigo);

                if (ValidarCodigoRepetido(codigo)) throw new Exception("El código está repetido!");

                DateTime fechaIngreso = Convert.ToDateTime(Interaction.InputBox("Ingrese la fecha de ingreso:", "Equipo", DateTime.Now.ToShortDateString()));
                bool enUso = MessageBox.Show("¿Está en uso?", "Equipo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? true : false;
                if (!enUso) fechaBaja = Convert.ToDateTime(Interaction.InputBox("Ingrese la fecha de baja:", "Equipo", fechaBaja.ToShortDateString()));

                if (fechaBaja < fechaIngreso) throw new Exception("Existe una incosistencia entre la fecha de baja y fecha de ingreso!");

                string anioCompraInput = Interaction.InputBox("Ingrese el año del equipo:", "Equipo");
                if (anioCompraInput.Length == 0) throw new Exception("El año del equipo está vacio!");
                if (!int.TryParse(anioCompraInput, out int anioCompra)) throw new Exception("El año del equipo debe ser numérico!");
                if (anioCompra < 0) throw new Exception("El año del equipo no puede ser negativo!");

                string valorCompraInput = Interaction.InputBox("Ingrese el valor de la compra:", "Equipo");
                if (valorCompraInput.Length == 0) throw new Exception("El valor de la compra está vacio!");
                if (!decimal.TryParse(valorCompraInput, out decimal valorCompra)) throw new Exception("El valor de la compra debe ser numérico!");
                if (valorCompra < 0) throw new Exception("El valor de la compra no puede ser negativo!");

                Equipo equipo = new Equipo(codigo, fechaIngreso, fechaBaja, anioCompra, enUso, valorCompra);

                ds.Tables[0].Rows.Add(new object[]
                {
                    equipo.Codigo,
                    equipo.FechaIngreso,
                    equipo.FechaBaja,
                    equipo.AnioCompra,
                    equipo.EnUso,
                    equipo.ValorCompra
                });
                Mostrar(grillaEquipos, ConsultaEquipos());
                Mostrar(grillaEquiposDadosDeBaja, ConsultaEquiposDadosDeBaja());
                GuardarEnBD();
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
                if (grillaEquipos.Rows.Count == 0) throw new Exception("No hay equipos en la grilla!");
                var equipo = RecuperarFilaSeleccionada();
                equipo.Delete();
                GuardarEnBD();
                Mostrar(grillaEquipos, ConsultaEquipos());
                Mostrar(grillaEquiposDadosDeBaja, ConsultaEquiposDadosDeBaja());
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
                if (grillaEquipos.Rows.Count == 0) throw new Exception("No hay equipos en la grilla!");
                var equipo = RecuperarFilaSeleccionada();
                DateTime fechaBaja = equipo.Field<DateTime>(2);
                DateTime fechaIngreso = Convert.ToDateTime(Interaction.InputBox("Ingrese la fecha de ingreso:", "Equipo", equipo.Field<DateTime>(1).ToShortDateString()));
                bool enUso = MessageBox.Show("¿Está en uso?", "Equipo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, equipo.Field<bool>(4) ? MessageBoxDefaultButton.Button1 : MessageBoxDefaultButton.Button2) == DialogResult.Yes ? true : false;
                if (!enUso) fechaBaja = Convert.ToDateTime(Interaction.InputBox("Ingrese la fecha de baja:", "Equipo", DateTime.Now.ToShortDateString()));

                if (fechaBaja < fechaIngreso) throw new Exception("Existe una incosistencia entre la fecha de baja y fecha de ingreso!");

                string anioCompraInput = Interaction.InputBox("Ingrese el año del equipo:", "Equipo", equipo.Field<int>(3).ToString());
                if (anioCompraInput.Length == 0) throw new Exception("El año del equipo está vacio!");
                if (!int.TryParse(anioCompraInput, out int anioCompra)) throw new Exception("El año del equipo debe ser numérico!");
                if (anioCompra < 0) throw new Exception("El año del equipo no puede ser negativo!");

                string valorCompraInput = Interaction.InputBox("Ingrese el valor de la compra:", "Equipo", equipo.Field<decimal>(5).ToString());
                if (valorCompraInput.Length == 0) throw new Exception("El valor de la compra está vacio!");
                if (!decimal.TryParse(valorCompraInput, out decimal valorCompra)) throw new Exception("El valor de la compra debe ser numérico!");
                if (valorCompra < 0) throw new Exception("El valor de la compra no puede ser negativo!");

                Equipo equipoModificado = new Equipo(equipo.Field<string>(0), fechaIngreso, fechaBaja, anioCompra, enUso, valorCompra);

                equipo.SetField<DateTime>(1, equipoModificado.FechaIngreso);
                equipo.SetField<DateTime>(2, equipoModificado.FechaBaja);
                equipo.SetField<int>(3, equipoModificado.AnioCompra);
                equipo.SetField<bool>(4, equipoModificado.EnUso);
                equipo.SetField<decimal>(5, equipoModificado.ValorCompra);
                GuardarEnBD();
                Mostrar(grillaEquipos, ConsultaEquipos());
                Mostrar(grillaEquiposDadosDeBaja, ConsultaEquiposDadosDeBaja());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarValorResidualDesdeHasta_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtValorResidualDesde.Text.Length > 0 && txtValorResidualHasta.Text.Length > 0)
                {
                    Mostrar(grillaEquiposValorResidual, ConsultaEquiposPorValorResidual(Convert.ToDecimal(txtValorResidualDesde.Text), Convert.ToDecimal(txtValorResidualHasta.Text)));
                }
            }
            catch (Exception) { }
        }

        private void txtBusquedaPorCodigo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBusquedaPorCodigo.Text.Length > 0)
                {
                    DataView dv = ds.Tables[0].AsDataView();
                    dv.RowFilter = $"codigo like '{txtBusquedaPorCodigo.Text}%'";
                    Mostrar(grillaConsultaIncrementalCodigo, dv);
                }
            }
            catch (Exception) { }
        }

        private void btnGuardarEnXml_Click(object sender, EventArgs e)
        {
            try
            {
                ds.WriteXml("equipos.xml", XmlWriteMode.WriteSchema);
                MessageBox.Show("Archivo guardado exitosamente!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
