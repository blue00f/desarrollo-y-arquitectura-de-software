using System.Diagnostics;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAbrirExe_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Ensamblados .NET (*.exe;*.dll)|*.exe;*.dll|Todos los archivos|*.*";
            openFileDialog.Title = "Seleccione un ensamblado para desensamblar";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string archivo = openFileDialog.FileName;
                try
                {
                    string rutaILDASM = "C:\\Program Files (x86)\\Microsoft SDKs\\Windows\\v10.0A\\bin\\NETFX 4.8 Tools\\ildasm.exe";
                    ProcessStartInfo psi = new ProcessStartInfo();
                    psi.FileName = rutaILDASM;
                    psi.Arguments = "\"" + archivo + "\"";
                    psi.UseShellExecute = true;
                    Process.Start(psi);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo ejecutar ILDASM: " + ex.Message);
                }
            }
        }
    }
}
