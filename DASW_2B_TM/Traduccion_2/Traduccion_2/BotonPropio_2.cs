using Ejemplo_traduccion_01;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo_traduccion_01
{
    public class BotonPropio_2 : System.Windows.Forms.Button, ITraducible
    {
        public BotonPropio_2()
        {
            Size = new System.Drawing.Size(176, 60);
            Visible = true;

        }
        private string identificador;
        [Browsable(true)]
        // Âttribute para categorizar la propiedad en el diseñador
        [Category("Datos")]
        // Attribute para agregar una descripción a la propiedad en el diseñador
        [Description("Obtiene o establece el valor del identificador del control.")]
        // Attribute para controlar la serialización de la propiedad en el diseñador
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Identificador { get => identificador; set => identificador=value; }

        public void Traducir(List<Datos> pListaDatos, Usuario pUsuario)
        {
           this.Text = pListaDatos.Find(x => x.Idioma == pUsuario.Idioma.Id && x.IdBoton == Identificador).Descripcion;
        }
    }
}
