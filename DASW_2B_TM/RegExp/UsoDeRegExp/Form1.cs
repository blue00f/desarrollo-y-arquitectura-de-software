using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

namespace UsoDeRegExp
{
    //Regular Exp para fechas:
    // ^(?:(?:31[\/-](?:0?[13578]|1[02])[\/-]\d{4})|(?: 30[\/ -](?:0?[13 - 9] | 1[0 - 2])[\/ -]\d{4})|(?: 29[\/ -](?:0?[1, 3 - 9] | 1[0 - 2])[\/ -]\d{4})|(?: 29[\/ -]0 ? 2[\/ -](?:(?:\d{ 2} (?: 0[48] | [2468][048] | [13579][26]))| (?: [02468][048]00)))|(?: 0?[1 - 9] | 1\d | 2[0 - 8])[\/-] (?: 0?[1 - 9] | 1[0 - 2])[\/ -]\d{4})$
    // Para emails:
    // ^(?:[a-zA-Z0-9_'^&\/+-])+(?:\.(?:[a-zA-Z0-9_'^&\/+-])+)*@(?:(?:[a-zA-Z0-9-]+\.)+[a-zA-Z]{2,}|(?:\[(?:\d{1,3}\.){3}\d{1,3}\]))$
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void txtEntradaExpReg_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Instancia un objeto Regex
                var re = new Regex(txtEntradaExpReg.Text);
                // Busca las coincidencias en el texto y retorna una colección de Match cuyo tipo es MatcheCollection
                var co = re.Matches(txtParrafo.Text);
                txtResultadosDeRegExp.Clear();
                txtResultadosDeRegExp.Text += $"Total de ocurrencias: {co.Count}{Environment.NewLine}{Environment.NewLine}";
                foreach (Match item in co)
                {
                    txtResultadosDeRegExp.Text += $"Indice: {item.Index} - Valor: {item.Value} - Largo: {item.Length}{Environment.NewLine}";
                }
            }
            catch (Exception)
            {
                txtResultadosDeRegExp.Clear();
            }
        }
        private void txtParrafo_TextChanged(object sender, EventArgs e)
        {
            txtEntradaExpReg_TextChanged(null, null);
        }
        private void btnReemplazar_Click(object sender, EventArgs e)
        {
            var p = Interaction.InputBox("Patrón: ", "Patrón de expresión regular");
            var r = Interaction.InputBox("Reemplazo: ", "¿Qué valores desea reemplazar con el patrón?");
            var re = new Regex(p);
            txtParrafo.Text = re.Replace(txtParrafo.Text, r);
        }
    }
}
