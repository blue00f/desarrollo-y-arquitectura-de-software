using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_PrestamoVista
    {
        BLL_Prestamo bllPrestamo;
        public BLL_PrestamoVista()
        {
            bllPrestamo = new BLL_Prestamo();
        }
        public List<object> ConsultaTodosPrestamos()
        {
            var lista = from p in bllPrestamo.ConsultaTodosPrestamos()
                        select new
                        {
                            p.Codigo,
                            p.MontoOtorgado,
                            p.FechaOtorgado,
                            p.Interes,
                            p.InteresPunitorio,
                            p.FechaVencimiento,
                            p.FechaDevolucion,
                            p.MontoDevuelto,
                            Persona = p.Persona.ToString()
                        };
            return lista.ToList<object>();
        }
        public List<object> Consulta(BE_Prestamo pObject) => bllPrestamo.Consulta(pObject).ToList<object>();
        public List<object> ConsultaDesdeHasta(BE_Prestamo pObject1, BE_Prestamo pObject2) => bllPrestamo.ConsultaDesdeHasta(pObject1, pObject2).ToList<object>();
        public List<object> ConsultaIncremental(BE_Prestamo pObject) => bllPrestamo.ConsultaIncremental(pObject).ToList<object>();
    }
}
