using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Reso_PrimerParcial.Entidades
{
    internal class DAO
    {
        DataSet ds;

        DataTable dtEquipo;
        DataTable dtProveedor;
        DataTable dtEquipoProveedor;

        DataRelation drEq_EqProv;
        DataRelation drProv_EqProv;

        SqlConnection con;
        SqlDataAdapter daEquipo;
        SqlDataAdapter daProveedor;
        SqlDataAdapter daEquipoProveedor;

        SqlCommandBuilder cbEquipo;
        SqlCommandBuilder cbProveedor;
        SqlCommandBuilder cbEquipoProveedor;
        public DAO()
        { 
            ds=new DataSet("DASW_2025_2B_TM");
            dtEquipo = new DataTable("Equipo");
            dtProveedor = new DataTable("Proveedor");
            dtEquipoProveedor = new DataTable("EquipoProveedor");

            con = new SqlConnection("Data Source=.;Initial Catalog=bd_equipos_primerparcial;User ID=administrador;Password=ETN7dolores;Trust Server Certificate=True");
            daEquipo = new SqlDataAdapter("select * from Equipo", con);
            daProveedor = new SqlDataAdapter("select * from Proveedor", con);
            daEquipoProveedor = new SqlDataAdapter("select * from EquipoProveedor", con);

            cbEquipo = new SqlCommandBuilder(daEquipo);
            cbProveedor = new SqlCommandBuilder(daProveedor);
            cbEquipoProveedor = new SqlCommandBuilder(daEquipoProveedor);

            daEquipo.UpdateCommand = cbEquipo.GetUpdateCommand();
            daEquipo.DeleteCommand = cbEquipo.GetDeleteCommand();
            daEquipo.InsertCommand = cbEquipo.GetInsertCommand();

            daProveedor.UpdateCommand = cbProveedor.GetUpdateCommand();
            daProveedor.DeleteCommand = cbProveedor.GetDeleteCommand();
            daProveedor.InsertCommand = cbProveedor.GetInsertCommand();

            daEquipoProveedor.UpdateCommand = cbEquipoProveedor.GetUpdateCommand();
            daEquipoProveedor.DeleteCommand = cbEquipoProveedor.GetDeleteCommand();
            daEquipoProveedor.InsertCommand = cbEquipoProveedor.GetInsertCommand();

            daEquipo.Fill(dtEquipo);
            daProveedor.Fill(dtProveedor);
            daEquipoProveedor.Fill(dtEquipoProveedor);

            dtEquipo.PrimaryKey = new DataColumn[] { dtEquipo.Columns[0] };
            dtProveedor.PrimaryKey = new DataColumn[] { dtProveedor.Columns[0] };
            dtEquipoProveedor.PrimaryKey = new DataColumn[] { dtEquipoProveedor.Columns[0], dtEquipoProveedor.Columns[1] };

            ds.Tables.Add(dtEquipo);
            ds.Tables.Add(dtProveedor);
            ds.Tables.Add(dtEquipoProveedor);

            drEq_EqProv = new DataRelation("Equipo_EquipoProveedor", dtEquipo.Columns[0], dtEquipoProveedor.Columns[0]);
            drProv_EqProv = new DataRelation("Proveedor_EquipoProveedor", dtProveedor.Columns[0], dtEquipoProveedor.Columns[1]);

            ds.Relations.Add(drEq_EqProv);
            ds.Relations.Add(drProv_EqProv);
        }

        #region "Servicios"
        public bool ExisteEquipo(Equipo pEquipo) => dtEquipo.Rows.Find(pEquipo.Codigo) == null ? false : true;
        public bool ExisteProveedor(Proveedor pProveedor) => dtProveedor.Rows.Find(pProveedor.Id) == null ? false : true;
        public void GuardarXML() => ds.WriteXml("Datos.xml", XmlWriteMode.WriteSchema);
        public void Guardar() => Guardar(daEquipo, dtEquipo);
        private void Guardar(SqlDataAdapter pDA, DataTable pDT) => pDA.Update(pDT);
        #endregion

        #region "ABM-C Equipo"
        public void AgregarEquipo(Equipo pEquipo)
        {
            DataRow newRow = dtEquipo.NewRow();
            newRow.ItemArray = pEquipo.RetornaDatosColeccion();
            dtEquipo.Rows.Add(newRow);
        }
        public void BorrarEquipo(Equipo pEquipo)
        {
            DataRow equipo = dtEquipo.Rows.Find(pEquipo.Codigo);
            if (equipo != null)
            {
                DataRow[] hijos = equipo.GetChildRows(drEq_EqProv);
                if (hijos.Length > 0) throw new Exception("No se puede eliminar a un equipo asociado con un proveedor !!!");
                equipo.Delete();
            }
        }
        public void ModificarEquipo(Equipo pEquipo)
        {
            DataRow equipo = dtEquipo.Rows.Find(pEquipo.Codigo);
            if (equipo != null)
            {
                equipo.ItemArray = new object[]
                {
                    equipo.Field<string>(0),
                    pEquipo.FechaIngreso,
                    pEquipo.FechaBaja,
                    pEquipo.AxoCompra,
                    pEquipo.EnUso,
                    pEquipo.ValorDeCompra
                };
            }
        }
        public List<Equipo> RetornaListaEquipos()
        {
            var equipos = new List<Equipo>();
            foreach (DataRow item in dtEquipo.Rows)
            {
                if (item.RowState == DataRowState.Deleted) continue;
                equipos.Add(new Equipo()
                {
                    Codigo = item.Field<string>(0),
                    FechaIngreso = item.Field<DateTime>(1),
                    FechaBaja = item.Field<DateTime>(2),
                    AxoCompra = item.Field<int>(3),
                    EnUso = item.Field<bool>(4),
                    ValorDeCompra = item.Field<Decimal>(5)
                });
            }
            return equipos;
        }
        public List<Equipo> RetornaListaEquiposInsert()
        {
            var equipos = new List<Equipo>();
            foreach (DataRow item in dtEquipo.Rows)
            {
                if (item.RowState == DataRowState.Added) equipos.Add(new Equipo()
                {
                    Codigo = item.Field<string>(0),
                    FechaIngreso = item.Field<DateTime>(1),
                    FechaBaja = item.Field<DateTime>(2),
                    AxoCompra = item.Field<int>(3),
                    EnUso = item.Field<bool>(4),
                    ValorDeCompra = item.Field<Decimal>(5)
                });
            }
            return equipos;
        }
        public List<Equipo> RetornaListaEquiposDelete()
        {
            var equipos = new List<Equipo>();
            foreach (DataRow item in dtEquipo.Rows)
            {
                if (item.RowState == DataRowState.Deleted) equipos.Add(new Equipo()
                { 
                    Codigo = item.Field<string>(0, DataRowVersion.Original),
                    FechaIngreso = item.Field<DateTime>(1, DataRowVersion.Original),
                    FechaBaja = item.Field<DateTime>(2, DataRowVersion.Original),
                    AxoCompra = item.Field<int>(3, DataRowVersion.Original),
                    EnUso = item.Field<bool>(4, DataRowVersion.Original),
                    ValorDeCompra = item.Field<Decimal>(5, DataRowVersion.Original)
                });
            }
            return equipos;
        }
        public List<Equipo> RetornaListaEquiposUpdate()
        {
            var equipos = new List<Equipo>();
            foreach (DataRow item in dtEquipo.Rows)
            {
                if (item.RowState == DataRowState.Modified) equipos.Add(new Equipo()
                {
                    Codigo = item.Field<string>(0),
                    FechaIngreso = item.Field<DateTime>(1),
                    FechaBaja = item.Field<DateTime>(2),
                    AxoCompra = item.Field<int>(3),
                    EnUso = item.Field<bool>(4),
                    ValorDeCompra = item.Field<Decimal>(5)
                });
            }
            return equipos;
        }
        #endregion

        #region "ABM-C Proveedor"
        public void AgregarProveedor(Proveedor pProveedor)
        {
            DataRow newRow = dtProveedor.NewRow();
            newRow.ItemArray = pProveedor.RetornaDatosColeccion();
            dtProveedor.Rows.Add(newRow);
            Guardar(daProveedor, dtProveedor);
        }
        public void BorrarProveedor(Proveedor pProveedor)
        {
            DataRow proveedor = dtProveedor.Rows.Find(pProveedor.Id);

            if (proveedor != null)
            {
                DataRow[] hijos = proveedor.GetChildRows(drProv_EqProv);
                if (hijos.Length > 0) throw new Exception("No se puede eliminar a un proveedor que provee equipos !!!");
                proveedor.Delete();
            }
            Guardar(daProveedor, dtProveedor);
        }
        public void ModificarProveedor(Proveedor pProveedor)
        {
            DataRow proveedor = dtProveedor.Rows.Find(pProveedor.Id);
            if (proveedor != null)
            {
                proveedor.ItemArray = new object[]
                {
                    proveedor.Field<string>(0),
                    pProveedor.Nombre,
                    pProveedor.Direccion,
                };
            }
            Guardar(daProveedor, dtProveedor);
        }
        public List<Proveedor> RetornaListaProveedores()
        {
            var proveedores = new List<Proveedor>();
            foreach (DataRow item in dtProveedor.Rows)
            {
                proveedores.Add(new Proveedor() { Id = item.Field<string>(0), Nombre = item.Field<string>(1), Direccion = item.Field<string>(2) });
            }
            return proveedores;
        }
        #endregion

        #region "Asignar Proveedor al Equipo"
        public void AsignarProveedorAlEquipo(EquipoProveedor pEquipoProveedor)
        {
            DataRow newRow = dtEquipoProveedor.NewRow();
            newRow.ItemArray = new object[]
            {
                pEquipoProveedor.Equipo.Codigo,
                pEquipoProveedor.Proveedor.Id,
                pEquipoProveedor.NombreTecnico
            };
            dtEquipoProveedor.Rows.Add(newRow);
            Guardar(daEquipoProveedor, dtEquipoProveedor);
        }
        public string RetornaProveedorDelEquipo(Equipo pEquipo)
        {
            string s = string.Empty;
            var item = dtEquipo.Rows.Find(pEquipo.Codigo);
            var equipo = new Equipo() { Codigo = item.Field<string>(0), FechaIngreso = item.Field<DateTime>(1), FechaBaja = item.Field<DateTime>(2), AxoCompra = item.Field<int>(3), EnUso = item.Field<bool>(4), ValorDeCompra = item.Field<Decimal>(5) };
            s += $"Código: {equipo.Codigo}{Environment.NewLine}";
            s += $"Fecha de Ingreso: {equipo.FechaIngreso}{Environment.NewLine}";
            s += $"Fecha de baja: {equipo.FechaBaja}{Environment.NewLine}";
            s += $"Año de compra: {equipo.AxoCompra}{Environment.NewLine}";
            s += $"En uso: {equipo.EnUso}{Environment.NewLine}";
            s += $"Valor de compra: {equipo.ValorDeCompra}{Environment.NewLine}";
            s += $"Valor residual: {equipo.ValorResidual():N2}{Environment.NewLine}";
            s += $"Días en empresa: {equipo.CantidadDeDiasEnUso()}{Environment.NewLine}";
            s += $"-------------------------------------{Environment.NewLine}";
            // Ahora las filas hijas de la tabla intermedia
            var filasHijas = item.GetChildRows(drEq_EqProv);
            s += $"PROVEEDORES{Environment.NewLine}";
            s += $"-------------------------------------{Environment.NewLine}";
            foreach (var fila in filasHijas)
            {
                //var proveedor = dtProveedor.Rows.Find(fila.Field<string>(1));
                var proveedor = fila.GetParentRow(drProv_EqProv);
                s += $"Id: {proveedor.Field<string>(0)}{Environment.NewLine}";
                s += $"Nombre: {proveedor.Field<string>(1)}{Environment.NewLine}";
                s += $"Dirección: {proveedor.Field<string>(2)}{Environment.NewLine}";
                s += $"Técnico: {fila.Field<string>(2)}{Environment.NewLine}";
                s += $"-------------------------------------{Environment.NewLine}";
            }
            return s;
        }
        #endregion
    }
}
