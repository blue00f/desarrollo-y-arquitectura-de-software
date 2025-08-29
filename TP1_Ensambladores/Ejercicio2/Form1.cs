using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Ejercicio2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string rutaDLL = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Negocio.dll");

        private void btnInstalar_Click(object sender, EventArgs e)
        {
            

            try
            {
                if (!File.Exists(rutaDLL)) throw new Exception("No se encontró Negocio.dll en la carpeta del proyecto");
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "C:\\Program Files (x86)\\Microsoft SDKs\\Windows\\v10.0A\\bin\\NETFX 4.8 Tools\\gacutil.exe";
                psi.Arguments = $"/i \"{rutaDLL}\"";
                psi.RedirectStandardOutput = true;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;

                Process proc = Process.Start(psi);
                string salida = proc.StandardOutput.ReadToEnd();
                proc.WaitForExit();

                MessageBox.Show(salida, "Instalación en GAC");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "C:\\Program Files (x86)\\Microsoft SDKs\\Windows\\v10.0A\\bin\\NETFX 4.8 Tools\\gacutil.exe";
                psi.Arguments = "/l Negocio";
                psi.RedirectStandardOutput = true;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;

                Process proc = Process.Start(psi);
                string salida = proc.StandardOutput.ReadToEnd();
                proc.WaitForExit();

                listBox1.Items.Clear();
                foreach (string line in salida.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                {
                    listBox1.Items.Add(line);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
