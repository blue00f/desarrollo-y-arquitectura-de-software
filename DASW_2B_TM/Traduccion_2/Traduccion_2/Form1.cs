using ControlesPropios;
using Ejemplo_traduccion_01;

namespace Traduccion_2
{
    public partial class Form1 : Form
    {
        List<Idioma> li;
        List<Datos> datos;
        Usuario u1, u2, u3;
        public Form1()
        {
            InitializeComponent();
            li = new List<Idioma>();
            datos = new List<Datos>();
            radioButton1.CheckedChanged += PrepararUsuario;
            radioButton2.CheckedChanged += PrepararUsuario;
            radioButton3.CheckedChanged += PrepararUsuario;
        }

       
        private void PrepararUsuario(object sender, EventArgs e)
        {
            Usuario usuario = u1;
            if (radioButton2.Checked) usuario = u2;
            if (radioButton3.Checked) usuario = u3;
            Traducir(usuario);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Esto llega desde la BLL
            li.AddRange(new Idioma[] { new Idioma() {Id=1,Descripcion="Español"},
                                       new Idioma() {Id=2,Descripcion="Inglés"},
                                       new Idioma() {Id=3,Descripcion="Italiano"}});
            datos.AddRange(new Datos[] {new Datos(){Idioma=1,IdBoton="B01",Descripcion="Alta"},
                                        new Datos(){Idioma=2,IdBoton="B01",Descripcion="Add"},
                                        new Datos(){Idioma=3,IdBoton="B01",Descripcion="Aggiungere"},
                                        new Datos(){Idioma=1,IdBoton="B02",Descripcion="Baja"},
                                        new Datos(){Idioma=2,IdBoton="B02",Descripcion="Delete"},
                                        new Datos(){Idioma=3,IdBoton="B02",Descripcion="Cancellare"},
                                        new Datos(){Idioma=1,IdBoton="B03",Descripcion="Modificar"},
                                        new Datos(){Idioma=2,IdBoton="B03",Descripcion="Edit"},
                                        new Datos(){Idioma=3,IdBoton="B03",Descripcion="Modificare"},
                                        new Datos(){Idioma=1,IdBoton="BP01",Descripcion="Testeo"},
                                        new Datos(){Idioma=2,IdBoton="BP01",Descripcion="Test"},
                                        new Datos(){Idioma=3,IdBoton="BP01",Descripcion="Testeare"} });
            u1 = new Usuario() { DNI = "30.405.765", Nombre = "Ana", Idioma = li.Find(x => x.Id == 1) };
            u2 = new Usuario() { DNI = "40.103.269", Nombre = "Juan", Idioma = li.Find(x => x.Id == 2) };
            u3 = new Usuario() { DNI = "18.404.987", Nombre = "Sol", Idioma = li.Find(x => x.Id == 3) };
            
            botonPersonal1.Identificador = "B01";
            botonPersonal2.Identificador = "B02";
            botonPersonal3.Identificador = "B03";

            BotonPropio_2 bb = new BotonPropio_2();
            Controls.Add(bb);
            bb.Location = new Point(100, 210);
            bb.Identificador = "BP01";

            Traducir(u1);
        }
        private void Traducir(Usuario pU)
        {
            foreach (var c in Controls)
            {
                if (c is ITraducible) (c as ITraducible).Traducir(datos, pU);
            }
        }
    }
}
