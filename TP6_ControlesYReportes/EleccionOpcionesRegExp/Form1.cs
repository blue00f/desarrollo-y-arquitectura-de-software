using System.Text.RegularExpressions;

namespace EleccionOpcionesRegExp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private enum OpcionesValidacion
        {
            Correo,
            CodigoPostal,
            Telefono,
            SoloLetras
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cbxOpciones.DataSource = Enum.GetValues(typeof(OpcionesValidacion));
            cbxOpciones.SelectedIndex = 0;
        }
        private void btnValidar_Click(object sender, EventArgs e)
        {
            var opcion = (OpcionesValidacion)cbxOpciones.SelectedItem;
            string patron = "";

            switch (opcion)
            {
                case OpcionesValidacion.Correo:
                    patron = @"^[a-zA-Z0-9._]+@[a-zA-Z0-9._]+\.[a-zA-Z]+\.[a-zA-Z]{2,3}$";
                    break;
                case OpcionesValidacion.CodigoPostal:
                    patron = @"^C\d{4}[A-Z]{3}$";
                    break;
                case OpcionesValidacion.Telefono:
                    patron = @"^\d{4}\-?\d{4}$";
                    break;
                case OpcionesValidacion.SoloLetras:
                    patron = @"^[a-zA-Z]+$";
                    break;
            }

            var re = new Regex(patron);
            if (!re.IsMatch(txtTexto.Text)) errorProvider1.SetError(txtTexto, "Valor inválido para la opción seleccionada");
            else errorProvider1.Clear();
        }
    }
}
