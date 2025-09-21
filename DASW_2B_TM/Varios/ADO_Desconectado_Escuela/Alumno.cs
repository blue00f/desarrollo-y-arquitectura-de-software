using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    internal class Alumno
    {
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public Alumno (int legajo, string nombre, string apellido)
        {
            Legajo = legajo;
            Nombre = nombre;
            Apellido = apellido;
        }
        public Alumno(object[] pDatos) : this
        (
            Convert.ToInt32(pDatos[0]),
            Convert.ToString(pDatos[1]),
            Convert.ToString(pDatos[2])
        ) { }
    }
}
