namespace EjemploMDI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            IsMdiContainer = true;
        }
        Form2[] formularios = new Form2[0];
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.MdiParent = this;
            Array.Resize(ref formularios, formularios.Length + 1);
            formularios[formularios.Length - 1]  = f;
            f.Show();

        }

        private void cerrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in formularios) {item.Close();}
        }
    }
}
