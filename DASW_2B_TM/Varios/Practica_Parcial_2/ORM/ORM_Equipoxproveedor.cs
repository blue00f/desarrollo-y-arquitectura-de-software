using BE;
using DAL;
using Interfaces;
using System.Data;

namespace ORM
{
    public class ORM_Equipoxproveedor : IABMC<BE_Equipoxproveedor>
    {
        DAO dao;
        ORM_Equipo ormEquipo;
        ORM_Proveedor ormProveedor;
        public ORM_Equipoxproveedor()
        {
            dao = new DAO();
            ormEquipo = new ORM_Equipo();
            ormProveedor = new ORM_Proveedor();
        }
        const string tabla = "equipoxproveedor";
        public void Agregar(BE_Equipoxproveedor pObjeto)
        {
            dao.Agregar(tabla, pObjeto.Equipo.Codigo, pObjeto.Proveedor.Codigo, pObjeto.Nombre, pObjeto.Apellido);
        }
        public void Borrar(BE_Equipoxproveedor pObjeto) => throw new NotImplementedException();
        public void Modificar(BE_Equipoxproveedor pObjeto) => throw new NotImplementedException();
        public List<BE_Equipoxproveedor> Consultar()
        {
            DataTable dt = dao.Consultar(tabla);
            var lista = new List<BE_Equipoxproveedor>();

            foreach (DataRow f in dt.Rows)
            {
                lista.Add(new BE_Equipoxproveedor(
                    RecuperarObjetoEquipo(f.Field<string>(0)),
                    RecuperarObjetoProveedor(f.Field<string>(1)),
                    f.Field<string>(2),
                    f.Field<string>(3)
                ));
            }

            return lista;
        }
        private BE_Equipo RecuperarObjetoEquipo(string pCodigo)
        {
            BE_Equipo equipo = null;
            foreach (BE_Equipo e in ormEquipo.Consultar())
            {
                if (pCodigo == e.Codigo) equipo = e;
            }
            return equipo;
        }
        private BE_Proveedor RecuperarObjetoProveedor(string pCodigo)
        {
            BE_Proveedor proveedor = null;
            foreach (BE_Proveedor p in ormProveedor.Consultar())
            {
                if (pCodigo == p.Codigo) proveedor = p;
            }
            return proveedor;
        }
        public bool ValidarCodigoRepetido(BE_Equipoxproveedor pObjeto) => throw new NotImplementedException();
    }
}
