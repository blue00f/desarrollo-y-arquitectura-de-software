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
            con = new SqlConnection("Data Source=.;Initial Catalog=bd_empresa_parcial2;Integrated Security=true;Trust Server Certificate=true");
            ds = new DataSet("bd_empresa");
            adaptadores = new Dictionary<string, SqlDataAdapter>();
            InicializarTabla("empleado");

            ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns[0] };
        }

        private void InicializarTabla(string pNombreTabla)
        {
            SqlDataAdapter da = new SqlDataAdapter($"select * from {pNombreTabla}", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            da.InsertCommand = cb.GetInsertCommand();
            da.UpdateCommand = cb.GetUpdateCommand();
            da.DeleteCommand = cb.GetDeleteCommand();

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
            Actualizar(pTabla);
        }
        public void Borrar(string pTabla, string pCodigo)
        {
            DataTable dt = ds.Tables[pTabla];
            DataRow fila = dt.Rows.Find(pCodigo);
            if (fila != null)
            {
                fila.Delete();
                Actualizar(pTabla);
            }
        }
        public DataTable Consultar(string pTabla) => ds.Tables[pTabla];
        public void Actualizar(string pTabla)
        {
            if (adaptadores.ContainsKey(pTabla)) adaptadores[pTabla].Update(ds.Tables[pTabla]);
        }
    }
}
