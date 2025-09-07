using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Formularios
{
    public class frmBase : Form
    {
        protected void ConfigurarGrilla(DataGridView pGrilla)
        {
            pGrilla.MultiSelect = false;
            pGrilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            pGrilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
