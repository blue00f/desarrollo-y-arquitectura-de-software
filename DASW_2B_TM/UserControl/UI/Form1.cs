using Controles_personalizados;
namespace EJ_01_US_CTR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            var x = new NumericTextBox();
            x.Visible = true;
            x.Size = new Size(200, 50);
            this.Controls.Add(x);
            numericUpDown1.Value = numericTextBox2.CantidadDecimales;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            numericTextBox2.Limpiar();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericTextBox2.CantidadDecimales = (int)numericUpDown1.Value;
        }
    }
}
