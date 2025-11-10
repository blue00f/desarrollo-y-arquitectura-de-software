using BE;
using Interfaces;
using ORM;

namespace BLL
{
    public class BLL_Empleado : IABMC<BE_Empleado>
    {
        ORM_Empleado orm;
        public BLL_Empleado() => orm = new ORM_Empleado();
        public void Agregar(BE_Empleado pObjeto) => orm.Agregar(pObjeto);
        public void Borrar(BE_Empleado pObjeto) => orm.Borrar(pObjeto);
        public void Modificar(BE_Empleado pObjeto) => orm.Modificar(pObjeto);
        public List<BE_Empleado> Consultar() => orm.Consultar();
        public bool ValidarCodigoRepetido(BE_Empleado pObjeto) => orm.ValidarCodigoRepetido(pObjeto);
        public BE_Empleado? RecuperarEmpleadoPorCodigo(string pCodigo) => orm.RecuperarEmpleadoPorCodigo(pCodigo);
        public List<object> ConsultaPersonalizada()
        {
            var consulta = from e in Consultar()
                           select new
                           {
                               Legajo = e.Legajo,
                               Nombre = e.Nombre,
                               Apellido = e.Apellido,
                               Fecha_de_Ingreso = e.FechaIngreso,
                               Antiguedad = e.CalcularAntiguedadEnAxos()
                           };
            return consulta.ToList<object>();
        }
        public List<object> ConsultaIncrementalPorApellido(string pApellido)
        {
            var consulta = from e in Consultar()
                           where e.Apellido.StartsWith(pApellido, StringComparison.CurrentCultureIgnoreCase)
                           select new
                           {
                               Legajo = e.Legajo,
                               Nombre = e.Nombre,
                               Apellido = e.Apellido,
                               Fecha_de_Ingreso = e.FechaIngreso,
                               Antiguedad = e.CalcularAntiguedadEnAxos()
                           };
            return consulta.ToList<object>();
        }
    }
}
