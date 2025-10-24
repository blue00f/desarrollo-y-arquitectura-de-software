using DAL;
using BE;
using System.Data;
using Interfaces;

namespace ORM
{
    public class ORM_Libro : IABMC<BE_Libro>
    {
        DAO _dao;
        public ORM_Libro()
        {
            _dao = new DAO();
        }
        public void Agregar(BE_Libro pLibro)
        {
            DataRow fila = _dao.Consultar(DAO.Tabla.Libro).NewRow();
            fila.ItemArray = new object[]
            {
                pLibro.Id,
                pLibro.Titulo,
                pLibro.Autor
            };
            _dao.Agregar(DAO.Tabla.Libro, fila);
        }
        public void Borrar(BE_Libro pLibro)
        {
            DataTable dt = _dao.Consultar(DAO.Tabla.Libro);
            DataRow fila = dt.Rows.Find(pLibro.Id);
            _dao.Borrar(DAO.Tabla.Libro, fila);
        }
        public void Modificar(BE_Libro pLibro)
        {
            DataTable dt = _dao.Consultar(DAO.Tabla.Libro);
            DataRow fila = dt.Rows.Find(pLibro.Id);
            fila.ItemArray = new object[]
            {
                fila[0],
                pLibro.Titulo,
                pLibro.Autor
            };
            _dao.Modificar(DAO.Tabla.Libro);
        }
        public List<BE_Libro> ObtenerDatos()
        {
            List<BE_Libro> libros = new List<BE_Libro>();
            foreach (DataRow f in _dao.Consultar(DAO.Tabla.Libro).Rows)
            {
                libros.Add(new BE_Libro(f.Field<string>(0), f.Field<string>(1), f.Field<string>(2)));
            }
            return libros;
        }
        public BE_Libro ObtenerPorId(string pId)
        {
            BE_Libro libro = null;
            foreach (DataRow f in _dao.Consultar(DAO.Tabla.Libro).Rows)
            {
                if (f.Field<string>(0) == pId)
                {
                    libro = new BE_Libro(f.Field<string>(0), f.Field<string>(1), f.Field<string>(2));
                }
            }
            return libro;
        }
        public bool ValidarIdRepetido(BE_Libro pLibro)
        {
            bool rdo = false;
            foreach (DataRow f in _dao.Consultar(DAO.Tabla.Libro).Rows)
            {
                if (f.ItemArray[0].ToString() == pLibro.Id) rdo = true;
            }
            return rdo;
        }
    }
}
