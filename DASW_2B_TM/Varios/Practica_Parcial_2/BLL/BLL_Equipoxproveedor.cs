using BE;
using Interfaces;
using ORM;

namespace BLL
{
    public class BLL_Equipoxproveedor : IABMC<BE_Equipoxproveedor>
    {
        ORM_Equipoxproveedor ormEquipoxproveedor;
        public BLL_Equipoxproveedor() => ormEquipoxproveedor = new ORM_Equipoxproveedor();
        public void Agregar(BE_Equipoxproveedor pObjeto) => ormEquipoxproveedor.Agregar(pObjeto);
        public void Borrar(BE_Equipoxproveedor pObjeto) => throw new NotImplementedException();

        public void Modificar(BE_Equipoxproveedor pObjeto) => throw new NotImplementedException();
        public List<BE_Equipoxproveedor> Consultar() => ormEquipoxproveedor.Consultar();
        public bool ValidarCodigoRepetido(BE_Equipoxproveedor pObjeto) => throw new NotImplementedException();
    }
}
