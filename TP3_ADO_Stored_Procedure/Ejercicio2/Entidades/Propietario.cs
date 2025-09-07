using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Entidades
{
    internal class Propietario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Domicilio { get; set; }
        public Propietario(int id, string nombre, string apellido, string dni, string domicilio)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            Domicilio = domicilio;
        }
        public Propietario(object[] pDatos) : this(
            Convert.ToInt16(pDatos[0]),
            Convert.ToString(pDatos[1]),
            Convert.ToString(pDatos[2]),
            Convert.ToString(pDatos[3]),
            Convert.ToString(pDatos[4])
        ) { }
    }
}
