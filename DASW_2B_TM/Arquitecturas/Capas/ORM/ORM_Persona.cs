using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Entidades;
using Interfaces;
using System.Data;

namespace ORM
{
    internal class ORM_Persona : Iabmc<BE_Persona>, IDisposable
    {
        DataSet ds;
        DAO_AccesoDatos dao;
        public ORM_Persona()
        {
            dao = new DAO_AccesoDatos();
            ds = dao.RetornaDataSet();
        }
        public void Alta(BE_Persona pObject)
        {
            try
            {
                ds = dao.RetornaDataSet();
                if (ds.Tables["Persona"].Rows.Find(pObject.DNI) == null) 
                {
                    // Generamos un dataRow de persona
                    DataRow drPersona = ds.Tables["Persona"].NewRow();
                    // Le cargamos los datos que arribaron como parte del estado del Prestamos (Propiedad Persona) al dataRow 
                    drPersona.ItemArray = new object[] { pObject.DNI, pObject.Nombre, pObject.Apellido };
                    // Agregamos el datarow al datatable de Persona
                    ds.Tables["Persona"].Rows.Add(drPersona);
                    dao.GrabarDatos(ds);
                }               
            }
            catch (Exception ex) { throw ex; }
        }
        public void Baja(BE_Persona pObject)
        {
            throw new NotImplementedException();
        }
        public void Modificacion(BE_Persona pObject)
        {
            throw new NotImplementedException();
        }
        public List<BE_Persona> Consulta(BE_Persona pObject)
        {
            throw new NotImplementedException();
        }
        public List<BE_Persona> ConsultaDesdeHasta(BE_Persona pObject1, BE_Persona pObject2)
        {
            throw new NotImplementedException();
        }
        public List<BE_Persona> ConsultaIncremental(BE_Persona pObject)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
