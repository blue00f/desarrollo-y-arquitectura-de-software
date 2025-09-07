using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Entidades
{
    internal class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Correo { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public Alumno(int pId, string pNombre, string pApellido, string pDni, string pCorreo, DateTime? pFechaNacimiento)
        {
            Id = pId;
            Nombre = pNombre;
            Apellido = pApellido;
            Dni = pDni;
            Correo = pCorreo;
            FechaNacimiento = pFechaNacimiento;
        }
        public Alumno(object[] pDatos) : this(
            Convert.ToInt16(pDatos[0]),
            Convert.ToString(pDatos[1]),
            Convert.ToString(pDatos[2]),
            Convert.ToString(pDatos[3]),
            Convert.ToString(pDatos[4]),
            pDatos[5] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(pDatos[5])
        ) { }
    }
}
