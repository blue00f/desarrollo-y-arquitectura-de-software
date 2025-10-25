using BE;
using Interfaces;
using ORM;

namespace BLL
{
    public class BLL_Prestamo : IABMC<BE_Prestamo>
    {
        ORM_Prestamo _ormprestamo;
        public BLL_Prestamo()
        {
            _ormprestamo = new ORM_Prestamo();
        }

        public void Agregar(BE_Prestamo pPrestamo)
        {
            int prestamosDelSocio = 0;
            bool libroYaPrestado = false;

            foreach (var p in _ormprestamo.ObtenerDatos())
            {
                if (p.Socio.Id == pPrestamo.Socio.Id && p.Estado == "En curso") prestamosDelSocio++;
                if (p.Libro.Id == pPrestamo.Libro.Id && p.Estado == "En curso") libroYaPrestado = true;
            }

            if (prestamosDelSocio >= 3) throw new Exception("El socio puede tener hasta 3 préstamos!");
            if (libroYaPrestado) throw new Exception("El libro ya está prestado por otro socio!");

            pPrestamo.Socio.Prestamos.Add(pPrestamo);
            pPrestamo.Libro.Prestamos.Add(pPrestamo);
            _ormprestamo.Agregar(pPrestamo);
        }

        public void Borrar(BE_Prestamo pPrestamo)
        {
            pPrestamo.Socio.Prestamos.Remove(pPrestamo);
            pPrestamo.Libro.Prestamos.Remove(pPrestamo);
            _ormprestamo.Borrar(pPrestamo);
        }

        public void Modificar(BE_Prestamo pPrestamo) => _ormprestamo.Modificar(pPrestamo);

        public List<BE_Prestamo> ObtenerDatos() => _ormprestamo.ObtenerDatos();
        public List<object> ObtenerDatosAnonimos() => ObtenerDatos().ToList<object>();
        public List<object> ObtenerListaFiltrada(BLL_Libro _blllibro, BLL_Socio _bllsocio)
        {
            var lista = from prestamo in ObtenerDatos()
                        join socio in _bllsocio.ObtenerDatos() on prestamo.Socio.Id equals socio.Id
                        join libro in _blllibro.ObtenerDatos() on prestamo.Libro.Id equals libro.Id
                        select new {
                            Id_Prestamo = prestamo.Id,
                            Nombre = socio.Nombre,
                            Apellido = socio.Apellido,
                            Estado = prestamo.Estado,
                            Libro = libro.Titulo,
                            Préstamo = prestamo.FechaPrestamo.ToShortDateString(),
                            Devolución = prestamo.FechaDevolucion.ToShortDateString()
                        };

            return lista.ToList<object>();
        }
        public bool ValidarIdRepetido(BE_Prestamo pPrestamo) => _ormprestamo.ValidarIdRepetido(pPrestamo);
    }
}
