using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reportes1.Entidades
{
    internal class Alumno
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Localidad { get; set; }
        public Alumno (string pNombre, string pApellido, DateTime pFechaNacimiento, string pLocalidad)
        {
            Nombre = pNombre;
            Apellido = pApellido;
            FechaNacimiento = pFechaNacimiento;
            Localidad = pLocalidad;
        }
    }
}
