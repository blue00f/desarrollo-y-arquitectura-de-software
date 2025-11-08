using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo_traduccion_01
{
    public interface ITraducible
    {
        void Traducir(List<Datos> pListaDatos, Usuario pUsuario);
        string Identificador { get; set; }
    }
}
