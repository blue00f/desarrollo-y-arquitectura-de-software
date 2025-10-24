using BE;
using Interfaces;
using ORM;

namespace BLL
{
    public class BLL_Socio : IABMC<BE_Socio>
    {
        ORM_Socio _ormsocio;
        public BLL_Socio()
        {
            _ormsocio = new ORM_Socio();
        }
        public void Agregar(BE_Socio pSocio) => _ormsocio.Agregar(pSocio);

        public void Borrar(BE_Socio pSocio)
        {
            if (pSocio.Prestamos.Count != 0) throw new Exception("El socio tiene un préstamo asociado!");
            _ormsocio.Borrar(pSocio);
        }

        public void Modificar(BE_Socio pSocio) => _ormsocio.Modificar(pSocio);

        public List<BE_Socio> ObtenerDatos() => _ormsocio.ObtenerDatos();
        public List<object> ObtenerDatosAnonimos() => ObtenerDatos().ToList<object>();

        public bool ValidarIdRepetido(BE_Socio pSocio) => _ormsocio.ValidarIdRepetido(pSocio);
    }
}
