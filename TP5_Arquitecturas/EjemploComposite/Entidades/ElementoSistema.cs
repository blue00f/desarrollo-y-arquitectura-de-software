using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploComposite.Entidades
{
    public abstract class ElementoSistema
    {
        public string Nombre { get; set; }
        public ElementoSistema(string pNombre)
        {
            Nombre = pNombre;
        }
        public abstract void Mostrar(TreeNodeCollection nodos);
    }
}
