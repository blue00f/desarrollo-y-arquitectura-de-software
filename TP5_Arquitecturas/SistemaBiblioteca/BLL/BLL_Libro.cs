using BE;
using Interfaces;
using ORM;

namespace BLL
{
    public class BLL_Libro : IABMC<BE_Libro>
    {
        ORM_Libro _ormlibro;
        public BLL_Libro()
        {
            _ormlibro = new ORM_Libro();
        }
        public void Agregar(BE_Libro pLibro) => _ormlibro.Agregar(pLibro);
        public void Borrar(BE_Libro pLibro)
        {
            if (pLibro.Prestamos.Count != 0) throw new Exception("El libro está en préstamo");
            _ormlibro.Borrar(pLibro);
        }
        public void Modificar(BE_Libro pLibro) => _ormlibro.Modificar(pLibro);
        public List<BE_Libro> ObtenerDatos() => _ormlibro.ObtenerDatos();
        public List<object> ObtenerDatosAnonimos() => ObtenerDatos().ToList<object>();
        public bool ValidarIdRepetido(BE_Libro pLibro) => _ormlibro.ValidarIdRepetido(pLibro);
    }
}
