using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ejemplo_traduccion_01;

namespace ContolesPropios
{
    public partial class BotonPersonal: UserControl, ITraducible
    {
        string identificador;
        public string Identificador { get => identificador; set => identificador = value; }

        public BotonPersonal()
        {
            InitializeComponent();
        }

        private void BotonPersonal_Load(object sender, EventArgs e)
        {
            BotonPersonal_Resize(null,null);
        }

        private void BotonPersonal_Resize(object sender, EventArgs e)
        {
            button1.Location = new Point(0, 0);
            button1.Size = Size;
        }

        public void Traducir(List<Datos> pListaDatos, Usuario pUsuario)
        {
          button1.Text= (pListaDatos.Find(x => x.Idioma == pUsuario.Idioma.Id && x.IdBoton==this.Identificador)).Descripcion;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
