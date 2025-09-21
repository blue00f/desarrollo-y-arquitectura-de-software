using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDemo
{
    internal class CHospital
    {
        public void mostrarHospitales(ListBox listaHospitales) 
        {
			try
			{
				CConexion objetoConexion = new CConexion();
				// Se muestran los hospitales donde hayan indicaciones para el paciente Homero Simpsons
				String query = "SELECT h.nombre FROM hospitales h JOIN indicaciones i ON h.idHospital = i.hospital JOIN pacientes p ON i.paciente = p.idPaciente WHERE p.nombre = 'Homero' AND p.apellido = 'Simpsons';";
				listaHospitales.DataSource = null;
				MySqlDataAdapter adapter = new MySqlDataAdapter(query, objetoConexion.establecerConexion());
				DataTable dt = new DataTable();
				adapter.Fill(dt);
				listaHospitales.DataSource = dt;
                listaHospitales.DisplayMember = "Nombre";
                objetoConexion.cerrarConexion();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
        }
    }
}
