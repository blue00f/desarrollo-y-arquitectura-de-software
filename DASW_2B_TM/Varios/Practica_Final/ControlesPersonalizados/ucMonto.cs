using System.Text.RegularExpressions;

namespace ControlesPersonalizados
{
    public partial class ucMonto : UserControl
    {
        Regex re = new Regex(@"^[0-9]+$");
        public ucMonto()
        {
            InitializeComponent();
        }
        public string RetornarText() => txtMonto.Text; 
        private void txtMonto_TextChanged(object sender, EventArgs e) => ValidarTextBox();
        public bool ValidarTextBox()
        {
            bool rdo = false;
            if (!re.IsMatch(txtMonto.Text))
            {
                txtMonto.ForeColor = Color.Red;
                rdo = true;
            }
            else txtMonto.ForeColor = Color.Green;
            return rdo;
        }
        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e) { }
    }
}
