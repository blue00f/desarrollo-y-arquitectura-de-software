using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio3
{
    public partial class frmVistaUsuario : Form
    {
        public frmVistaUsuario()
        {
            InitializeComponent();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            frmLogin login = Application.OpenForms.OfType<frmLogin>().FirstOrDefault();
            if (login != null) login.Show();
            this.Close();
        }
    }
}
