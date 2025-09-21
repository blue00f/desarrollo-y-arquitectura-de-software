using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ejemplo1
{
    public partial class Form1 : Form
    {
        string rutaXml = Path.GetFullPath(Path.Combine(Application.StartupPath, @"C:\Users\Blue\source\repos\DAS\DASW_2B_TM\Varios\Ejemplo1\datos.xml"));

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe", rutaXml);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(rutaXml) { UseShellExecute = true });
        }
    }
}
