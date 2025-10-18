using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploComposite.Entidades
{
    public class Archivo : ElementoSistema
    {
        public Archivo(string pNombre) : base(pNombre) { }
        public override void Mostrar(TreeNodeCollection nodos)
        {
            nodos.Add(this.Nombre);
        }
    }
}
