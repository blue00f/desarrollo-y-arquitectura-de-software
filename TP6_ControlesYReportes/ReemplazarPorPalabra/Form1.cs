using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

namespace ReemplazarPorPalabra
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnReemplazar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPalabra.Text.Length == 0) throw new Exception("La palabra está vacía!");
                string reemplazo = Interaction.InputBox($"La palabra a reemplazar es '{txtPalabra.Text}', escriba la nueva palabra:", "Reemplazo");
                Regex re = new Regex(txtPalabra.Text);
                txtBiografia.Text = re.Replace(txtBiografia.Text, reemplazo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
