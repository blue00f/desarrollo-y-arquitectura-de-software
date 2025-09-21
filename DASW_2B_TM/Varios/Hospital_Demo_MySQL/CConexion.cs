using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDemo
{
    internal class CConexion
    {
        MySqlConnection conex = new MySqlConnection();
        static string servidor = "localhost";
        static string bd = "gestorDeIndicaciones";
        static string usuario = "root";
        static string password = "ETN7dolores";
        static string port = "3306";
        string cadenaConexion = $"server={servidor}; port={port}; user id={usuario}; password={password}; database={bd}";

        public MySqlConnection establecerConexion()
        {
            try
            {
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                //MessageBox.Show("Se conectó a la base de datos");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return conex;
        }
        public void cerrarConexion()
        {
            conex.Close();
        }
    }
}
