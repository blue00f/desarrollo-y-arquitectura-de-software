using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Formularios
{
    public class frmBase : Form
    {
        public void ConfigurarGrilla(DataGridView pGrilla)
        {
            pGrilla.MultiSelect = false;
            pGrilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            pGrilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
