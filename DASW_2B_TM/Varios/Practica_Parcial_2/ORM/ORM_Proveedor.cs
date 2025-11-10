using BE;
using DAL;
using Interfaces;
using System.Data;

namespace ORM
{
    public class ORM_Proveedor : IABMC<BE_Proveedor>
    {
        DAO _dao;
        const string tabla = "proveedor";
        public ORM_Proveedor() => _dao = new DAO();
        public void Agregar(BE_Proveedor pObjeto)
        {
            _dao.Agregar(tabla, pObjeto.Codigo, pObjeto.Nombre, pObjeto.Direccion);
            _dao.Actualizar(tabla);
        }
        public void Borrar(BE_Proveedor pObjeto)
        {
            _dao.Borrar(tabla, pObjeto.Codigo);
            _dao.Actualizar(tabla);
        }
        public void Modificar(BE_Proveedor pObjeto)
        {
            DataTable dt = _dao.Consultar(tabla);
            DataRow fila = dt.Rows.Find(pObjeto.Codigo);
            if (fila != null)
            {
                fila[1] = pObjeto.Nombre;
                fila[2] = pObjeto.Direccion;
                _dao.Actualizar(tabla);
            }
        }
        public List<BE_Proveedor> Consultar()
        {
            DataTable dt = _dao.Consultar(tabla);
            var proveedores = new List<BE_Proveedor>();
            foreach (DataRow f in dt.Rows)
            {
                proveedores.Add(new BE_Proveedor(
                    f.Field<string>(0),
                    f.Field<string>(1),
                    f.Field<string>(2)
                ));
            }
            return proveedores;
        }
        public bool ValidarCodigoRepetido(BE_Proveedor pObjeto)
        {
            bool rdo = false;
            foreach (var p in Consultar())
            {
                if (pObjeto.Codigo == p.Codigo) rdo = true;
            }
            return rdo;
        }
    }
}
