using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAO
    {
        DataSet ds;
        DataTable dtLibro, dtSocio, dtPrestamo;
        DataRelation drLibroPrestamo, drSocioPrestamo;
        SqlConnection con;
        SqlDataAdapter daLibro, daSocio, daPrestamo;
        SqlCommandBuilder cbLibro, cbSocio, cbPrestamo;

        public enum Tabla
        {
            Libro,
            Socio,
            Prestamo
        }
        public DAO()
        {
            ds = new DataSet("BD_BIBLIOTECA");
            dtLibro = new DataTable("Libro");
            dtSocio = new DataTable("Socio");
            dtPrestamo = new DataTable("Prestamo");

            con = new SqlConnection("Data Source=.;Initial Catalog=bd_biblioteca_tp5;User ID=administrador;Password=ETN7dolores;Trust Server Certificate=True");

            daLibro = new SqlDataAdapter("select * from libro", con);
            daSocio = new SqlDataAdapter("select * from socio", con);
            daPrestamo = new SqlDataAdapter("select * from prestamo", con);

            cbLibro = new SqlCommandBuilder(daLibro);
            cbSocio = new SqlCommandBuilder(daSocio);
            cbPrestamo = new SqlCommandBuilder(daPrestamo);

            daLibro.InsertCommand = cbLibro.GetInsertCommand();
            daLibro.DeleteCommand = cbLibro.GetDeleteCommand();
            daLibro.UpdateCommand = cbLibro.GetUpdateCommand();

            daSocio.InsertCommand = cbSocio.GetInsertCommand();
            daSocio.DeleteCommand = cbSocio.GetDeleteCommand();
            daSocio.UpdateCommand = cbSocio.GetUpdateCommand();

            daPrestamo.InsertCommand = cbPrestamo.GetInsertCommand();
            daPrestamo.DeleteCommand = cbPrestamo.GetDeleteCommand();
            daPrestamo.UpdateCommand = cbPrestamo.GetUpdateCommand();

            daLibro.Fill(dtLibro);
            daSocio.Fill(dtSocio);
            daPrestamo.Fill(dtPrestamo);

            dtLibro.PrimaryKey = new DataColumn[] { dtLibro.Columns[0] };
            dtSocio.PrimaryKey = new DataColumn[] { dtSocio.Columns[0] };
            dtPrestamo.PrimaryKey = new DataColumn[] { dtPrestamo.Columns[0] };

            ds.Tables.Add(dtLibro);
            ds.Tables.Add(dtSocio);
            ds.Tables.Add(dtPrestamo);

            drLibroPrestamo = new DataRelation("Libro_Prestamo", dtLibro.Columns[0], dtPrestamo.Columns[2]);
            drSocioPrestamo = new DataRelation("Socio_Prestamo", dtSocio.Columns[0], dtPrestamo.Columns[1]);

            ds.Relations.Add(drLibroPrestamo);
            ds.Relations.Add(drSocioPrestamo);
        }

        public void Agregar(Tabla pTabla, DataRow pFila)
        {
            DataTable dt = ds.Tables[pTabla.ToString()];
            dt.Rows.Add(pFila);
            ActualizarTabla(pTabla);
        }
        public void Borrar(Tabla pTabla, DataRow pFila)
        {
            pFila.Delete();
            ActualizarTabla(pTabla);
        }
        public void Modificar(Tabla pTabla) => ActualizarTabla(pTabla);
        public DataTable Consultar(Tabla pTabla) => ds.Tables[pTabla.ToString()];
        private void ActualizarTabla(Tabla pTabla)
        {
            if (pTabla.ToString() == "Libro") daLibro.Update(ds.Tables[0]);
            if (pTabla.ToString() == "Socio") daSocio.Update(ds.Tables[1]);
            if (pTabla.ToString() == "Prestamo") daPrestamo.Update(ds.Tables[2]);
        }
    }
}
