using DAO;
using Entidades;
using Interfaces;
using System.Data;

namespace ORM
{
    public class ORM_Prestamo : Iabmc<BE_Prestamo>, IDisposable
    {
        DataSet ds;
        DAO_AccesoDatos dao;
        ORM_Persona ormPersona;
        public ORM_Prestamo()
        {
            dao = new DAO_AccesoDatos();
            ds = dao.RetornaDataSet();
            ormPersona = new ORM_Persona();
        }
        public void Alta(BE_Prestamo pObject)
        {
            try
            {
                // Tomamos el dataTable Préstamo del dataSet _ds
                DataTable dtPrestamo = ds.Tables["Prestamo"];
                // Generamos un dataRow a partir del dataTable Préstamo
                DataRow drPrestamo = dtPrestamo.NewRow();
                // Le cargamos al dataTable los datos que llegaron en el estado del objeto BE_Prestamo que
                // recibimos por parámetro
                drPrestamo.ItemArray = new object[] {pObject.Codigo,pObject.MontoOtorgado,pObject.FechaOtorgado,
                                              pObject.Interes,pObject.InteresPunitorio,pObject.FechaVencimiento,
                                              pObject.FechaDevolucion,pObject.MontoDevuelto,pObject.Persona.DNI};
                // Agregamos el dataRow de Préstamos al dataTable Préstamo
                dtPrestamo.Rows.Add(drPrestamo);
                // Solicitamos el servicio de grabación de datos a _dao
                dao.GrabarDatos(ds);
                //Enviamos a dar de alta la persona               
                ormPersona.Alta(new BE_Persona(pObject.Persona.DNI,pObject.Persona.Nombre,pObject.Persona.Apellido));
            }
            catch (Exception ex) { throw ex; }
        }

        public void Baja(BE_Prestamo pObject)
        {
            try
            {
                DataTable dtPrestamos = ds.Tables["Prestamo"];
                dtPrestamos.Rows.Find(pObject.Codigo).Delete();
                dao.GrabarDatos(ds);
            }           
            catch (Exception ex) { throw ex; }
        }
        public void Modificacion(BE_Prestamo pObject)
        {
            try
            {
                DataTable dtPrestamos = ds.Tables["Prestamo"];
                DataRow dr = dtPrestamos.Rows.Find(pObject.Codigo);
                dr.ItemArray = new object[] {pObject.Codigo, pObject.MontoOtorgado, pObject.FechaOtorgado,
                                              pObject.Interes, pObject.InteresPunitorio, pObject.FechaVencimiento,
                                              pObject.FechaDevolucion, pObject.MontoDevuelto, pObject.Persona.DNI };
                dao.GrabarDatos(ds);
            }
            catch (Exception ex) { throw ex; }
        }
        public List<BE_Prestamo> ConsultaTodosPrestamos()
        {
            List<BE_Prestamo> aux = new List<BE_Prestamo>();
            ds = dao.RetornaDataSet();

            foreach (DataRow r in ds.Tables["Prestamo"].Rows)
            {
                BE_Persona auxper = new BE_Persona(ds.Tables["Persona"].Rows.Find(r.ItemArray[8]).ItemArray);
                aux.Add(new BE_Prestamo(r.ItemArray, auxper));
            }
            return aux;
        }
        public List<BE_Prestamo> Consulta(BE_Prestamo pObject)
        {
            var resultado = from x in ConsultaTodosPrestamos() where x.Codigo == pObject.Codigo select x;
            return resultado.ToList();
        }
        public List<BE_Prestamo> ConsultaDesdeHasta(BE_Prestamo pObject1, BE_Prestamo pObject2)
        {
            var resultado = from x in ConsultaTodosPrestamos() where x.Codigo.CompareTo(pObject1.Codigo)>=0 && x.Codigo.CompareTo(pObject2.Codigo)<=0 select x;
            return resultado.ToList();
        }

        public List<BE_Prestamo> ConsultaIncremental(BE_Prestamo pObject)
        {
            var resultados = from r in ConsultaTodosPrestamos()
                             where r.Codigo.StartsWith(pObject.Codigo)
                             select r;

            return resultados.ToList();
        }
        public void Dispose() => dao = null;
    }
}
