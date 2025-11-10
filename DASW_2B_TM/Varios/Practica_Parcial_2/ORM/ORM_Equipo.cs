using BE;
using Interfaces;
using DAL;
using System.Data;
namespace ORM
{
    public class ORM_Equipo : IABMC<BE_Equipo>
    {
        DAO _dao;
        const string tabla = "equipo";
        public ORM_Equipo() => _dao = new DAO();
        public void Agregar(BE_Equipo pObjeto) => _dao.Agregar(tabla, pObjeto.Codigo, pObjeto.FechaIngreso, pObjeto.FechaBaja, pObjeto.AxoCompra, pObjeto.EnUso, pObjeto.ValorCompra);
        public void Borrar(BE_Equipo pObjeto) => _dao.Borrar(tabla, pObjeto.Codigo);
        public void Modificar(BE_Equipo pObjeto)
        {
            DataTable dt = _dao.Consultar(tabla);
            DataRow fila = dt.Rows.Find(pObjeto.Codigo);
            if (fila != null)
            {
                fila[1] = pObjeto.FechaIngreso;
                fila[2] = pObjeto.FechaBaja;
                fila[3] = pObjeto.AxoCompra;
                fila[4] = pObjeto.EnUso;
                fila[5] = pObjeto.ValorCompra;
            }
        }
        public List<BE_Equipo> Consultar()
        {
            DataTable dt = _dao.Consultar(tabla);
            var equipos = new List<BE_Equipo>();
            foreach (DataRow f in dt.Rows)
            {
                if (f.RowState != DataRowState.Unchanged) continue;
                equipos.Add(new BE_Equipo(
                        f.Field<string>(0),
                        f.Field<DateTime>(1),
                        f.Field<DateTime>(2),
                        f.Field<int>(3),
                        f.Field<bool>(4),
                        f.Field<decimal>(5)
                ));
            }
            return equipos;
        }
        public bool ValidarCodigoRepetido(BE_Equipo pObjeto)
        {
            bool rdo = false;
            foreach (var e in Consultar())
            {
                if (pObjeto.Codigo == e.Codigo) rdo = true;
            }
            return rdo;
        }
        public void ConfirmarCambios() => _dao.Actualizar(tabla);
        public List<object> ConsultarAdded()
        {
            DataTable dt = _dao.Consultar(tabla);
            var consulta = from DataRow f in dt.Rows
                           where f.RowState == DataRowState.Added
                           select new
                           {
                               Codigo = f.Field<string>(0),
                               Fecha_Ingreso = f.Field<DateTime>(1),
                               Fecha_Baja = f.Field<DateTime>(2),
                               Año_Compra = f.Field<int>(3),
                               En_Uso = f.Field<bool>(4),
                               Valor_Compra = f.Field<decimal>(5)
                           };
            return consulta.ToList<object>();
        }
        public List<object> ConsultarModified()
        {
            DataTable dt = _dao.Consultar(tabla);
            var consulta = from DataRow f in dt.Rows
                           where f.RowState == DataRowState.Modified
                           select new
                           {
                               Codigo = f.Field<string>(0, DataRowVersion.Current),
                               Fecha_Ingreso = f.Field<DateTime>(1, DataRowVersion.Current),
                               Fecha_Baja = f.Field<DateTime>(2, DataRowVersion.Current),
                               Año_Compra = f.Field<int>(3, DataRowVersion.Current),
                               En_Uso = f.Field<bool>(4, DataRowVersion.Current),
                               Valor_Compra = f.Field<decimal>(5, DataRowVersion.Current)
                           };
            return consulta.ToList<object>();
        }
        public List<object> ConsultarDeleted()
        {
            DataTable dt = _dao.Consultar(tabla);
            var consulta = from DataRow f in dt.Rows
                           where f.RowState == DataRowState.Deleted
                           select new
                           {
                               Codigo = f.Field<string>(0, DataRowVersion.Original),
                               Fecha_Ingreso = f.Field<DateTime>(1, DataRowVersion.Original),
                               Fecha_Baja = f.Field<DateTime>(2, DataRowVersion.Original),
                               Año_Compra = f.Field<int>(3, DataRowVersion.Original),
                               En_Uso = f.Field<bool>(4, DataRowVersion.Original),
                               Valor_Compra = f.Field<decimal>(5, DataRowVersion.Original)
                           };
            return consulta.ToList<object>();
        }
        public void GuardarXml() => _dao.GuardarXml();
    }
}
