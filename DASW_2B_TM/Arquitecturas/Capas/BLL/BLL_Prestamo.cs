using Entidades;
using Interfaces;
using ORM;
namespace BLL
{
    public class BLL_Prestamo : Iabmc<BE_Prestamo>, IDisposable
    {
        ORM_Prestamo _ormpre;
        public BLL_Prestamo()
        {
            _ormpre = new ORM_Prestamo();
        }
        public void Alta(BE_Prestamo pObject) => _ormpre.Alta(pObject);
        public void Baja(BE_Prestamo pObject) => _ormpre.Baja(pObject);
        public void Modificacion(BE_Prestamo pObject) => _ormpre.Modificacion(pObject);
        public List<BE_Prestamo> ConsultaTodosPrestamos() => _ormpre.ConsultaTodosPrestamos();
        public List<BE_Prestamo> Consulta(BE_Prestamo pObject) => _ormpre.Consulta(pObject);
        public List<BE_Prestamo> ConsultaDesdeHasta(BE_Prestamo pObject1, BE_Prestamo pObject2) => _ormpre.ConsultaDesdeHasta(pObject1, pObject2);
        public List<BE_Prestamo> ConsultaIncremental(BE_Prestamo pObject) => _ormpre.ConsultaIncremental(pObject);
        public void Dispose() => _ormpre = null;
    }
}
