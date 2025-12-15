using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DAO
    {
        // PATRÓN SINGLETON (opcional aplicarlo para el final)
        private static DAO _instancia;
        public static DAO instancia
        {
            get
            {
                if (_instancia == null) _instancia = new DAO();
                return _instancia;
            }
        }

        SqlConnection con;
        DataSet ds;
        Dictionary<string, SqlDataAdapter> adaptadores;
        public DAO()
        {
            con = new SqlConnection("Data Source=.;Initial Catalog=bd_banco;Integrated Security=true;Trust Server Certificate=true");
            ds = new DataSet("bd_banco");
            adaptadores = new Dictionary<string, SqlDataAdapter>();
            InicializarTabla("cuentacorriente");
            InicializarTabla("cajaahorro");
            InicializarTabla("titular");
            InicializarTabla("cuentacorrientextitular");
            InicializarTabla("cajaahorroxtitular");

            ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns[0] };
            ds.Tables[1].PrimaryKey = new DataColumn[] { ds.Tables[1].Columns[0] };
            ds.Tables[2].PrimaryKey = new DataColumn[] { ds.Tables[2].Columns[0] };
            ds.Tables[3].PrimaryKey = new DataColumn[] { ds.Tables[3].Columns[0], ds.Tables[3].Columns[1] };
            ds.Tables[4].PrimaryKey = new DataColumn[] { ds.Tables[4].Columns[0], ds.Tables[4].Columns[1] };
            ds.Relations.Add("fk_titular", ds.Tables[2].Columns[0], ds.Tables[3].Columns[0]);
            ds.Relations.Add("fk_cuentacorriente", ds.Tables[0].Columns[0], ds.Tables[3].Columns[1]);
            ds.Relations.Add("fk_titularcuenta", ds.Tables[2].Columns[0], ds.Tables[4].Columns[0]);
            ds.Relations.Add("fk_cajaahorro", ds.Tables[1].Columns[0], ds.Tables[4].Columns[1]);
        }
        private void InicializarTabla(string pTabla)
        {
            SqlDataAdapter da = new SqlDataAdapter($"select * from {pTabla}", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.InsertCommand = cb.GetInsertCommand();
            da.DeleteCommand = cb.GetDeleteCommand();
            da.UpdateCommand = cb.GetUpdateCommand();
            DataTable dt = new DataTable(pTabla);
            da.Fill(dt);
            ds.Tables.Add(dt);
            adaptadores[pTabla] = da;
        }
        public void Agregar(string pTabla, params object[] pValores)
        {
            DataTable dt = ds.Tables[pTabla];
            DataRow fila = dt.NewRow();
            fila.ItemArray = pValores;
            dt.Rows.Add(fila);
            Actualizar(pTabla);
        }
        public void Borrar(string pTabla, string pId)
        {
            DataTable dt = ds.Tables[pTabla];
            DataRow fila = dt.Rows.Find(pId);
            if (fila != null)
            {
                fila.Delete();
            }
            Actualizar(pTabla);
        }
        public DataTable Consultar(string pTabla) => ds.Tables[pTabla];
        public void Actualizar(string pTabla)
        {
            if (adaptadores.ContainsKey(pTabla))
            {
                adaptadores[pTabla].Update(ds.Tables[pTabla]);
            }
        }
        public void GuardarXml() => ds.WriteXml("bd_banco.xml", XmlWriteMode.WriteSchema);
    }
}
