using BE;
using DAL;
using Interfaces;
using System.Data;

namespace ORM
{
    public class ORM_Empleado : IABMC<BE_Empleado>
    {
        DAO dao;
        const string tabla = "empleado";
        public ORM_Empleado() => dao = new DAO();

        public void Agregar(BE_Empleado pObjeto) => dao.Agregar(tabla, pObjeto.Legajo, pObjeto.Nombre, pObjeto.Apellido, pObjeto.FechaIngreso);

        public void Borrar(BE_Empleado pObjeto) => dao.Borrar(tabla, pObjeto.Legajo);
        public void Modificar(BE_Empleado pObjeto)
        {
            DataTable dt = dao.Consultar(tabla);
            DataRow fila = dt.Rows.Find(pObjeto.Legajo);
            if (fila != null)
            {
                fila[1] = pObjeto.Nombre;
                fila[2] = pObjeto.Apellido;
                fila[3] = pObjeto.FechaIngreso;
                dao.Actualizar(tabla);
            }
        }
        public List<BE_Empleado> Consultar()
        {
            DataTable dt = dao.Consultar(tabla);
            var empleados = new List<BE_Empleado>();
            foreach (DataRow f in dt.Rows)
            {
                empleados.Add(new BE_Empleado(
                    f.Field<string>(0),
                    f.Field<string>(1),
                    f.Field<string>(2),
                    f.Field<DateTime>(3)
                ));
            }
            return empleados;
        }
        public bool ValidarCodigoRepetido(BE_Empleado pObjeto)
        {
            bool rdo = false;
            foreach (var e in Consultar())
            {
                if (e.Legajo == pObjeto.Legajo) rdo = true;
            }
            return rdo;
        }
        public BE_Empleado? RecuperarEmpleadoPorCodigo(string pCodigo)
        {
            BE_Empleado empleado = null;
            foreach (var e in Consultar())
            {
                if (e.Legajo == pCodigo) empleado = e;
            }
            return empleado;
        }
    }
}
