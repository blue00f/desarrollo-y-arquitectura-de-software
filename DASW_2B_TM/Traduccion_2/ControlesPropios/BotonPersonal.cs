using Ejemplo_traduccion_01;
using System.ComponentModel;

namespace ControlesPropios
{
    public partial class BotonPersonal : UserControl, ITraducible
    {
        string identificador;

        [Browsable(true)]
        // Âttribute para categorizar la propiedad en el diseñador
        [Category("Datos")]
        // Attribute para agregar una descripción a la propiedad en el diseñador
        [Description("Obtiene o establece el valor del identificador del control.")]
        // Attribute para controlar la serialización de la propiedad en el diseñador
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Identificador { get => identificador; set => identificador = value; }

        public BotonPersonal()
        {
            InitializeComponent();
            this.Resize += (sender, e) =>
             {
                 button1.Location = new Point(0, 0);
                 button1.Size = this.Size;
             };
            this.Load += (sender, e) => this.OnResize(null);
        }

        public void Traducir(List<Datos> pListaDatos, Usuario pUsuario)
        {
            button1.Text = (pListaDatos.Find(x => x.Idioma == pUsuario.Idioma.Id && x.IdBoton == this.Identificador)).Descripcion;
        }

        private void BotonPersonal_Load(object sender, EventArgs e)
        {

        }
    }
}
