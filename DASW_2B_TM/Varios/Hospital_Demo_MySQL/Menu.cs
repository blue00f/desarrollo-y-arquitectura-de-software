using System.Data;
using System.Windows.Forms;

namespace HospitalDemo
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            CHospital objetoHospital = new CHospital();
            objetoHospital.mostrarHospitales(lstHospitales);
        }

        private void lstHospitales_DoubleClick(object sender, EventArgs e)
        {
            if (lstHospitales.SelectedItem != null)
            {
                // Obtiene el DataRowView del elemento seleccionado
                DataRowView selectedRow = (DataRowView)lstHospitales.SelectedItem;

                // Extrae el nombre del hospital de la columna correspondiente
                string nombreHospital = selectedRow["nombre"].ToString(); // Cambia "nombre" al nombre real de la columna si es necesario

                // Crea una instancia del nuevo formulario
                Indicaciones formIndicaciones = new Indicaciones(nombreHospital);

                // Muestra el formulario
                formIndicaciones.ShowDialog();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
