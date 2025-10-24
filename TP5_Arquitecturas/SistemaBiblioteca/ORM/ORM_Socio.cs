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
    public class ORM_Socio : IABMC<BE_Socio>
    {
        DAO _dao;
        public ORM_Socio()
        {
            _dao = new DAO();
        }

        public void Agregar(BE_Socio pSocio)
        {
            DataRow fila = _dao.Consultar(DAO.Tabla.Socio).NewRow();
            fila.ItemArray = new object[]
            {
                pSocio.Id,
                pSocio.Nombre,
                pSocio.Apellido,
                pSocio.FechaNacimiento,
                pSocio.Localidad
            };
            _dao.Agregar(DAO.Tabla.Socio, fila);
        }

        public void Borrar(BE_Socio pSocio)
        {
            DataTable dt = _dao.Consultar(DAO.Tabla.Socio);
            DataRow fila = dt.Rows.Find(pSocio.Id);
            _dao.Borrar(DAO.Tabla.Socio, fila);
        }

        public void Modificar(BE_Socio pSocio)
        {
            DataTable dt = _dao.Consultar(DAO.Tabla.Socio);
            DataRow fila = dt.Rows.Find(pSocio.Id);
            fila.ItemArray = new object[]
            {
                fila[0],
                pSocio.Nombre,
                pSocio.Apellido,
                pSocio.FechaNacimiento,
                pSocio.Localidad
            };
            _dao.Modificar(DAO.Tabla.Socio);
        }

        public List<BE_Socio> ObtenerDatos()
        {
            List<BE_Socio> socios = new List<BE_Socio>();
            foreach (DataRow f in _dao.Consultar(DAO.Tabla.Socio).Rows)
            {
                socios.Add(new BE_Socio(f.Field<string>(0), f.Field<string>(1), f.Field<string>(2), f.Field<DateTime>(3), f.Field<string>(4)));
            }
            return socios;
        }
        public BE_Socio ObtenerPorId(string pId)
        {
            BE_Socio socio = null;
            foreach (DataRow f in _dao.Consultar(DAO.Tabla.Socio).Rows)
            {
                if (f.Field<string>(0) == pId)
                {
                    socio = new BE_Socio(f.Field<string>(0), f.Field<string>(1), f.Field<string>(2), f.Field<DateTime>(3), f.Field<string>(4));
                }
            }
            return socio;
        }
        public bool ValidarIdRepetido(BE_Socio pSocio)
        {
            bool rdo = false;
            foreach (DataRow f in _dao.Consultar(DAO.Tabla.Socio).Rows)
            {
                if (f.ItemArray[0].ToString() == pSocio.Id) rdo = true;
            }
            return rdo;
        }
    }
}
