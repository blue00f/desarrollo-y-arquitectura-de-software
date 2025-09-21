using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalDemo
{
    internal class CIndicacion
    {
        public void mostrarIndicaciones(RichTextBox infoIndicacion, string nombreHospital)
        {
            try
            {
                CConexion objetoConexion = new CConexion();
                // Se obtiene la indicación para el hospital seleccionado
                String query = "SELECT i.descripcion FROM indicaciones i JOIN hospitales h ON i.hospital = h.idHospital JOIN pacientes p ON i.paciente = p.idPaciente WHERE h.nombre = @nombreHospital AND p.nombre = 'Homero' AND p.apellido = 'Simpsons';";

                MySqlCommand command = new MySqlCommand(query, objetoConexion.establecerConexion());
                command.Parameters.AddWithValue("@nombreHospital", nombreHospital);

                MySqlDataReader reader = command.ExecuteReader();

                infoIndicacion.Clear(); // Limpia el RichTextBox antes de mostrar nuevas indicaciones

                while (reader.Read())
                {
                    // Agrega cada indicación al RichTextBox
                    infoIndicacion.AppendText(reader["descripcion"].ToString() + Environment.NewLine);
                }

                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
