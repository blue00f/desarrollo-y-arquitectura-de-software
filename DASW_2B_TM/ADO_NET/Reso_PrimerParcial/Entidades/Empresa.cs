using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reso_PrimerParcial.Entidades
{
    internal class Empresa
    {
        DAO dao;
        public Empresa() { dao = new DAO(); }

        #region "Servicios"
        public bool ExisteEquipo(Equipo pEquipo) => dao.ExisteEquipo(pEquipo);
        public bool ExisteProveedor(Proveedor pProveedor) => dao.ExisteProveedor(pProveedor);
        public void Guardar() => dao.Guardar();
        public void GuardarXML() { dao.GuardarXML(); }
        #endregion

        #region "ABM-C Equipo"
        public void AgregarEquipo(Equipo pEquipo) => dao.AgregarEquipo(pEquipo);
        public void BorrarEquipo(Equipo pEquipo) => dao.BorrarEquipo(pEquipo);
        public void ModificarEquipo(Equipo pEquipo) => dao.ModificarEquipo(pEquipo);
        public List<object> RetornaEquipos()
        {
            return (from eq in dao.RetornaListaEquipos()
                    select new
                    {
                        Código = eq.Codigo,
                        Año_Compra = eq.AxoCompra,
                        Valor_Residual = $"{eq.ValorResidual():N2}",
                        En_uso = eq.EnUso,
                        Valor_Compra = $"{eq.ValorDeCompra:N2}",
                        Fecha_Ingreso = eq.FechaIngreso,
                        Fecha_Baja = eq.FechaBaja,
                        Días_En_Empresa = eq.CantidadDeDiasEnUso()
                    }).ToList<object>();
        }
        public List<object> RetornaEquiposBaja()
        {
            return (from eq in dao.RetornaListaEquipos()
                    orderby eq.CantidadDeDiasEnUso() ascending
                    where eq.EnUso == false
                    select new
                    {
                        Código = eq.Codigo,
                        Año_Compra = eq.AxoCompra,
                        Valor_Residual = $"{eq.ValorResidual():N2}",
                        En_uso = eq.EnUso,
                        Valor_Compra = $"{eq.ValorDeCompra:N2}",
                        Fecha_Ingreso = eq.FechaIngreso,
                        Fecha_Baja = eq.FechaBaja,
                        Días_En_Empresa = eq.CantidadDeDiasEnUso()
                    }).ToList<object>();
        }
        public List<object> RetornaEquiposValorResidual(decimal pDesde, decimal pHasta)
        {
            return (from eq in dao.RetornaListaEquipos()
                    orderby eq.ValorResidual() descending
                    where eq.ValorResidual() >= pDesde && eq.ValorResidual() <= pHasta
                    select new
                    {
                        Código = eq.Codigo,
                        Año_Compra = eq.AxoCompra,
                        Valor_Residual = $"{eq.ValorResidual():N2}",
                        En_uso = eq.EnUso,
                        Valor_Compra = $"{eq.ValorDeCompra:N2}",
                        Fecha_Ingreso = eq.FechaIngreso,
                        Fecha_Baja = eq.FechaBaja,
                        Días_En_Empresa = eq.CantidadDeDiasEnUso()
                    }).ToList<object>();
        }
        public List<object> RetornaEquiposCodigoIncrementral(string pCodigo)
        {
            return (from eq in dao.RetornaListaEquipos()
                    where eq.Codigo.StartsWith(pCodigo)
                    select new
                    {
                        Código = eq.Codigo,
                        Año_Compra = eq.AxoCompra,
                        Valor_Residual = $"{eq.ValorResidual():N2}",
                        En_uso = eq.EnUso,
                        Valor_Compra = $"{eq.ValorDeCompra:N2}",
                        Fecha_Ingreso = eq.FechaIngreso,
                        Fecha_Baja = eq.FechaBaja,
                        Días_En_Empresa = eq.CantidadDeDiasEnUso()
                    }).ToList<object>();
        }
        public List<object> RetornaEquiposInsert()
        {
            return (from eq in dao.RetornaListaEquiposInsert()
                    select new
                    {
                        Código = eq.Codigo,
                        Año_Compra = eq.AxoCompra,
                        Valor_Residual = $"{eq.ValorResidual():N2}",
                        En_uso = eq.EnUso,
                        Valor_Compra = $"{eq.ValorDeCompra:N2}",
                        Fecha_Ingreso = eq.FechaIngreso,
                        Fecha_Baja = eq.FechaBaja,
                        Días_En_Empresa = eq.CantidadDeDiasEnUso()
                    }).ToList<object>();
        }
        public List<object> RetornaEquiposDelete()
        {
            return (from eq in dao.RetornaListaEquiposDelete()
                    select new
                    {
                        Código = eq.Codigo,
                        Año_Compra = eq.AxoCompra,
                        Valor_Residual = $"{eq.ValorResidual():N2}",
                        En_uso = eq.EnUso,
                        Valor_Compra = $"{eq.ValorDeCompra:N2}",
                        Fecha_Ingreso = eq.FechaIngreso,
                        Fecha_Baja = eq.FechaBaja,
                        Días_En_Empresa = eq.CantidadDeDiasEnUso()
                    }).ToList<object>();
        }
        public List<object> RetornaEquiposUpdate()
        {
            return (from eq in dao.RetornaListaEquiposUpdate()
                    select new
                    {
                        Código = eq.Codigo,
                        Año_Compra = eq.AxoCompra,
                        Valor_Residual = $"{eq.ValorResidual():N2}",
                        En_uso = eq.EnUso,
                        Valor_Compra = $"{eq.ValorDeCompra:N2}",
                        Fecha_Ingreso = eq.FechaIngreso,
                        Fecha_Baja = eq.FechaBaja,
                        Días_En_Empresa = eq.CantidadDeDiasEnUso()
                    }).ToList<object>();
        }
        #endregion

        #region "ABM-C Proveedor"
        public void AgregarProveedor(Proveedor pProveedor) => dao.AgregarProveedor(pProveedor);
        public void BorrarProveedor(Proveedor pProveedor) => dao.BorrarProveedor(pProveedor);
        public void ModificarProveedor(Proveedor pProveedor) => dao.ModificarProveedor(pProveedor);
        public List<object> RetornaProveedores()
        {
            return (from pr in dao.RetornaListaProveedores()
                    select new
                    {
                        Id = pr.Id,
                        Nombre = pr.Nombre,
                        Direccion = pr.Direccion
                    }).ToList<object>();
        }
        #endregion

        #region "Asignar Proveedor al Equipo"
        public void AsignarProveedorAlEquipo(EquipoProveedor pEquipoProveedor) => dao.AsignarProveedorAlEquipo(pEquipoProveedor);
        public string RetornaProveedorDelEquipo(Equipo pEquipo) => dao.RetornaProveedorDelEquipo(pEquipo);
        #endregion
    }
}

