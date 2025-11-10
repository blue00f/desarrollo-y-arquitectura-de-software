using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DAO
    {
        SqlConnection con;
        DataSet ds;
        Dictionary<string, SqlDataAdapter> adaptadores;
        public DAO()
        {
            con = new SqlConnection("Data Source=.;Initial Catalog=bd_equipos_segundoparcial;Integrated Security=true;Trust Server Certificate=true");
            ds = new DataSet("bd_equipos");
            adaptadores = new Dictionary<string, SqlDataAdapter>();
            InicializarTabla("equipo");
            InicializarTabla("proveedor");
            InicializarTabla("equipoxproveedor");

            ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns[0] };
            ds.Tables[1].PrimaryKey = new DataColumn[] { ds.Tables[1].Columns[0] };
            ds.Tables[2].PrimaryKey = new DataColumn[] { ds.Tables[2].Columns[0], ds.Tables[2].Columns[1] };

            ds.Relations.Add("fk_equipo", ds.Tables[0].Columns[0], ds.Tables[2].Columns[0]);
            ds.Relations.Add("fk_proveedor", ds.Tables[1].Columns[0], ds.Tables[2].Columns[1]);
        }
        public void InicializarTabla(string pNombreTabla)
        {
            SqlDataAdapter da = new SqlDataAdapter($"select * from {pNombreTabla}", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.InsertCommand = cb.GetInsertCommand();
            da.DeleteCommand = cb.GetDeleteCommand();
            da.UpdateCommand = cb.GetUpdateCommand();
            DataTable dt = new DataTable(pNombreTabla);
            da.Fill(dt);
            ds.Tables.Add(dt);
            adaptadores[pNombreTabla] = da;
        }
        public void Agregar(string pTabla, params object[] pValores)
        {
            DataTable dt = ds.Tables[pTabla];
            DataRow fila = dt.NewRow();
            fila.ItemArray = pValores;
            dt.Rows.Add(fila);
            //Actualizar(pTabla);
        }
        public void Borrar(string pTabla, string pId)
        {
            DataTable dt = ds.Tables[pTabla];
            DataRow fila = dt.Rows.Find(pId);
            if (fila != null)
            {
                fila.Delete();
                //Actualizar(pTabla);
            }
        }
        public DataTable Consultar(string pTabla) => ds.Tables[pTabla];
        public void Actualizar(string pTabla)
        {
            if (adaptadores.ContainsKey(pTabla)) adaptadores[pTabla].Update(ds.Tables[pTabla]);
        }
        public void GuardarXml()
        {
            ds.WriteXml("equipos.xml", XmlWriteMode.WriteSchema);
        }
    }
}
