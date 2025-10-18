using System.Data;

namespace DAO
{
    public class DAO_AccesoDatos
    {
        DataSet _ds;
        DataTable _dtPrestamo;
        DataTable _dtPersona;
        public DAO_AccesoDatos()
        {
            _ds = new DataSet("Datos");
            if (!File.Exists("Datos.xml")) CrearArchivo();
            else _ds.ReadXml("Datos.xml");
        }
        public DataSet RetornaDataSet() 
        {
            _ds.Tables.Clear();
            _ds.ReadXml("Datos.xml");
            return _ds;
        }
        public void GrabarDatos(DataSet pDS) => pDS.WriteXml("Datos.xml", XmlWriteMode.WriteSchema);

        private void CrearArchivo()
        {
            // Creamos los dataTable
            _dtPrestamo = new DataTable("Prestamo");
            _dtPersona = new DataTable("Persona");

            // Le colocamos las columnas al dataTable dtPrestamo
            _dtPrestamo.Columns.Add("Codigo", typeof(string));
            _dtPrestamo.Columns.Add("MontoOtorgado", typeof(decimal));
            _dtPrestamo.Columns.Add("FechaOtorgado", typeof(DateTime));
            _dtPrestamo.Columns.Add("Interes", typeof(decimal));
            _dtPrestamo.Columns.Add("InteresPunitorio", typeof(decimal));
            _dtPrestamo.Columns.Add("FechaVencimiento", typeof(DateTime));
            _dtPrestamo.Columns.Add("FechaDevolucion", typeof(DateTime));
            _dtPrestamo.Columns.Add("MontoDevuelto", typeof(decimal));

            // El DNI oficia de clave foranea en elte dataTable
            _dtPrestamo.Columns.Add("DNI", typeof(string));

            // Establecemos como clave primaria la columna código del préstamo
            _dtPrestamo.PrimaryKey = new DataColumn[] { _dtPrestamo.Columns[0] };

            // Le colocamos las columnas al dataTable dtPersona
            _dtPersona.Columns.Add("DNI", typeof(string));
            _dtPersona.Columns.Add("Nombre", typeof(string));
            _dtPersona.Columns.Add("Apellido", typeof(string));

            //  Establecemos como clave primaria la columna DNI de la persona
            _dtPersona.PrimaryKey = new DataColumn[] { _dtPersona.Columns[0] };

            // Agregamos al dataTable las tablas
            _ds.Tables.AddRange(new DataTable[] { _dtPrestamo, _dtPersona });
            GrabarDatos(_ds);
        }
    }
}
