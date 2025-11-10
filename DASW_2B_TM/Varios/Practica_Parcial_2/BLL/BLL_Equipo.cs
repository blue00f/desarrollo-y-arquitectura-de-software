using Interfaces;
using BE;
using ORM;
namespace BLL
{
    public class BLL_Equipo : IABMC<BE_Equipo>
    {
        ORM_Equipo _orm;
        BLL_Equipoxproveedor bllEquipoproveedor;
        public BLL_Equipo()
        {
            _orm = new ORM_Equipo();
            bllEquipoproveedor = new BLL_Equipoxproveedor();
        }
        public void Agregar(BE_Equipo pObjeto) => _orm.Agregar(pObjeto);
        public void Borrar(BE_Equipo pObjeto)
        {
            foreach (var o in bllEquipoproveedor.Consultar())
            {
                if (o.Equipo.Codigo == pObjeto.Codigo) throw new Exception("El equipo está asociado a un proveedor!");
            }
            _orm.Borrar(pObjeto);
        }
        public void Modificar(BE_Equipo pObjeto) => _orm.Modificar(pObjeto);
        public List<BE_Equipo> Consultar() => _orm.Consultar();
        public bool ValidarCodigoRepetido(BE_Equipo pObjeto) => _orm.ValidarCodigoRepetido(pObjeto);
        public BE_Equipo? RecuperarEquipoPorCodigo(string pCodigo)
        {
            BE_Equipo equipo = null;
            foreach (BE_Equipo e in _orm.Consultar())
            {
                if (pCodigo == e.Codigo) equipo = e;
            }
            return equipo;
        }
        public List<object> ConsultaPersonalizada1()
        {
            var consulta = from e in Consultar()
                           select new
                           {
                               Codigo = e.Codigo,
                               Año_Compra = e.AxoCompra,
                               Valor_Residual = e.CalcularValorResidual().ToString("0.00"),
                               En_Uso = e.EnUso,
                               Valor_Compra = e.ValorCompra,
                               Fecha_Ingreso = e.FechaIngreso,
                               Fecha_Baja = e.FechaBaja,
                               Dias_En_Empresa = e.CalcularCantidadDiasEnEmpresa()
                           };
            return consulta.ToList<object>();
        }
        public List<object> ConsultaDadosDeBajaAsc()
        {
            var consulta = from e in Consultar()
                           where e.EnUso == false
                           orderby e.CalcularCantidadDiasEnEmpresa() ascending
                           select new
                           {
                               Codigo = e.Codigo,
                               Año_Compra = e.AxoCompra,
                               Valor_Residual = e.CalcularValorResidual().ToString("0.00"),
                               En_Uso = e.EnUso,
                               Valor_Compra = e.ValorCompra,
                               Fecha_Ingreso = e.FechaIngreso,
                               Fecha_Baja = e.FechaBaja,
                               Dias_En_Empresa = e.CalcularCantidadDiasEnEmpresa()
                           };
            return consulta.ToList<object>();
        }
        public List<object> ConsultaValorResidualDesdeHasta(decimal pDesde, decimal pHasta)
        {
            var consulta = from e in Consultar() where e.CalcularValorResidual() >= pDesde && e.CalcularValorResidual() <= pHasta orderby e.CalcularValorResidual() descending
                           select new
                           {
                               Codigo = e.Codigo,
                               Año_Compra = e.AxoCompra,
                               Valor_Residual = e.CalcularValorResidual().ToString("0.00"),
                               En_Uso = e.EnUso,
                               Valor_Compra = e.ValorCompra,
                               Fecha_Ingreso = e.FechaIngreso,
                               Fecha_Baja = e.FechaBaja,
                               Dias_En_Empresa = e.CalcularCantidadDiasEnEmpresa()
                           };
            return consulta.ToList<object>();
        }
        public List<object> ConsultaIncrementalPorCodigo(string pCodigo)
        {
            var consulta = from e in Consultar() where e.Codigo.StartsWith(pCodigo, StringComparison.OrdinalIgnoreCase)
                           select new
                           {
                               Codigo = e.Codigo,
                               Año_Compra = e.AxoCompra,
                               Valor_Residual = e.CalcularValorResidual().ToString("0.00"),
                               En_Uso = e.EnUso,
                               Valor_Compra = e.ValorCompra,
                               Fecha_Ingreso = e.FechaIngreso,
                               Fecha_Baja = e.FechaBaja,
                               Dias_En_Empresa = e.CalcularCantidadDiasEnEmpresa()
                           };
            return consulta.ToList<object>();
        }
        public List<object> ConsultarAdded() => _orm.ConsultarAdded();
        public List<object> ConsultarModified() => _orm.ConsultarModified();
        public List<object> ConsultarDeleted() => _orm.ConsultarDeleted();
        public void ConfirmarCambios() => _orm.ConfirmarCambios();
        public void GuardarXml() => _orm.GuardarXml();
    }
}
