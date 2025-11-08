using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejemplo_traduccion_01;

namespace Ejemplo_traduccion_01
{
    public class BotonPropio_2 : System.Windows.Forms.Button, ITraducible
    {
        public BotonPropio_2()
        {
            Size = new System.Drawing.Size(100, 50);
            Visible = true;

        }
        private string identificador;
        public string Identificador { get => identificador; set => identificador=value; }

       

        public void Traducir(List<Datos> pListaDatos, Usuario pUsuario)
        {
           this.Text = pListaDatos.Find(x => x.Idioma == pUsuario.Idioma.Id && x.IdBoton == Identificador).Descripcion;
        }
    }
}
