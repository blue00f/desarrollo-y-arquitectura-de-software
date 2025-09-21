using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalDemo
{
    public partial class Indicaciones : Form
    {
        public Indicaciones(string nombreHospital)
        {
            InitializeComponent();
            label1.Text = $"Indicaciones del {nombreHospital}";
            CIndicacion objetoIndicacion = new CIndicacion();
            objetoIndicacion.mostrarIndicaciones(richTextBox1, nombreHospital);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
