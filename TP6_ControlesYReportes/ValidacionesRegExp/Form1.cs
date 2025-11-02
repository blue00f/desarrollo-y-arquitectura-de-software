using System.Text.RegularExpressions;

namespace ValidacionesRegExp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void LimpiarErrores()
        {
            foreach (var componente in components.Components)
            {
                if (componente is ErrorProvider ep) ep.Clear();
            }
        }
        private bool ValidarTexto(string pCadena, string pExpresionRegular)
        {
            Regex re = new Regex(pExpresionRegular);
            return re.IsMatch(pCadena);
        }
        private void btnValidar_Click(object sender, EventArgs e)
        {
            // Delimitadores de inicio y fin: ^,$
            LimpiarErrores();

            if (!ValidarTexto(textBox1.Text, @"\d{4}-\d{4}")) errorProvider1.SetError(textBox1, "El formato debe ser XXXX-XXXX");
            if (!ValidarTexto(textBox2.Text, @"^[a-zA-Z0-9._]+@[a-zA-Z0-9._]+\.[a-zA-Z]+\.[a-zA-Z]{2,3}$")) errorProvider2.SetError(textBox2, "El formato debe ser Nombre@Dominio.Actividad.pais");
            if (!ValidarTexto(textBox3.Text, @"^\d+$")) errorProvider3.SetError(textBox3, "Escribir solo números");
            if (!ValidarTexto(textBox4.Text, @"^[a-zA-Z]+$")) errorProvider4.SetError(textBox4, "Escribir solo letras");
            if (!ValidarTexto(textBox5.Text, @"(?=.*[a-zA-Z])(?=.*[\d])^[a-zA-Z0-9]+$")) errorProvider5.SetError(textBox5, "Escribir solo números y letras");
            if (!ValidarTexto(textBox6.Text, @"(?=.*[a-zA-Z])(?=.*[\d])(?=.*[!@#$%&*])^[a-zA-Z0-9!@#$%&*]+$")) errorProvider6.SetError(textBox6, "Escribir números, letras y caracteres especiales");

            if (!ValidarTexto(textBox7.Text, @"^[AEIOUaeiou]+$")) errorProvider7.SetError(textBox7, "Escribir solo vocales");
            if (!ValidarTexto(textBox8.Text, @"^[!@#$%&*]+$")) errorProvider8.SetError(textBox8, "Escribir solo caracteres especiales");
            if (!ValidarTexto(textBox9.Text, @"^[^!@#$%&*]+$")) errorProvider9.SetError(textBox9, "Escribir todo menos caracteres especiales");
            if (!ValidarTexto(textBox10.Text, @"^C\d{4}[A-Z]{3}$")) errorProvider10.SetError(textBox10, "El formato debe ser CXXXXYYY");
            if (!ValidarTexto(textBox11.Text, @"^\+54\s?\d{2}\s?\d{4}-?\d{4}$")) errorProvider11.SetError(textBox11, "El formato debe ser +54 11 1234-5678 o +541112345678");
            if (!ValidarTexto(textBox12.Text, @"^(https?:\/\/)?(www\.)?([a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]+)+)(:[0-9]{1,5})?(\/[a-zA-Z0-9\-._~:\/?#[\]@!$&'()*+,;%=]*)?$")) errorProvider12.SetError(textBox12, "Error");
        }
    }
}
