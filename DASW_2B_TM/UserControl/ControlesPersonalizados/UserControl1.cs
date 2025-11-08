using System;
using System.ComponentModel;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Controles_personalizados
{
    public partial class NumericTextBox : UserControl
    {
        public NumericTextBox()
        {
            InitializeComponent();
            this.Load += (sender, e) =>
            {
                textBox1.Width = this.Width;
                textBox1.Height = this.Height;
                textBox1.Location = new System.Drawing.Point(0, 0);
            };
        }

        private void NumericTextBox_Load1(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        // Propiedad pública para acceder al valor numérico
        [Browsable(true)]
        [Category("Datos")]
        [Description("Obtiene o establece el valor numérico del control.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Valor
        {
            get => textBox1.Text;
            set => textBox1.Text = value;
        }

        // Solo permite dígitos y teclas de control
        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo un punto decimal
            if (textBox1.Text.Contains('.') && e.KeyChar == 46) { e.Handled = true; }
            else
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != 46)
                {
                    e.Handled = true; // bloquea el carácter
                }
                //validar cantidad de decimales
                else if (textBox1.Text.Contains('.') && char.IsDigit(e.KeyChar))
                {
                    if (textBox1.Text.Split('.')[1].Length >= cantidadDecimal)
                        e.Handled = true;
                    else
                        e.Handled = false;
                }
            }   
        }

        // Ejemplo de validación visual (fondo rojo si no es válido)
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBox1.Text, out _))
                textBox1.BackColor = System.Drawing.Color.White;
            else
                textBox1.BackColor = System.Drawing.Color.MistyRose;
        }

        private int cantidadDecimal = 0;

        [Browsable(true)]
        [Category("Datos")]
        [Description("Obtiene o establece la cantidad de caracteres decimales que puede poseer el número.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CantidadDecimales
        {
            get => cantidadDecimal;
            set => cantidadDecimal = value<0 ? 0 : value;
        }

        [Browsable(true)]
        [Category("Datos")]
        [Description("Obtiene o establece las características del Font.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Font Letra
        {
            get => textBox1.Font;
            set => textBox1.Font = value;
        }

        [Browsable(true)]
        [Category("Datos")]
        [Description("Obtiene o establece el color de la letra.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color ColorLetra
        {
            get => textBox1.ForeColor;
            set => textBox1.ForeColor = value;
        }

        private void NumericTextBox_Resize(object sender, EventArgs e)
        {
            this.OnLoad(null);

        }

      
    }
}