using System.Text.RegularExpressions;

namespace ControlesPersonalizados
{
    public partial class ucLegajo : UserControl
    {
        Regex re = new Regex(@"^[A-Z]{2}-[0-9]{3}-[a-z]{2,3}$");
        public ucLegajo()
        {
            InitializeComponent();
        }
        public string RetornarText() => txtLegajo.Text;
        public bool CargarTextBox(string pLegajo)
        {
            bool rdo = false;
            txtLegajo.Text = pLegajo;
            if (!re.IsMatch(txtLegajo.Text))
            {
                txtLegajo.ForeColor = Color.Red;
                rdo = true;
            }
            else txtLegajo.ForeColor = Color.Green;
            return rdo;
        }
        public void txtLegajo_TextChanged(object sender, EventArgs e) => CargarTextBox(txtLegajo.Text);
        public void ucLegajo_Load(object sender, EventArgs e) { }
    }
}
