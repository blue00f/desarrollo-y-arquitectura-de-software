using BE;
using Interfaces;
using ORM;

namespace BLL
{
    public class BLL_Socio : IABMC<BE_Socio>
    {
        ORM_Socio _ormsocio;
        ORM_Prestamo _ormprestamo;
        public BLL_Socio()
        {
            _ormsocio = new ORM_Socio();
            _ormprestamo = new ORM_Prestamo();
        }
        public void Agregar(BE_Socio pSocio) => _ormsocio.Agregar(pSocio);

        public void Borrar(BE_Socio pSocio)
        {
            foreach (var p in _ormprestamo.ObtenerDatos())
            {
                if (p.Socio.Id == pSocio.Id) throw new Exception("No se puede borrar porque tiene asociado un préstamo!");
            }
            _ormsocio.Borrar(pSocio);
        }

        public void Modificar(BE_Socio pSocio) => _ormsocio.Modificar(pSocio);

        public List<BE_Socio> ObtenerDatos() => _ormsocio.ObtenerDatos();
        public List<object> ObtenerDatosAnonimos() => ObtenerDatos().ToList<object>();
        public List<object> ObtenerListaFiltrada()
        {
            var lista = from socio in ObtenerDatos()
                        select new {
                            socio.Id,
                            socio.Nombre,
                            socio.Apellido,
                            socio.Localidad,
                            Fecha_Nacimiento = socio.FechaNacimiento.ToShortDateString()
                        };
            return lista.ToList<object>();
        }
        public bool ValidarIdRepetido(BE_Socio pSocio) => _ormsocio.ValidarIdRepetido(pSocio);
    }
}
