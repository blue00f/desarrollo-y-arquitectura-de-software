using System.Text.RegularExpressions;

namespace UsoGroup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            lstGrupoFecha.Items.Clear();
            string patron = @"^(?:(?:0?[1-9]|[12][0-9]|3[01])[\/-](?:0?[13578]|1[02])[\/-]\d{4}|" +  // 31 días meses con 31
                             @"(?:0?[1-9]|[12][0-9]|30)[\/-](?:0?[13456789]|1[0-2])[\/-]\d{4}|" +      // 30 días meses con 30
                             @"(?:0?[1-9]|1[0-9]|2[0-8])[\/-]0?2[\/-]\d{4}|" +                           // Febrero días 1-28
                             @"29[\/-]0?2[\/-](?:(?:\d{2}(?:0[48]|[2468][048]|[13579][26]))|(?:[02468][048]00)))$"; // 29 Feb bisiestos

            Regex re = new Regex(patron);
            Match match = re.Match(txtFecha.Text);
            if (match.Success)
            {
                for (int i = 0; i < match.Groups.Count; i++)
                {
                    lstGrupoFecha.Items.Add($"{match.Groups[i].Value}");
                    lstGrupoFecha.Items.Add($"Longitud: {match.Groups[i].Length}");
                    lstGrupoFecha.Items.Add($"Índice: {match.Groups[i].Index}");
                }
            }
        }
    }
}
