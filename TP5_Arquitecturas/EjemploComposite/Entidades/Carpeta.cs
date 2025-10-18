using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploComposite.Entidades
{
    internal class Carpeta : ElementoSistema
    {
        List<ElementoSistema> _l;
        public Carpeta(string pNombre) : base(pNombre)
        {
            _l = new List<ElementoSistema>();
        }
        public void Agregar(ElementoSistema pElementoSistema) => _l.Add(pElementoSistema);

        public override void Mostrar(TreeNodeCollection nodos)
        {
            TreeNode nodoCarpeta = new TreeNode(this.Nombre);
            nodos.Add(nodoCarpeta);

            foreach (var elemento in _l)
            {
                elemento.Mostrar(nodoCarpeta.Nodes);
            }
        }
    }
}
