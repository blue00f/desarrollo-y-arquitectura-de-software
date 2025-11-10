using BE;
using Interfaces;
using ORM;

namespace BLL
{
    public class BLL_Proveedor : IABMC<BE_Proveedor>
    {
        ORM_Proveedor ormProveedor;
        BLL_Equipoxproveedor bllEquipoproveedor;
        public BLL_Proveedor()
        {
            ormProveedor = new ORM_Proveedor();
            bllEquipoproveedor = new BLL_Equipoxproveedor();
        }
        public void Agregar(BE_Proveedor pObjeto) => ormProveedor.Agregar(pObjeto);

        public void Borrar(BE_Proveedor pObjeto)
        {
            foreach (var o in bllEquipoproveedor.Consultar())
            {
                if (o.Proveedor.Codigo == pObjeto.Codigo) throw new Exception("El proveedor está asignado a un equipo!");
            }
            ormProveedor.Borrar(pObjeto);
        }
        public void Modificar(BE_Proveedor pObjeto) => ormProveedor.Modificar(pObjeto);
        public List<BE_Proveedor> Consultar() => ormProveedor.Consultar();
        public bool ValidarCodigoRepetido(BE_Proveedor pObjeto) => ormProveedor.ValidarCodigoRepetido(pObjeto);
    }
}
