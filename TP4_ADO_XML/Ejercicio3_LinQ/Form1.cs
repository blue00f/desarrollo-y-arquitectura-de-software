using Microsoft.VisualBasic;
using System.Xml.Linq;

namespace Ejercicio3_LinQ
{
    public partial class Form1 : Form
    {
        XDocument doc;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            grillaJuegos.MultiSelect = false;
            grillaJuegos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grillaJuegos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (File.Exists("juegos.xml")) doc = XDocument.Load("juegos.xml");
            else doc = new XDocument(new XElement("juegos"));
            Mostrar();
        }
        private void Mostrar()
        {
            var juegos = from juego in doc.Descendants("juego")
                         select new
                         {
                             Id = (int)juego.Element("id"),
                             Nombre = (string)juego.Element("nombre"),
                             Lanzamiento = (DateTime)juego.Element("lanzamiento"),
                             EsOnline = (bool)juego.Element("esOnline"),
                             Empresa = (string)juego.Element("empresa"),
                             HorasJugadas = (int)juego.Element("horasJugadas")

                         };
            grillaJuegos.DataSource = null;
            grillaJuegos.DataSource = juegos.ToList();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int nuevoId = doc.Descendants("juego").Count() + 1;
            XElement nuevoJuego = new XElement("juego",
               new XElement("id", nuevoId),
               new XElement("nombre", Interaction.InputBox("Ingrese nombre del juego:", "Agregar")),
               new XElement("lanzamiento", Interaction.InputBox("Ingrese fecha de lanzamiento (AAAA-MM-DD):", "Agregar")),
               new XElement("esOnline", MessageBox.Show("¿Es online?", "Agregar", MessageBoxButtons.YesNo) == DialogResult.Yes),
               new XElement("empresa", Interaction.InputBox("Ingrese empresa desarrolladora:", "Agregar")),
               new XElement("horasJugadas", Convert.ToInt32(Interaction.InputBox("Ingrese horas jugadas:", "Agregar")))
            );
            doc.Root.Add(nuevoJuego);
            doc.Save("juegos.xml");
            Mostrar();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaJuegos.Rows.Count == 0) throw new Exception("No hay juegos para borrar!");
                int idSeleccionado = (int)grillaJuegos.SelectedRows[0].Cells[0].Value;
                var juego = doc.Descendants("juego").FirstOrDefault(x => (int)x.Element("id") == idSeleccionado);
                if (juego != null)
                {
                    juego.Remove();
                    doc.Save("juegos.xml");
                    Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (grillaJuegos.Rows.Count == 0) throw new Exception("No hay juegos para borrar!");
                int idSeleccionado = (int)grillaJuegos.CurrentRow.Cells[0].Value;
                var juego = doc.Descendants("juego").FirstOrDefault(x => (int)x.Element("id") == idSeleccionado);
                if (juego != null)
                {
                    juego.SetElementValue("nombre", Interaction.InputBox("Ingrese nombre del juego:", "Modificar", (string)juego.Element("nombre")));
                    juego.SetElementValue("lanzamiento", Interaction.InputBox("Ingrese fecha de lanzamiento (AAAA-MM-DD):", "Modificar", (string)juego.Element("lanzamiento")));
                    juego.SetElementValue("esOnline", MessageBox.Show("¿Es online?", "Modificar", MessageBoxButtons.YesNo) == DialogResult.Yes);
                    juego.SetElementValue("empresa", Interaction.InputBox("Ingrese empresa desarrolladora:", "Modificar", (string)juego.Element("empresa")));
                    juego.SetElementValue("horasJugadas", Convert.ToInt32(Interaction.InputBox("Ingrese horas jugadas:", "Modificar", juego.Element("horasJugadas").Value)));
                    doc.Save("juegos.xml");
                    Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSalir_Click(object sender, EventArgs e) => Application.Exit();
    }
}
