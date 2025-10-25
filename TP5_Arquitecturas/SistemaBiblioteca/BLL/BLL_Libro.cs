using BE;
using Interfaces;
using ORM;

namespace BLL
{
    public class BLL_Libro : IABMC<BE_Libro>
    {
        ORM_Libro _ormlibro;
        ORM_Prestamo _ormprestamo;
        public BLL_Libro()
        {
            _ormlibro = new ORM_Libro();
            _ormprestamo = new ORM_Prestamo();
        }
        public void Agregar(BE_Libro pLibro) => _ormlibro.Agregar(pLibro);
        public void Borrar(BE_Libro pLibro)
        {
            foreach (var p in _ormprestamo.ObtenerDatos())
            {
                if (p.Libro.Id == pLibro.Id) throw new Exception("No se puede borrar porque tiene asociado un préstamo!");
            }
            _ormlibro.Borrar(pLibro);
        }
        public void Modificar(BE_Libro pLibro) => _ormlibro.Modificar(pLibro);
        public List<BE_Libro> ObtenerDatos() => _ormlibro.ObtenerDatos();
        public List<object> ObtenerDatosAnonimos() => ObtenerDatos().ToList<object>();
        public List<object> ObtenerListaFiltrada()
        {
            var lista = from libro in ObtenerDatos() select new { libro.Id, libro.Titulo, libro.Autor };
            return lista.ToList<object>();
        }
        public bool ValidarIdRepetido(BE_Libro pLibro) => _ormlibro.ValidarIdRepetido(pLibro);
    }
}
