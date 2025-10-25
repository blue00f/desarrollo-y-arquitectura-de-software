using BE;
using DAL;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class ORM_Prestamo : IABMC<BE_Prestamo>
    {
        DAO _dao;
        ORM_Libro _ormlibro;
        ORM_Socio _ormsocio;
        public ORM_Prestamo()
        {
            _dao = new DAO();
            _ormlibro = new ORM_Libro();
            _ormsocio = new ORM_Socio();
            foreach (DataRow f in _dao.Consultar(DAO.Tabla.Prestamo).Rows)
            {
                BE_Socio socio = _ormsocio.ObtenerPorId(f.Field<string>(1));
                BE_Libro libro = _ormlibro.ObtenerPorId(f.Field<string>(2));
                BE_Prestamo prestamo = new BE_Prestamo(f.Field<string>(0), socio, libro, f.Field<DateTime>(4), f.Field<DateTime>(5), f.Field<string>(3));
                socio.Prestamos.Add(prestamo);
                libro.Prestamos.Add(prestamo);
            }
        }

        public void Agregar(BE_Prestamo pPrestamo)
        {
            DataRow fila = _dao.Consultar(DAO.Tabla.Prestamo).NewRow();
            fila.ItemArray = new object[]
            {
                pPrestamo.Id,
                pPrestamo.Socio.Id,
                pPrestamo.Libro.Id,
                pPrestamo.Estado,
                pPrestamo.FechaPrestamo,
                pPrestamo.FechaDevolucion
            };
            _dao.Agregar(DAO.Tabla.Prestamo, fila);

            pPrestamo.Socio.Prestamos.Add(pPrestamo);
            pPrestamo.Libro.Prestamos.Add(pPrestamo);
        }

        public void Borrar(BE_Prestamo pPrestamo)
        {
            DataTable dt = _dao.Consultar(DAO.Tabla.Prestamo);
            DataRow fila = dt.Rows.Find(pPrestamo.Id);
            _dao.Borrar(DAO.Tabla.Prestamo, fila);
        }

        public void Modificar(BE_Prestamo pPrestamo)
        {
            DataTable dt = _dao.Consultar(DAO.Tabla.Prestamo);
            DataRow fila = dt.Rows.Find(pPrestamo.Id);
            fila.ItemArray = new object[]
            {
                fila[0],
                fila[1],
                fila[2],
                pPrestamo.Estado,
                pPrestamo.FechaPrestamo,
                pPrestamo.FechaDevolucion
            };
            _dao.Modificar(DAO.Tabla.Prestamo);
        }

        public List<BE_Prestamo> ObtenerDatos()
        {
            List<BE_Prestamo> prestamos = new List<BE_Prestamo>();
            foreach (DataRow f in _dao.Consultar(DAO.Tabla.Prestamo).Rows)
            {
                prestamos.Add(new BE_Prestamo(f.Field<string>(0), _ormsocio.ObtenerPorId(f.Field<string>(1)), _ormlibro.ObtenerPorId(f.Field<string>(2)), f.Field<DateTime>(4), f.Field<DateTime>(5), f.Field<string>(3)));
            }
            return prestamos;
        }
        public bool ValidarIdRepetido(BE_Prestamo pPrestamo)
        {
            bool rdo = false;
            foreach (DataRow f in _dao.Consultar(DAO.Tabla.Prestamo).Rows)
            {
                if (f.ItemArray[0].ToString() == pPrestamo.Id) rdo = true;
            }
            return rdo;
        }
    }
}
